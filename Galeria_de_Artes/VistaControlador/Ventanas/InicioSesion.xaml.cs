using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Galeria_de_Artes.Modelo.Bases_Datos;
using Galeria_de_Artes.Modelo.Clases;

namespace Galeria_de_Artes.VistaControlador.Ventanas
{
    /// <summary>
    /// Lógica de interacción para InicioSesion.xaml
    /// </summary>
    public partial class InicioSesion : Page
    {
        int tipo, id;
        CRUD datos = new CRUD();
        private bool isLoggedIn = false;

        public InicioSesion()
        {
            InitializeComponent();
        }

        private void Comprobar_Click(object sender, RoutedEventArgs e)
        {
            if((usua.Text != "") && (Cont.Password != ""))
            {
                switch(datos.IniciarSesion(usua.Text.ToString(), Cont.Password.ToString()))
                {
                    case 1:
                        isLoggedIn = true;
                        tipo = 1;
                        NavigationService.Navigate(new Principal());
                        break;
                    case 2:
                        isLoggedIn = true;
                        tipo = 2;
                        NavigationService.Navigate(new Principal());
                        break;
                    default:
                        MessageBox.Show("Error de inicio");
                        break;
                }

            }
        }

       
        

        private void Sesiones_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NuevoUsuario());
        }
    }
}
