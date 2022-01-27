using System;
using System.Windows;
using System.Windows.Input;
using Opc.Ua;

namespace OpcUA_Client
{
    public partial class MainWindow : Window
    {

        #region attributs
        private ReferenceDescription _selectedItemDesc;
        private MenuItem _selectedMenuItem;
        #endregion

        #region properties

        #endregion

        #region methods
        /// <summary>
        /// Handles a new Item selection in the treeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OPCDataTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Get the selected menu item from the EventArgs
            _selectedMenuItem = (MenuItem)e.NewValue;
            try
            {
                _selectedItemDesc = _selectedMenuItem.RefDesc;
            }
            catch
            {
                ;
            }
        }


        /// <summary>
        /// Show the Node Description of the selected node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_ClickDetail(object sender, RoutedEventArgs e)
        {
            _nodeDescription = new NodeDescription(_selectedItemDesc, _session);
            _nodeDescription.ShowDialog();  
        }



        /// <summary>
        /// Delete the old TreeView model and generate a new one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_ClickRefresh(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait; 

            _dataBrowsed = false;

            //Delet old TreeView Model 
            _dataTreeView = null;
            OPCDataTreeView.Items.Clear(); 

            //Browse data only one time
            if (!_dataBrowsed)
            {
                _dataTreeView = new DataTreeView(_session, (bool)BrowseStructs.IsChecked);
                _dataTreeView.CreateTreeViewData();
                OPCDataTreeView.Items.Add(_dataTreeView._BaseMenuItem);
                _dataBrowsed = true;
            }

            Mouse.OverrideCursor = null; 
        }


        /// <summary>
        /// Start Browsing the Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickBrowse(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;

            //Browse data only one time
            if (!_dataBrowsed)
            {

                _dataTreeView = new DataTreeView(_session, (bool)BrowseStructs.IsChecked);
                _dataTreeView.CreateTreeViewData();
                OPCDataTreeView.Items.Add(_dataTreeView._BaseMenuItem);
                _dataBrowsed = true;

            }

            Mouse.OverrideCursor = null;

        }

        /// <summary>
        /// Handler if Checkbox has checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseStructs_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Das Browsen der Einzelvariablen kann mit einer längeren Wartezeit verbunden sein!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            _dataBrowsed = false;
            OPCDataTreeView.Items.Clear();
        }


        /// <summary>
        /// Browse the nodes for an Array or UDT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_ClickShowMember(object sender, RoutedEventArgs e)
        {
            ReferenceDescriptionCollection tmpReferenceDescriptionCollection;

            try
            {
                tmpReferenceDescriptionCollection = _UAhelperAPI.BrowseNode(_selectedItemDesc);

                //Nodes available
                if (tmpReferenceDescriptionCollection.Count > 0)
                {
                    //Go throu all the nodes an try to browse again until no more nodes available
                    foreach (ReferenceDescription RefDesc in tmpReferenceDescriptionCollection)
                    {
                        //Neues MenueItem Anlegen
                        _selectedMenuItem.Items.Add(new MenuItem(RefDesc.DisplayName.ToString(), RefDesc));
                    }
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Kein Objekt ausgewählt!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OPCDataTreeView.Items.Refresh();
            OPCDataTreeView.UpdateLayout(); 
        }


        #endregion 

    }
}
