﻿#pragma checksum "..\..\AddNewsPanelUc.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A4C7097EE6656B1BE1AF35E78A70B48FDED17572"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Course_Project_Gym;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Course_Project_Gym {
    
    
    /// <summary>
    /// AddNewsPanelUc
    /// </summary>
    public partial class AddNewsPanelUc : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AddNewsPanelUc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddNewsPanel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddNewsPanelUc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseAddNewsPanelBtn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AddNewsPanelUc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewsNameTb;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AddNewsPanelUc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewsAboutTb;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AddNewsPanelUc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddImageInNews;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddNewsPanelUc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddFinallyBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Course Project Gym;component/addnewspaneluc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddNewsPanelUc.xaml"
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
            this.AddNewsPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.CloseAddNewsPanelBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.NewsNameTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NewsAboutTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddImageInNews = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\AddNewsPanelUc.xaml"
            this.AddImageInNews.Click += new System.Windows.RoutedEventHandler(this.AddImageInNews_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddFinallyBtn = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\AddNewsPanelUc.xaml"
            this.AddFinallyBtn.Click += new System.Windows.RoutedEventHandler(this.AddFinallyBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

