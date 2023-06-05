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

namespace Galeria_de_Artes.VistaControlador.Ventanas
{
    /// <summary>
    /// Lógica de interacción para PregGalerias.xaml
    /// </summary>
    public partial class PregGalerias : Page
    {
        int preg;
        public PregGalerias( int desc)
        {
            InitializeComponent();

            preg = desc;

            switch(preg)
            {
                case 1:
                    Titulo.Text = "Botones de arte";
                    textos.Visibility = Visibility.Collapsed;
                    btn.Visibility = Visibility.Visible;
                    break;

                case 2:
                    Titulo.Text = "Mi galeria";
                    textos.Visibility = Visibility.Visible;
                    btn.Visibility = Visibility.Collapsed;

                    Texto_Ayuda.Text = "Se tendran como opciones los diferentes tipos de arte y segun sean seleccionados se mostraran las obras seleccionadas por el usuario y cuando se seleccione una se mostrar el elmento de media que corresponda. Por otro lado, abra un una ventana que mostrara las obras en las que el usuario dio like con su nombre, id y tipo";

                    break;
                    
                case 3:
                    Titulo.Text = "Galeria de arte";
                    textos.Visibility = Visibility.Visible;
                    btn.Visibility = Visibility.Collapsed;

                    Texto_Ayuda.Text = "Se tendran como opciones principales los botones que referencian a un tipo de arte segun se seleccione uno este va a rediriguir a las diferentes ventanas.";

                    break;
                     
            }
        }

        /// <summary>
        /// Metodos de accion de botonces, se usaran para cambiar el textblock presente y dar una explicacion sobre las interfaces de cada tipo de arte
        /// </summary>
        
        private void Musica_Click(object sender, RoutedEventArgs e)
        {
            textos.Visibility = Visibility.Visible;
            btn.Visibility = Visibility.Collapsed;

            Texto_Ayuda.Text = "MUSICA: \n Se puede buscar por artistas, albumes o titulos ya sean los recomendados o escrbiendolos en las cajas de texto al frente de cada titulo, las busquedas se realizaran cuando se cambie de seleccion en los cuadros de opciones o cuando se escriban y se de click en el boton de busqueda. Por otro lado, cuando se seleccione un titulo si existe la cancion sonaran los primeros segundos de esta y para guardar la informacion colocada en los diferentes campos se da al boton de guardar.";

            volver.Visibility = Visibility.Visible; 
        }

        private void Pinturas_Click(object sender, RoutedEventArgs e)
        {
            textos.Visibility = Visibility.Visible;
            btn.Visibility = Visibility.Collapsed;

            Texto_Ayuda.Text = "PINTURAS: \n Se puede buscar por artistas o nombre de la obra de los titulos disponibles, las busquedas se realizaran cuando se cambie de seleccion en los cuadros de opciones. Por otro lado, cuando se seleccione un titulo si existe la pintura esta se mostrara y para guardar la informacion colocada en los diferentes campos se le da al boton de guardar.";
            
            volver.Visibility = Visibility.Visible;
        }

        private void Peliculas_Click(object sender, RoutedEventArgs e)
        {
            textos.Visibility = Visibility.Visible;
            btn.Visibility = Visibility.Collapsed;

            Texto_Ayuda.Text = "PELICULAS: \n Se puede buscar por el nombre de la obra de los titulos disponibles, las busquedas se realizaran cuando se cambie de seleccion en los cuadros de opciones. Por otro lado, cuando se seleccione un titulo si existe la imagen de la cartelera de la pelicula esta se mostrara como los actores y directores de esta y para guardar la informacion colocada en los diferentes campos se le da al boton de guardar.";

            volver.Visibility = Visibility.Visible;
        }

        private void Libros_Click(object sender, RoutedEventArgs e)
        {
            textos.Visibility = Visibility.Visible;
            btn.Visibility = Visibility.Collapsed;

            Texto_Ayuda.Text = "LIBROS: \n Se puede buscar por artistas o nombre de la obra de los titulos disponibles. Por otro lado, cuando se seleccione un titulo si existe la imagen de la cartelera de la pelicula esta se mostrara como los actores y directores de esta y para guardar la informacion colocada en los diferentes campos se le da al boton de guardar.";

            volver.Visibility = Visibility.Visible;
        }

        private void volver_Click(object sender, RoutedEventArgs e)
        {
            textos.Visibility = Visibility.Collapsed;
            btn.Visibility = Visibility.Visible;
        }
    }
}
