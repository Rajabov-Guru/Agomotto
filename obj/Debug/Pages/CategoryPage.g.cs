#pragma checksum "..\..\..\Pages\CategoryPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F703DCCE39D2A652877ED3EBD13E2BCAC3C334F5486CEC386C1A1956CD6F55D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Agamotto.Pages;
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


namespace Agamotto.Pages {
    
    
    /// <summary>
    /// CategoryPage
    /// </summary>
    public partial class CategoryPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Pages\CategoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cg;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\CategoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cg_Copy;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\CategoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cg_Copy1;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\CategoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cg_Copy2;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\CategoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cg_Copy3;
        
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
            System.Uri resourceLocater = new System.Uri("/Agamotto;component/pages/categorypage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CategoryPage.xaml"
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
            
            #line 29 "..\..\..\Pages\CategoryPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MainClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 32 "..\..\..\Pages\CategoryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cg = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Pages\CategoryPage.xaml"
            this.cg.Click += new System.Windows.RoutedEventHandler(this.SmartClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cg_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Pages\CategoryPage.xaml"
            this.cg_Copy.Click += new System.Windows.RoutedEventHandler(this.SmartClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cg_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Pages\CategoryPage.xaml"
            this.cg_Copy1.Click += new System.Windows.RoutedEventHandler(this.SmartClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cg_Copy2 = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Pages\CategoryPage.xaml"
            this.cg_Copy2.Click += new System.Windows.RoutedEventHandler(this.SmartClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cg_Copy3 = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Pages\CategoryPage.xaml"
            this.cg_Copy3.Click += new System.Windows.RoutedEventHandler(this.SmartClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

