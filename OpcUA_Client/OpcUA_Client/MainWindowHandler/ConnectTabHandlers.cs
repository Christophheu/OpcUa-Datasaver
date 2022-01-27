using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
        /// Show the available endpoints found with a given url
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShowEndpoints_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait; 
            try
            {
                _endpoints.getEndpoints(URLTextbox.Text);
            }
            catch {; }
            finally { Mouse.OverrideCursor = null; }
            
        }


        /// <summary>
        /// Connect Button Click Eventhandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {

            //Connect or Disconnect Session??
            if (_session != null && !_session.Disposed)
            {
                try
                {
                    _subscription.Delete(true);
                }
                catch
                {
                    ;
                }
                _UAhelperAPI.Disconnect();
                _session = _UAhelperAPI.Session;
                ResetUserInterface();
            }
            //Connect the Client
            else
            {
                try
                {
                    //Change mouse to wait symbol
                    Mouse.OverrideCursor = Cursors.Wait;

                    //Register Eventhandler
                    _UAhelperAPI.KeepAliveNotification += new KeepAliveEventHandler(Notification_KeepAlive);
                    _UAhelperAPI.CertificateValidationNotification += new CertificateValidationEventHandler(Notification_ServerCertificate);

                    //Check if Endpoint is selected
                    if (_endpointDescription != null)
                    {
                        //Use Password?
                        bool usePassword = false;
                        if(RadioButtonPassword.IsChecked == true)
                        {
                            usePassword = true; 
                        }
                        else
                        {
                            usePassword = false; 
                        }

                        //Try to connect
                        _UAhelperAPI.Connect(_endpointDescription, usePassword, UsernameBox.Text, PasswordBox.Password).Wait();
                        _session = _UAhelperAPI.Session;
                        ButtonConnect.Content = "Disconnect";
                        if (_session.Connected)
                        {
                            ConntectedImg.Visibility = Visibility.Visible;
                            DisconnectedImg.Visibility = Visibility.Hidden;
                        }
                        TabData.IsEnabled = true;
                    }
                    //Error, no enpoint selected
                    else
                    {
                        MessageBox.Show("Bitte Endpunkt auswählen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception exc1)
                {
                    _certificate = null;
                    ResetUserInterface();
                    MessageBox.Show(exc1.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    Mouse.OverrideCursor = null; 
                }
            }
        }


        /// <summary>
        /// Endpoint Selection Changed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndpointsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Index 0 is default Text with no function!!!
            if (EndpointsList.SelectedIndex > 0)
            {
                _endpointDescription = _endpoints.EndpointDesc[EndpointsList.SelectedIndex - 1];
            }
        }
        #endregion

    }
}
