﻿#pragma checksum "..\..\..\ApplicationWindows\AddPlayerWin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F479EEC66A0CC7DF7B3BDAAB26E04A19"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
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


namespace volleyball_stat {
    
    
    /// <summary>
    /// AddPlayer
    /// </summary>
    public partial class AddPlayer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox teamsCombobox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox playerName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox playerNumber;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_AddPlayer;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel_AddPlayer;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox playerName_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/volleyball_stat;component/applicationwindows/addplayerwin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
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
            
            #line 4 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
            ((volleyball_stat.AddPlayer)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
            ((volleyball_stat.AddPlayer)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.teamsCombobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
            this.teamsCombobox.DropDownOpened += new System.EventHandler(this.teamsCombobox_DropDownOpened);
            
            #line default
            #line hidden
            return;
            case 3:
            this.playerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.playerNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Save_AddPlayer = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
            this.Save_AddPlayer.Click += new System.Windows.RoutedEventHandler(this.Save_AddPlayer_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Cancel_AddPlayer = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\ApplicationWindows\AddPlayerWin.xaml"
            this.Cancel_AddPlayer.Click += new System.Windows.RoutedEventHandler(this.Cancel_AddPlayer_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.playerName_Copy = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

