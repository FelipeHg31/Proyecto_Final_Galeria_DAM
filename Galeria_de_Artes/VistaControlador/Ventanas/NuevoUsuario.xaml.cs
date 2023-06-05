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

namespace Galeria_de_Artes.VistaControlador.Ventanas
{
    /// <summary>
    /// Lógica de interacción para NuevoUsuario.xaml
    /// </summary>
    public partial class NuevoUsuario : Page
    {
        CRUD datos = new CRUD();
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void Comprobar_Click(object sender, RoutedEventArgs e)
        {
            if ((usua.Text != "") && (Cont.Text != ""))
            {
                try
                {
                    datos.NuevoUsuario(usua.Text.ToString(), Cont.Text.ToString(), 2);
                    NavigationService.GoBack();
                }
                catch(Exception ex)
                {
                   
                    MessageBox.Show("Error de ingreso de datos");
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingresa datos en los espacios");
            }
        }
    }
}
