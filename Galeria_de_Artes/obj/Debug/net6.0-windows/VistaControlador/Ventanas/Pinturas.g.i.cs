﻿#pragma checksum "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B23D930E5545591D475D6AA7F1C0CB2855E4B5A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Galeria_de_Artes.VistaControlador.Ventanas;
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


namespace Galeria_de_Artes.VistaControlador.Ventanas {
    
    
    /// <summary>
    /// Pinturas
    /// </summary>
    public partial class Pinturas : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox titulos;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Autor;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox opinion;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button gusta;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button No_Gusta;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Busq;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button opi;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Pintura;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Galeria_de_Artes;component/vistacontrolador/ventanas/pinturas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.titulos = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.titulos.MouseEnter += new System.Windows.Input.MouseEventHandler(this.titulos_MouseEnter);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.titulos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.titulos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Autor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.Autor.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Director_MouseEnter);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.Autor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Autor_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.opinion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.gusta = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.gusta.Click += new System.Windows.RoutedEventHandler(this.gusta_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.No_Gusta = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.No_Gusta.Click += new System.Windows.RoutedEventHandler(this.No_Gusta_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Busq = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.Busq.Click += new System.Windows.RoutedEventHandler(this.Busq_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.opi = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.opi.Click += new System.Windows.RoutedEventHandler(this.opi_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Pintura = ((System.Windows.Controls.Image)(target));
            
            #line 32 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.Pintura.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Pintura_MouseEnter);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\..\VistaControlador\Ventanas\Pinturas.xaml"
            this.Pintura.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Pintura_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
