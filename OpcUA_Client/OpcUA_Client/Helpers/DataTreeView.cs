using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper; 

namespace OpcUA_Client
{

    public class DataTreeView 
    {
        #region attributes
        private ReferenceDescriptionCollection _referenceDescriptionCollection;
        private UAClientHelperAPI _UAhelperAPI;
        private bool _BrowseStructs;

        #endregion

        #region properties 
        public MenuItem _BaseMenuItem { get; }
        #endregion

        #region constructor
        //Build the Tree
        public DataTreeView(Session _session, bool BrowseStructs)
        {
            _UAhelperAPI = new UAClientHelperAPI();
            _UAhelperAPI.mSession = _session; 
            _BaseMenuItem = new MenuItem("Data", null);
            _BrowseStructs = BrowseStructs; 
        }
        #endregion

        #region methods 
        /// <summary>
        /// Creates the Data for the TreeView
        /// </summary>
        public void CreateTreeViewData()
        { 
            //Build root directory
            if (_referenceDescriptionCollection == null)
            {
                try
                {
                    _referenceDescriptionCollection = _UAhelperAPI.BrowseRoot();

                    //Find all Elemnts in the root directories
                    foreach(ReferenceDescription RefDesc in _referenceDescriptionCollection)
                    {
                        //Create the Root directories
                        _BaseMenuItem.Items.Add(new MenuItem(RefDesc.DisplayName.ToString(), RefDesc));

                        //Browse nodes in the new created folder
                        BrowseNodes(RefDesc, _BaseMenuItem.Items.Last<MenuItem>());
                    }
                }
                catch (Exception exc1)
                {
                    MessageBox.Show(exc1.Message, "Error" , MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        /// <summary>
        /// Recursive Browse of the Object Nodes
        /// </summary>
        /// <param name="_refDesc"></param>
        /// <param name="items"></param>
        private void BrowseNodes(ReferenceDescription _refDesc, MenuItem items)
        {

            ReferenceDescriptionCollection tmpReferenceDescriptionCollection;
            try
            {
                tmpReferenceDescriptionCollection = _UAhelperAPI.BrowseNode(_refDesc);

                //Nodes available
                if (tmpReferenceDescriptionCollection.Count > 0)
                {
                    //Go throu all the nodes an try to browse again until no more nodes available
                    foreach(ReferenceDescription RefDesc in tmpReferenceDescriptionCollection)
                    {
                        //Create new MenuItem
                        items.Items.Add(new MenuItem(RefDesc.DisplayName.ToString(), RefDesc));

                        //Nodes is a directory again
                        if (RefDesc.NodeClass == NodeClass.Object && !_BrowseStructs)
                        {
                            BrowseNodes(RefDesc, items.Items.Last<MenuItem>());
                        }
                        else if (_BrowseStructs)
                        {
                            BrowseNodes(RefDesc, items.Items.Last<MenuItem>());
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception exc2)
            {
                MessageBox.Show(exc2.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// Create a List of the selected Nodes
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        public List<ReferenceDescription> getSelectedNodeVariables(MenuItem MenuItem)
        {
            List<ReferenceDescription> tmpDescList = new List<ReferenceDescription>(); 

            if(MenuItem.Items.Count > 0)
            {
                foreach (MenuItem item in MenuItem.Items)
                {
                    if(item.isChecked == true)
                    {
                        tmpDescList.Add(item.RefDesc);
                    }
                    if(item.Items.Count > 0)
                    {
                        tmpDescList.AddRange(getSelectedNodeVariables(item));
                    }
                }
            }
            return tmpDescList; 
        }
        #endregion
    }

}
