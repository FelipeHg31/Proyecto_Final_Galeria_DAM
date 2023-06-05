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

namespace Galeria_de_Artes.VistaControlador.User_control
{
    /// <summary>
    /// Lógica de interacción para Opiniones.xaml
    /// </summary>
    public partial class Megustan : UserControl
    {
        CRUD datos = new CRUD();

        public Megustan()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Metodo que muestra las obras que le gustan al usuario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gusta_MouseEnter(object sender, MouseEventArgs e)
        {
            datos.ObtObrasLikes(UsuarioIngresado.id, gusta);
        }
    }
}
