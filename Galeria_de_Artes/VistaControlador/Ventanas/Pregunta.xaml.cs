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
    /// Lógica de interacción para Pregunta.xaml
    /// </summary>
    public partial class Pregunta : Page
    {
        int preg = 0;
        public Pregunta()
        {
            InitializeComponent();
        }

        private void Como_arte_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PregGalerias(1));
        }

        private void Como_MiGaleria_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PregGalerias(2));
        }

        private void Como_Bot_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PregGalerias(3));
        }

    }
}
