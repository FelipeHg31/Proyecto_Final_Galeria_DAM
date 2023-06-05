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
using Galeria_de_Artes.Modelo.Clases;

namespace Galeria_de_Artes.VistaControlador.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Page
    {
        InicioSesion init = new InicioSesion();
        public Principal()
        {
            InitializeComponent();

        }

        private void Prins_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();

            us.Text = UsuarioIngresado.nombre;

            if (UsuarioIngresado.tipo == 2)
            {
                Admin.Visibility = Visibility.Collapsed;
            }
            

        }

        /// <summary>
        /// Cambio de tamaño de las imagenes 
        /// </summary>

        private void BotonPelis_MouseEnter(object sender, MouseEventArgs e)
        {
            Peliculas.Width = 400;
            Peliculas.Height = 350;
            BotonPelis.Width = 400;
            BotonPelis.Height = 350;
            Panel.SetZIndex(BotonPelis, 2);
        }
        private void BotonPelis_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Peliculas.Width = 240;
            Peliculas.Height = 180;
            BotonPelis.Width = 240;
            BotonPelis.Height = 180;
            Panel.SetZIndex(BotonPelis, 1);
        }

        private void BotonLibros_MouseEnter(object sender, MouseEventArgs e)
        {
            BotonLibros.Width = 425;
            BotonLibros.Height = 280;
            Libros.Width = 455;
            Libros.Height = 289;
            Panel.SetZIndex(BotonLibros, 2);
        }

        private void BotonLibros_MouseLeave(object sender, MouseEventArgs e)
        {
            BotonLibros.Width = 275;
            BotonLibros.Height = 150;
            Libros.Width = 275;
            Libros.Height = 150;
            Panel.SetZIndex(BotonLibros, 1);
        }

        private void BotonMusica_MouseEnter(object sender, MouseEventArgs e)
        {
            BotonMusica.Width = 400;
            BotonMusica.Height = 310;
            Musica.Width = 350;
            Musica.Height = 300;
            Panel.SetZIndex(BotonMusica, 2);
        }

        private void BotonMusica_MouseLeave(object sender, MouseEventArgs e)
        {
            BotonMusica.Width = 250;
            BotonMusica.Height = 160;
            Musica.Width = 200;
            Musica.Height = 150;
            Panel.SetZIndex(BotonMusica, 1);
        }

        private void MousePintura(object sender, MouseEventArgs e)
        {
            Pinturas.Width = 390;
            Pinturas.Height = 260;
            BotonPinturas.Width = 350;
            BotonPinturas.Height = 270;
            Panel.SetZIndex(BotonPinturas, 2);
        }

        private void BotonPinturas_MouseLeave(object sender, MouseEventArgs e)
        {
            Pinturas.Width = 260;
            Pinturas.Height = 150;
            BotonPinturas.Width = 250;
            BotonPinturas.Height = 160;
            Panel.SetZIndex(BotonPinturas, 1);
        }

        /// <summary>
        /// Accion de los botones
        /// </summary>

        private void BotonPelis_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Peliculas());
        }
        private void BotonPinturas_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pinturas());
        }

        private void BotonMusica_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Musica());
        }

        private void BotonLibros_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new libros());
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InicioSesion());
        }

        private void Mi_Galeria_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Mi_galeria());
        }

        private void Pregunta_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pregunta()); 
        }
    }
}
