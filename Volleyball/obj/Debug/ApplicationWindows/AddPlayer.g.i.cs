﻿#pragma checksum "..\..\..\ApplicationWindows\AddPlayer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "804258CDD30DB7D2F4244607A679F98C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Volleyball {
    
    
    /// <summary>
    /// AddPlayer
    /// </summary>
    public partial class AddPlayer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\ApplicationWindows\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox teamsCombobox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\ApplicationWindows\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox playerName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\ApplicationWindows\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox playerNumber;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\ApplicationWindows\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox amplua;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\ApplicationWindows\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox captainSign;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\ApplicationWindows\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\ApplicationWindows\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateButton;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\ApplicationWindows\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Volleyball;component/applicationwindows/addplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ApplicationWindows\AddPlayer.xaml"
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
            
            #line 4 "..\..\..\ApplicationWindows\AddPlayer.xaml"
            ((Volleyball.AddPlayer)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\ApplicationWindows\AddPlayer.xaml"
            ((Volleyball.AddPlayer)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.teamsCombobox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.playerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.playerNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.amplua = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.captainSign = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\ApplicationWindows\AddPlayer.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.updateButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\ApplicationWindows\AddPlayer.xaml"
            this.updateButton.Click += new System.Windows.RoutedEventHandler(this.UpdateButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\ApplicationWindows\AddPlayer.xaml"
            this.cancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

