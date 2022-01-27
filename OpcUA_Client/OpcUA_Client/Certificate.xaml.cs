using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Opc.Ua;

namespace OpcUA_Client
{
    /// <summary>
    /// Interaktionslogik für Certificate.xaml
    /// </summary>
    public partial class Certificate : Window
    {
        #region attribute
        private CertificateValidationEventArgs eventArgs = null; 
        #endregion

        public Certificate(CertificateValidationEventArgs e)
        {
            InitializeComponent();
            eventArgs = e;

            //Fill the Table with the information
            IssuerInfo.Text = eventArgs.Certificate.IssuerName.Name;
            ValidFrom.Text = eventArgs.Certificate.NotBefore.ToString();
            ValidTo.Text = eventArgs.Certificate.NotAfter.ToString();
            SerialNumber.Text = eventArgs.Certificate.SerialNumber; 
            Algorithm.Text = eventArgs.Certificate.SignatureAlgorithm.FriendlyName;
            CipherStrengh.Text = eventArgs.Certificate.PublicKey.Key.KeySize.ToString();
            Thumbprint.Text = eventArgs.Certificate.Thumbprint;
            TableURI.Text = eventArgs.Certificate.GetNameInfo(X509NameType.UrlName, false); 
        }

        /// <summary>
        /// Create a new Certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            eventArgs.Accept = true;

            //Open the Store and add a new OPC UA certificate 
            X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            try
            {
                store.Add(eventArgs.Certificate);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
            
            store.Close();
            Close(); 
        }

        /// <summary>
        /// Creation of new Certificate cancled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            eventArgs.Accept = false;
            Close(); 
        }
    }
}
