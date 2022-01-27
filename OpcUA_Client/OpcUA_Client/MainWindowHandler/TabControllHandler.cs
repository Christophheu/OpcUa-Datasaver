using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Opc.Ua; 

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
        /// Handles the Tab change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Datenansicht isSelected?
            switch (TabControll.SelectedIndex)
            {
                case 0:
                    break; 

                case 1: 
                    TabDataSelected();
                    break;

                default:
                    break; 
            }
        }




        /// <summary>
        /// Handles the events if the Datatab is Selected
        /// </summary>
        private void TabDataSelected()
        {
            //Create a new Subscribtion
            createSubscribtion();

        }


        /// <summary>
        /// Create a new Subscription if Tab data is selected
        /// </summary>
        private void createSubscribtion()
        {
            try
            {
                //Create a new subscibtion if there is no one
                if (_subscription == null)
                {
                    _subscription = _UAhelperAPI.Subscribe(1000);
                }
            }
            catch(Exception excp)
            {
                MessageBox.Show(excp.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion 

    }
}
