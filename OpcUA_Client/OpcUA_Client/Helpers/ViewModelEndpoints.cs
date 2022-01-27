using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper;

namespace OpcUA_Client
{
    public class ViewModelEndpoints
    {
        #region attribute
        private UAClientHelperAPI myClientHelperAPI;
        #endregion

        #region properties
        public ObservableCollection<String> EndpointList { get; }
        public List<EndpointDescription> EndpointDesc { get; set; }
        #endregion

        #region constructor
        public ViewModelEndpoints()
        {
            EndpointList = new ObservableCollection<string>() { "Bitte auswählen" };
            EndpointDesc = new List<EndpointDescription>();
            myClientHelperAPI = new UAClientHelperAPI(); 
        }
        #endregion

        #region methods
        /// <summary>
        /// Add a new Endpoint to the Textbox
        /// </summary>Add a single Endpoint to the textlist
        /// <param name="endpoint"></param>
        /// <param name="server"></param>
        private void addEndpointToList(EndpointDescription endpoint, ApplicationDescription server)
        {
            string securityPolicy = endpoint.SecurityPolicyUri.Remove(0, 42);
            string key = "Applikationsname: " + server.ApplicationName + " | " + "Sicherheitsart: " + endpoint.SecurityMode + " | " + "Sicherheitsrichtlinie: " + securityPolicy + " | " + "URL: " + endpoint.EndpointUrl;

            if (!EndpointList.Contains(key))
            {
                EndpointList.Add(key);
            }
        }


        /// <summary>
        /// Search Endpoints and Add them to the Textbox
        /// </summary>
        /// <param name="Url">Url of Discovery Server or OPC UA Server</param>
        public void getEndpoints(string Url)
        {
            int _i_numberOfEndpoints = 0;
            int _i_numberOfServer = 0; 

            try
            {
                //Find all Servers
                ApplicationDescriptionCollection servers = myClientHelperAPI.FindServers(Url);
                _i_numberOfServer = servers.Count; 
                foreach (ApplicationDescription ad in servers)
                {
                    //Find Endpoints for all found servers
                    foreach (string _url in ad.DiscoveryUrls)
                    {
                        try
                        {
                            //Create Endpoint Description collection
                            EndpointDescriptionCollection endpoints = myClientHelperAPI.GetEndpoints(_url);
                            _i_numberOfEndpoints = _i_numberOfEndpoints + endpoints.Count; 

                            //Show the Single Endpoints from the server
                            foreach(EndpointDescription endpoint in endpoints)
                            {
                                addEndpointToList(endpoint, ad);
                                //Add the Endpoint to the available Endpointlist
                                EndpointDesc.Add(endpoint);
                            }
                        }
                        catch (Exception exc1)
                        {
                            //Url cannot be reached -> GetEndpoints throw an exception
                            MessageBox.Show(exc1.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    if(_i_numberOfEndpoints == 0)
                    {
                        //No Endpoint on any Server
                        MessageBox.Show("Could not found any Endpoints on any Server", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        //User Information
                        MessageBox.Show("Found " + _i_numberOfEndpoints.ToString() + " Endpoints on " + _i_numberOfServer.ToString() + " Servers", "Information", MessageBoxButton.OK, MessageBoxImage.Information); 
                    }
                }
            }
            catch (Exception exc2)
            {
                //No Servers Found ,no Connection or wrong url -> GetServers throw an exception
                MessageBox.Show(exc2.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        #endregion

    }
}
