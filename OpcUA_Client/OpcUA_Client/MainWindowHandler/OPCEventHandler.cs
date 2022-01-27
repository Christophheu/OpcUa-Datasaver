using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Media;
using Opc.Ua;
using Opc.Ua.Client;

namespace OpcUA_Client
{
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Global OPC UA Handler (from Siemens OPC UA Sample project adapted to this application)
        /// </summary>
        #region Opc Event Handlers
        private void Notification_ServerCertificate(CertificateValidator cert, CertificateValidationEventArgs e)
        {
            //Handle certificate here
            //To accept a certificate manually move it to the root folder (Start > mmc.exe > add snap-in > certificates)
            //Or handle via UAClientCertForm
            if (!CheckAccess())
            {
                this.Dispatcher.BeginInvoke(new CertificateValidationEventHandler(Notification_ServerCertificate), cert, e);
                return;
            }

            try
            {
                //Search for the server's certificate in store; if found -> accept
                X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509CertificateCollection certCol = store.Certificates.Find(X509FindType.FindByThumbprint, e.Certificate.Thumbprint, true);
                store.Close();
                //is there a OPC UA certificate available??
                if (certCol.Capacity > 0)
                {
                    e.Accept = true;
                }

                //Show cert dialog if cert hasn't been accepted yet
                else
                {
                    if (!e.Accept && _certificate == null)
                    {
                        _certificate = new Certificate(e);
                        _certificate.ShowDialog();
                    }
                }
            }
            catch
            {
                ;
            }
        }

        /// <summary>
        /// Keep Alive event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notification_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            //Check if the Method is in the Dispatcher and availabe for a call
            if (!CheckAccess())
            {
                this.Dispatcher.BeginInvoke(new KeepAliveEventHandler(Notification_KeepAlive), sender, e);  //Add Kepp alive Handler to Dispatcher (asynchronious execution)
                return;
            }

            try
            {
                // check for events from discarded sessions.
                if (!Object.ReferenceEquals(sender, _session))
                {
                    return;
                }

                // check for disconnected session.
                if (!ServiceResult.IsGood(e.Status))
                {
                    // try reconnecting using the existing session state
                    ConntectedImg.Visibility = Visibility.Hidden;
                    DisconnectedImg.Visibility = Visibility.Visible;
                    _session.Reconnect();
                }
                else
                {
                    ConntectedImg.Visibility = Visibility.Visible;
                    DisconnectedImg.Visibility = Visibility.Hidden;
                }            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                ResetUserInterface();
            }
        }

        /// <summary>
        /// Eventhandler for changed monitored items
        /// </summary>
        /// <param name="monitoredItem"></param>
        /// <param name="e"></param>
        private void Notification_MonitoredItem(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (!CheckAccess())
            {
                this.Dispatcher.BeginInvoke(new MonitoredItemNotificationEventHandler(Notification_MonitoredItem), monitoredItem, e);
                return;
            }
            MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;
            if (notification == null)
            {
                return;
            }

            //Get the Key
            String tmp_key = monitoredItem.StartNodeId.ToString();

            //Add data to dictionary
            if (obversableDictionary.ContainsKey(tmp_key))
            {
                obversableDictionary[tmp_key] = notification.Value.WrappedValue.ToString();
            }
            else
            {
                //Add new Key + Value
                obversableDictionary.Add(tmp_key, notification.Value.WrappedValue.ToString());
            }

        }

        #endregion
    }
}
