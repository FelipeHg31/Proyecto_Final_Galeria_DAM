using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using Galeria_de_Artes.Modelo.Apis;
using Galeria_de_Artes.Modelo.Bases_Datos;
using Galeria_de_Artes.Modelo.Clases;
using static System.Net.Mime.MediaTypeNames;

namespace Galeria_de_Artes.VistaControlador.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Mi_galeria.xaml
    /// </summary>
    public partial class Mi_galeria : Page
    {
        CRUD datos = new CRUD();
        int tipoArte, indice;

        JsonDocument busqTitM, busqTitPel, busqTitPin, busqTitL;
        ApiMusica apiM = new ApiMusica();
        ApiChicago apiPint = new ApiChicago();
        ApiCine apiCine = new ApiCine();
        ApiLibros apiL = new ApiLibros();

        char tope = '.';
        string titulo, tit, dir;
        Metodos Met = new Metodos();

       
        public Mi_galeria()
        {
            InitializeComponent();

            apiM.BusquedaTitulo("");

            apiPint.BusqImgs(0);

            Musica.LoadedBehavior = MediaState.Manual;

            RepMusica.Visibility = Visibility.Collapsed;
            Imagen.Visibility = Visibility.Collapsed;
            Nombre.Visibility = Visibility.Collapsed;
            NombreEnun.Visibility = Visibility.Collapsed;
        }

        private void Pregunta_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pregunta());
        }

        /// <summary>
        /// Metodos de seleccion de los elementos del radio buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void rbtnMusica_Checked(object sender, RoutedEventArgs e)
        {
            Musica.Pause();
            Imagen.Source = new BitmapImage();
            datos.MostrarObras(Nombre, 1);

            Nombre.Visibility = Visibility.Visible;
            NombreEnun.Visibility = Visibility.Visible;
            RepMusica.Visibility = Visibility.Visible;
            Imagen.Visibility = Visibility.Collapsed;

            tipoArte = 1;
        }

        private void rbtnPelis_Checked(object sender, RoutedEventArgs e)
        {
            Musica.Pause();
            Imagen.Source = new BitmapImage();
            datos.MostrarObras(Nombre, 3);

            Nombre.Visibility = Visibility.Visible;
            NombreEnun.Visibility = Visibility.Visible;
            RepMusica.Visibility = Visibility.Collapsed;
            Imagen.Visibility = Visibility.Visible;

            tipoArte = 3;
        }

        private void rbtnPint_Checked(object sender, RoutedEventArgs e)
        {
            Musica.Pause();
            Imagen.Source = new BitmapImage();
            datos.MostrarObras(Nombre, 2);

            Nombre.Visibility = Visibility.Visible;
            NombreEnun.Visibility = Visibility.Visible;
            RepMusica.Visibility = Visibility.Collapsed;
            Imagen.Visibility = Visibility.Visible;

            tipoArte = 2;
        }

        private void rbtnLibros_Checked(object sender, RoutedEventArgs e)
        {
            Musica.Pause();
            Imagen.Source = new BitmapImage();
            datos.MostrarObras(Nombre, 4);
            Nombre.Visibility = Visibility.Visible;
            NombreEnun.Visibility = Visibility.Visible;
            RepMusica.Visibility = Visibility.Collapsed;

            tipoArte = 4;
        }

        /// <summary>
        /// Seleccion de la obra y realza la accion de mostrar la media de la obra
        /// </summary>
                
        private void Nombre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int idB = 0;
            string media = "";

            switch (tipoArte)
            {
                case 1:
                    
                    if(Nombre.Items.Count > 0)
                    {
                        titulo = Nombre.SelectedValue.ToString();

                        indice = titulo.IndexOf(tope);

                        idB = Int32.Parse(titulo.Substring(0, indice));

                        media = datos.ObtMedia(idB, tipoArte);

                        Musica.Source = new Uri(media, UriKind.Absolute);
                    }
                    
                    break;

                case 2:

                    if (Nombre.Items.Count > 0)
                    {
                        titulo = Nombre.SelectedValue.ToString();

                        indice = titulo.IndexOf(tope);

                        idB = Int32.Parse(titulo.Substring(0, indice));

                        media = datos.ObtMedia(idB, tipoArte);

                        Imagen.Source = new BitmapImage(new Uri("https://www.artic.edu/iiif/2/" + media + "/full/843,/0/default.jpg"));
                    }
                        

                    break;

                case 3:

                    if (Nombre.Items.Count > 0)
                    {
                        titulo = Nombre.SelectedValue.ToString();

                        indice = titulo.IndexOf(tope);

                        idB = Int32.Parse(titulo.Substring(0, indice));

                        media = datos.ObtMedia(idB, tipoArte);

                        Imagen.Source = new BitmapImage(new Uri("https://image.tmdb.org/t/p/w500/" + media));
                    }              


                    break;

                case 4:

                    if (Nombre.Items.Count > 0)
                    {

                        Imagen.Source = new BitmapImage(new Uri("/Resources/libro2.jpg", UriKind.Relative));

                    }

                    break;
            }
        }

        /// <summary>
        /// Botones de accion de la musica
        /// </summary>
        
        private void Pausa_Click(object sender, RoutedEventArgs e)
        {
            Musica.Stop();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            Musica.Play();
        }
    }
}
