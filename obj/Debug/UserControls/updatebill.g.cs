﻿#pragma checksum "..\..\..\UserControls\updatebill.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2EB91DFC7DE439BF4F7DD3EE8866879B269247C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using StoreManagement.UserControls;
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


namespace StoreManagement.UserControls {
    
    
    /// <summary>
    /// updatebill
    /// </summary>
    public partial class updatebill : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 18 "..\..\..\UserControls\updatebill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Datefrom;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UserControls\updatebill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Dateto;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UserControls\updatebill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDCashier;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\UserControls\updatebill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listbillupdate;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\UserControls\updatebill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn deleteColumn;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\UserControls\updatebill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn editColumn;
        
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
            System.Uri resourceLocater = new System.Uri("/StoreManagement;component/usercontrols/updatebill.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\updatebill.xaml"
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
            
            #line 9 "..\..\..\UserControls\updatebill.xaml"
            ((StoreManagement.UserControls.updatebill)(target)).IsEnabledChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.UserControl_IsEnabledChanged);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\UserControls\updatebill.xaml"
            ((StoreManagement.UserControls.updatebill)(target)).ToolTipClosing += new System.Windows.Controls.ToolTipEventHandler(this.UserControl_ToolTipClosing);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\UserControls\updatebill.xaml"
            ((StoreManagement.UserControls.updatebill)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.UserControl_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Datefrom = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.Dateto = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.IDCashier = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 28 "..\..\..\UserControls\updatebill.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.listbillupdate = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.deleteColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 9:
            this.editColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            
            #line 46 "..\..\..\UserControls\updatebill.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Xoa_Click);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 53 "..\..\..\UserControls\updatebill.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

