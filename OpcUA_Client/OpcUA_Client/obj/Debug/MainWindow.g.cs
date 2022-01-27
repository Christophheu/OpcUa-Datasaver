﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B2E4930992E63C885C2B9AA00136A12E2D2CEE44013666A0ABCC7C05D5A6D6EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using OpcUA_Client;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace OpcUA_Client {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 485 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControll;
        
        #line default
        #line hidden
        
        
        #line 487 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem TabConnection;
        
        #line default
        #line hidden
        
        
        #line 497 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonShowEndpoints;
        
        #line default
        #line hidden
        
        
        #line 498 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EndpointsList;
        
        #line default
        #line hidden
        
        
        #line 500 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox URLTextbox;
        
        #line default
        #line hidden
        
        
        #line 501 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonConnect;
        
        #line default
        #line hidden
        
        
        #line 506 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 507 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameBox;
        
        #line default
        #line hidden
        
        
        #line 508 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButtonAnonym;
        
        #line default
        #line hidden
        
        
        #line 509 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButtonPassword;
        
        #line default
        #line hidden
        
        
        #line 513 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ConntectedImg;
        
        #line default
        #line hidden
        
        
        #line 514 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DisconnectedImg;
        
        #line default
        #line hidden
        
        
        #line 519 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem TabData;
        
        #line default
        #line hidden
        
        
        #line 520 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TabDataGrid;
        
        #line default
        #line hidden
        
        
        #line 522 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView OPCDataTreeView;
        
        #line default
        #line hidden
        
        
        #line 532 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ShowData;
        
        #line default
        #line hidden
        
        
        #line 534 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BrowseStructs;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OpcUA_Client;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\MainWindow.xaml"
            ((OpcUA_Client.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\MainWindow.xaml"
            ((OpcUA_Client.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TabControll = ((System.Windows.Controls.TabControl)(target));
            
            #line 485 "..\..\MainWindow.xaml"
            this.TabControll.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TabConnection = ((System.Windows.Controls.TabItem)(target));
            return;
            case 4:
            this.ButtonShowEndpoints = ((System.Windows.Controls.Button)(target));
            
            #line 497 "..\..\MainWindow.xaml"
            this.ButtonShowEndpoints.Click += new System.Windows.RoutedEventHandler(this.ButtonShowEndpoints_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EndpointsList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 498 "..\..\MainWindow.xaml"
            this.EndpointsList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.EndpointsList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.URLTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ButtonConnect = ((System.Windows.Controls.Button)(target));
            
            #line 501 "..\..\MainWindow.xaml"
            this.ButtonConnect.Click += new System.Windows.RoutedEventHandler(this.ButtonConnect_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.UsernameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.RadioButtonAnonym = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 11:
            this.RadioButtonPassword = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 12:
            this.ConntectedImg = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.DisconnectedImg = ((System.Windows.Controls.Image)(target));
            return;
            case 14:
            this.TabData = ((System.Windows.Controls.TabItem)(target));
            return;
            case 15:
            this.TabDataGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 16:
            this.OPCDataTreeView = ((System.Windows.Controls.TreeView)(target));
            
            #line 522 "..\..\MainWindow.xaml"
            this.OPCDataTreeView.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.OPCDataTreeView_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 525 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_ClickDetail);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 526 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_ClickRefresh);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 527 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_ClickShowMember);
            
            #line default
            #line hidden
            return;
            case 20:
            this.ShowData = ((System.Windows.Controls.ListView)(target));
            
            #line 532 "..\..\MainWindow.xaml"
            this.ShowData.Drop += new System.Windows.DragEventHandler(this.ShowData_Drop);
            
            #line default
            #line hidden
            return;
            case 21:
            this.BrowseStructs = ((System.Windows.Controls.CheckBox)(target));
            
            #line 534 "..\..\MainWindow.xaml"
            this.BrowseStructs.Checked += new System.Windows.RoutedEventHandler(this.BrowseStructs_Checked);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 535 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ClickBrowse);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 536 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_ClearList);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 538 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_SaveMonVarsAs);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 539 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_OpenMonitorData);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 540 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ShowSelectedVariables);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 541 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_SaveSelectedValues);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 542 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_WriteValues);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
