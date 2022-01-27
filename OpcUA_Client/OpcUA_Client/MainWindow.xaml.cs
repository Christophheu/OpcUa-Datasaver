using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper;

namespace OpcUA_Client
{

    //Additionaly parts of this claas contained in: 
    //  -ConnectTabHandlers
    //  -OPCEventHandler
    //  -TabControllHandler

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region constructors
        /// <summary>
        /// Main Window Constructor
        /// </summary>
        public MainWindow()
        {
            //Create global Objects
            _endpoints = new ViewModelEndpoints();
            obversableDictionary = new ObservableDictionary<String, String>();

            //Init functions
            InitializeComponent();
            ResetUserInterface();
            //set DataContext
            DataContext = this; 
        }
        #endregion

        #region attributes
        private ViewModelEndpoints _endpoints;
        private Session _session;
        private Certificate _certificate;
        private Subscription _subscription;
        private UAClientHelperAPI _UAhelperAPI;
        private EndpointDescription _endpointDescription; 
        private DataTreeView _dataTreeView;
        private bool _dataBrowsed = false;
        private NodeDescription _nodeDescription;
        private List<MonitoredItem> _monitoredItems = new List<MonitoredItem>();
        private ObservableDictionary<String, String> obversableDictionary;
        #endregion

        #region Properities
        /// <summary>
        /// 
        /// </summary>
        public ViewModelEndpoints Endpoint
        {
            get { return _endpoints; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableDictionary<String, String> GetObversableDictionary
        {
            get { return obversableDictionary; }
        }
        #endregion 

        #region User Controll Eventhandler

        /// <summary>
        /// View Loaded Eventhandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _UAhelperAPI = new UAClientHelperAPI();

        }

        /// <summary>
        /// View Closed Eventhandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
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
        }

        #endregion

        #region Helper methods
        /// <summary>
        /// 
        /// </summary>
        private void ResetUserInterface()
        {
            //Reset Button
            ButtonConnect.Content = "Verbinden";
            ConntectedImg.Visibility = Visibility.Hidden;
            DisconnectedImg.Visibility = Visibility.Visible;
            TabData.IsEnabled = false; 
        }



        #endregion

    }
}
