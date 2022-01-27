using System.Collections.Generic;
using System.Windows;
using Opc.Ua;
using Opc.Ua.Client; 
using Siemens.UAClientHelper; 


namespace OpcUA_Client
{
    /// <summary>
    /// Interaktionslogik für NodeDescription.xaml
    /// </summary>
    public partial class NodeDescription : Window
    {
        #region attribute
        ReferenceDescription _refDesc;
        UAClientHelperAPI _UaClientHelperAPI;
        #endregion

        public NodeDescription(ReferenceDescription refDesc, Session session)
        {
            InitializeComponent();
            _refDesc = refDesc;
            _UaClientHelperAPI = new UAClientHelperAPI();
            _UaClientHelperAPI.mSession = session; 
            ShowNodeDescription();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickClose(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        /// <summary>
        /// Show the Description of the chosen node
        /// </summary>
        private void ShowNodeDescription()
        {
            Node node = _UaClientHelperAPI.ReadNode(_refDesc.NodeId.ToString());
            VariableNode variableNode = new VariableNode(); 

            NodeID.Text = _refDesc.NodeId.ToString();
            NamespaceIndex.Text = _refDesc.NodeId.NamespaceIndex.ToString();
            IdentifierType.Text = _refDesc.NodeId.IdType.ToString();
            Identifier.Text = _refDesc.NodeId.Identifier.ToString();
            BrowseName.Text = _refDesc.BrowseName.ToString();
            DisplayName.Text = _refDesc.DisplayName.ToString();
            NodeClass.Text = _refDesc.NodeClass.ToString();

            if(node.Description != null)
            {
                NodeDesc.Text = node.Description.ToString(); 
            }
            else
            {
                NodeDesc.Text = "NULL"; 
            }

            TypeDefinition.Text = _refDesc.TypeDefinition.ToString();
            WriteMask.Text = node.WriteMask.ToString();

            if(node.NodeClass == Opc.Ua.NodeClass.Variable)
            {
                variableNode = (VariableNode)node.DataLock;
                List<NodeId> nodeIds = new List<NodeId>();
                List<string> displayNames = new List<string>();
                List<ServiceResult> errors = new List<ServiceResult>();
                NodeId nodeId = new NodeId(variableNode.DataType);
                nodeIds.Add(nodeId);
                _UaClientHelperAPI.mSession.ReadDisplayName(nodeIds, out displayNames, out errors);

                DataType.Text = displayNames[0];
                RankValue.Text = variableNode.ValueRank.ToString();
                ArrayDimension.Text = variableNode.ArrayDimensions.ToString();
                AcessLevel1.Text = variableNode.AccessLevel.ToString();
                MinimumSamplingIntervall.Text = variableNode.MinimumSamplingInterval.ToString();
                Historizing.Text = variableNode.Historizing.ToString();
            }
            
        }
    }
}
