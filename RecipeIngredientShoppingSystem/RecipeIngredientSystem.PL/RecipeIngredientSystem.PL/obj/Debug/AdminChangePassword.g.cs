#pragma checksum "..\..\AdminChangePassword.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CDF47A3AE8BD0DEFDF1FB28DFF8C42A382B20BDB6EC44FF41B3F43D53AFB718F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RecipeIngredientSystem.PL;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace RecipeIngredientSystem.PL {
    
    
    /// <summary>
    /// AdminChangePassword
    /// </summary>
    public partial class AdminChangePassword : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\AdminChangePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtusername;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AdminChangePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtpassword;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AdminChangePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button changepassbtn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AdminChangePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button homepagebtn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AdminChangePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backbtn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AdminChangePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtanswer;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AdminChangePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtquestion;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AdminChangePassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtconfirmpass;
        
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
            System.Uri resourceLocater = new System.Uri("/RecipeIngredientSystem.PL;component/adminchangepassword.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminChangePassword.xaml"
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
            this.txtusername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtpassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.changepassbtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\AdminChangePassword.xaml"
            this.changepassbtn.Click += new System.Windows.RoutedEventHandler(this.changepassbtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.homepagebtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\AdminChangePassword.xaml"
            this.homepagebtn.Click += new System.Windows.RoutedEventHandler(this.homepagebtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.backbtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\AdminChangePassword.xaml"
            this.backbtn.Click += new System.Windows.RoutedEventHandler(this.backbtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtanswer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtquestion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtconfirmpass = ((System.Windows.Controls.PasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

