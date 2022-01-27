using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Opc.Ua;
using Opc.Ua.Client;

namespace OpcUA_Client
{
    public partial class MainWindow : Window
    {

        #region attributs
        int _CountMonitoredItems = 0;
        #endregion

        #region properties 

        #endregion

        #region methods

        /// <summary>
        ///  Set the DragDrop Effects during mouse is moving
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            //Left button pressed over treeview?
            if (e.LeftButton == MouseButtonState.Pressed && OPCDataTreeView.IsMouseOver)
            {
                DataObject data = new DataObject();
                try
                {
                    data.SetData("MenuItem", _selectedMenuItem);
                }
                catch
                {
                    ; 
                }

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }

            e.Handled = true;
        }

        /// <summary>
        /// Set the Cursor symbol during drag and drop action
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }


        /// <summary>
        /// Eventhandler for the drop Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowData_Drop(object sender, DragEventArgs e)
        {

            bool tmp_alreadyMonitored = false; 

            //Get the Droped object and cast it to a new menu item
            MenuItem MenuItem = (MenuItem)e.Data.GetData("MenuItem");

            //Item already monitored??
            foreach (MonitoredItem monitoredItem in _monitoredItems)
            {
                if (monitoredItem.StartNodeId.ToString() == MenuItem.RefDesc.NodeId.ToString())
                {
                    MessageBox.Show("Die Variable wird bereits beobachtet!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    tmp_alreadyMonitored = true; 
                }
            }

            //Add the new Item
            if(!tmp_alreadyMonitored)
            {
                AddNewMonitoredItem(MenuItem.RefDesc.NodeId.ToString());
            }
        }

        /// <summary>
        /// Add the new droped item to the list of monitored items
        /// </summary>
        /// <param name="NodeID"></param>
        private void AddNewMonitoredItem(String NodeID)
        {
            _monitoredItems.Add(_UAhelperAPI.AddMonitoredItem(_subscription, NodeID , "Item " + _CountMonitoredItems, 1));
            _UAhelperAPI.ItemChangedNotification += new MonitoredItemNotificationEventHandler(Notification_MonitoredItem);
            _CountMonitoredItems++;
        }

        #endregion
    }
}
