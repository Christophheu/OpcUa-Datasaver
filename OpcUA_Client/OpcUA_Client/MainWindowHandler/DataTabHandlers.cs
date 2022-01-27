using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using CsvHelper;
using Microsoft.Win32;
using Opc.Ua;
using Opc.Ua.Client;

namespace OpcUA_Client
{
    public partial class MainWindow : Window
    {

        #region attributes

        #endregion

        #region properties

        #endregion

        #region methods
        /// <summary>
        /// Clear the list of the Monitored items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_ClearList(object sender, RoutedEventArgs e)
        {
            obversableDictionary.Clear();
            RemoveMonitoredItems(_monitoredItems);
        }

        /// <summary>
        /// Remove the monitored items
        /// </summary>
        /// <param name="monitoredItems"></param>
        private void RemoveMonitoredItems(List<MonitoredItem> monitoredItems)
        {
            foreach (MonitoredItem Item in monitoredItems)
            {
                _UAhelperAPI.RemoveMonitoredItem(_subscription, Item);
            }
            _monitoredItems.Clear();
        }

        /// <summary>
        /// Save actual values of the monitored variables in a csv list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SaveMonVarsAs(object sender, RoutedEventArgs e)
        {
            //Check if Data available
            if(obversableDictionary.Count == 0)
            {
                MessageBox.Show("Keine Variablen zum Speichern im Beobachtungsfenster!!!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return; 
            }

            //Create a new save file dialog
            SaveFileDialog saveDialog = new SaveFileDialog();
            //Set title
            saveDialog.Title = "Aktualwerte Speichern unter";
            //Set filter 
            saveDialog.Filter = "CSV file(*.csv)| *.csv";
            //Set Default path
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //Set Default Filename 
            saveDialog.FileName = "MonitordVariablesSave";

            if (saveDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveDialog.FileName))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    //temp vars
                    CsvData data = new CsvData(); 

                    //Write the header
                    try
                    {
                        csv.WriteHeader<CsvData>();
                        csv.NextRecord();
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show(exception.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                    //Write the monitored Data
                    foreach(var entry in obversableDictionary)
                    {
                        //Create the data
                        data.NodeID = entry.Key.ToString();
                        data.Value = entry.Value.ToString();

                        //Write the data 
                        try
                        {
                            csv.WriteRecord(data);
                            csv.NextRecord();
                        }
                        catch(Exception exception)
                        {
                            MessageBox.Show(exception.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        
                    }
                }
            }
        }


        /// <summary>
        /// Open a saved watchlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OpenMonitorData(object sender, RoutedEventArgs e)
        {
            //Create a new open file dialog 
            OpenFileDialog openDialog = new OpenFileDialog();
            //Set Title
            openDialog.Title = "Variablenliste öffnen";
            //Set filter 
            openDialog.Filter = " file (*.csv)| *.csv";
            //Set Default path 
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            if (openDialog.ShowDialog() == true)
            {
                using(var reader = new StreamReader(openDialog.FileName))
                using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    //Read the header
                    try
                    {
                        csv.Read();
                        csv.ReadHeader(); 
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show(exception.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    //Clear old List of Monitored items
                    obversableDictionary.Clear();
                    RemoveMonitoredItems(_monitoredItems);

                    //Read the new Data
                    try
                    {
                        //Get the data
                        while(csv.Read())
                        {
                            var record = csv.GetRecord<CsvData>();
                            //Write it in the obversable Dictionary
                            AddNewMonitoredItem(record.NodeID);
                            obversableDictionary.Add(record.NodeID, record.Value);
                        }

                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show(exception.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Add the selected nodes to the watchlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ShowSelectedVariables(object sender, RoutedEventArgs e)
        {
            //Get a list of the selected NodeID´s
            List<ReferenceDescription> refList = new List<ReferenceDescription>();
            try
            {
                refList = _dataTreeView.getSelectedNodeVariables(_dataTreeView._BaseMenuItem);
            }
            catch(System.NullReferenceException)
            {
                MessageBox.Show("Lesen sie zuerst die Serverdaten ein!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            

            if(refList.Count == 0)
            {
                MessageBox.Show("Kein Objekt angewählt", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return; 
            }

            //Clear old List of Monitored items
            obversableDictionary.Clear();
            RemoveMonitoredItems(_monitoredItems);

            //Add the Variables
            foreach (var entry in refList)
            {
                AddNewMonitoredItem(entry.NodeId.ToString());
                obversableDictionary.Add(entry.NodeId.ToString(), "null");
            }
        }

        /// <summary>
        /// Get the values of the selected variables and save it in a csv list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SaveSelectedValues(object sender, RoutedEventArgs e)
        {
            int NodeIdIndex = 0;

            //Get a list of the selected NodeID´s
            List<ReferenceDescription> refList = new List<ReferenceDescription>();
            try
            {
                refList = _dataTreeView.getSelectedNodeVariables(_dataTreeView._BaseMenuItem);
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Lesen sie zuerst die Serverdaten ein!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Create a list of NodeID Strings
            List<string> IDs = new List<string>(); 
            foreach(var Node in refList)
            {
                IDs.Add(Node.NodeId.ToString());
            }

            //Read the values
            List<string> values = new List<string>(); 
            try
            {
                values = _UAhelperAPI.ReadValues(IDs);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //Create a new save file dialog
            SaveFileDialog saveDialog = new SaveFileDialog();
            //Set title
            saveDialog.Title = "Werteliste Speichern unter";
            //Set filter 
            saveDialog.Filter = "CSV file(*.csv)| *.csv";
            //Set Default path
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //Set Default Filename 
            saveDialog.FileName = "SelectedVariablesSave";

            if (saveDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveDialog.FileName))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    //temp vars
                    CsvData data = new CsvData();

                    //Write the header
                    try
                    {
                        csv.WriteHeader<CsvData>();
                        csv.NextRecord();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    //Write the monitored Data
                    foreach (var entry in IDs)
                    {
                        //Create the data
                        data.NodeID = entry;
                        data.Value = values[NodeIdIndex++];

                        //Write the data 
                        try
                        {
                            csv.WriteRecord(data);
                            csv.NextRecord();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
            }
        }



        /// <summary>
        /// Write the values from the csv input list to the opc node variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_WriteValues(object sender, RoutedEventArgs e)
        {
            //Create a new open file dialog 
            OpenFileDialog openDialog = new OpenFileDialog();
            //Set Title
            openDialog.Title = "Variablenliste öffnen";
            //Set filter 
            openDialog.Filter = " file (*.csv)| *.csv";
            //Set Default path 
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            if (openDialog.ShowDialog() == true)
            {
                List<string> IDs = new List<string>();
                List<string> values = new List<string>(); 

                using (var reader = new StreamReader(openDialog.FileName))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    //Read the header
                    try
                    {
                        csv.Read();
                        csv.ReadHeader();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    //Read the new Data
                    try
                    {
                        //Get the data
                        while (csv.Read())
                        {
                            var record = csv.GetRecord<CsvData>();
                            //Save IDs and values
                            IDs.Add(record.NodeID);
                            values.Add(record.Value); 
                        }

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    //Write the data to the server
                    try
                    {
                        _UAhelperAPI.WriteValues(values, IDs); 
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show(exception.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        #endregion

    }
}
