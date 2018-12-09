﻿#pragma checksum "..\..\CashierDashboard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "067C8C53F7DB45B9AE4726CF33CE1F4F2BCEF7AB"
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
using StoreManagement;
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


namespace StoreManagement {
    
    
    /// <summary>
    /// CashierDashboard
    /// </summary>
    public partial class CashierDashboard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\CashierDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\CashierDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMaximize;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\CashierDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\CashierDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StoreManagement.UserControls.sale selling;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\CashierDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StoreManagement.UserControls.basket basket;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\CashierDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StoreManagement.UserControls.updatebill updatebill;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\CashierDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TrainsitionigContentSlide;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\CashierDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridCursor;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\CashierDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewMenu;
        
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
            System.Uri resourceLocater = new System.Uri("/StoreManagement;component/cashierdashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CashierDashboard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\CashierDashboard.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.BtnMinimize_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnMaximize = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\CashierDashboard.xaml"
            this.btnMaximize.Click += new System.Windows.RoutedEventHandler(this.BtnMaximize_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\CashierDashboard.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.BtnClose_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.selling = ((StoreManagement.UserControls.sale)(target));
            return;
            case 5:
            this.basket = ((StoreManagement.UserControls.basket)(target));
            return;
            case 6:
            this.updatebill = ((StoreManagement.UserControls.updatebill)(target));
            return;
            case 7:
            this.TrainsitionigContentSlide = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 8:
            this.GridCursor = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.ListViewMenu = ((System.Windows.Controls.ListView)(target));
            
            #line 55 "..\..\CashierDashboard.xaml"
            this.ListViewMenu.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewMenu_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

