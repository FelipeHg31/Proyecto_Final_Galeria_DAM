using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Galeria_de_Artes.VistaControlador.User_control
{
    /// <summary>
    /// Lógica de interacción para administrar.xaml
    /// </summary>
    public partial class administrar : UserControl
    {
        /// <summary>
        /// Seleccionar accion y arte dado el caso
        /// </summary>
        int sel = 0, selTipo = 0, selArt = 0;
        CRUD datos = new CRUD();    

        public administrar()
        {
            InitializeComponent();
            Tipo.Visibility = Visibility.Collapsed;
            TipoArte.Visibility = Visibility.Collapsed;
            ListVer.Visibility = Visibility.Collapsed;
            Agregar5.Visibility = Visibility.Collapsed;
            Actualizar2.Visibility = Visibility.Collapsed;
            Actualizar3.Visibility = Visibility.Collapsed;
            Volver.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// Metodos de eleccion de accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            sel = 1;
            Tipo.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Collapsed;
            Volver.Visibility = Visibility.Visible;
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            sel = 2;
            Tipo.Visibility= Visibility.Visible;
            Btn.Visibility = Visibility.Collapsed;
            Volver.Visibility = Visibility.Visible;
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            sel = 3;
            Tipo.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Collapsed;
            Volver.Visibility = Visibility.Visible;
        }

       

        private void Ver_Click(object sender, RoutedEventArgs e)
        {
            sel = 4;
            Tipo.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Collapsed;
            Volver.Visibility = Visibility.Visible;
        }

     
        /// <summary>
        /// Metodo para volver y realizar otra accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            sel = 0;
            selArt = 0;
            selTipo = 0;

            txtb2_3.Height = 25;

            Btn.Visibility = Visibility.Visible;
            Tipo.Visibility = Visibility.Collapsed;
            TipoArte.Visibility = Visibility.Collapsed;
            ListVer.Visibility = Visibility.Collapsed;
            Agregar5.Visibility = Visibility.Collapsed;
            Actualizar2.Visibility = Visibility.Collapsed;
            Actualizar3.Visibility = Visibility.Collapsed;
            Volver.Visibility = Visibility.Collapsed;

            rbtnLibros.IsChecked = false;
            rbtnMusica.IsChecked = false;
            rbtnPelis.IsChecked = false;
            rbtnPint.IsChecked = false;

        }

        private void Obras_Click(object sender, RoutedEventArgs e)
        {
            selTipo = 1;

            TipoArte.Visibility = Visibility.Visible;
            Tipo.Visibility = Visibility.Collapsed;
            Volver.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Organiacion de los elementos visuales para realizar acciones en la tabla de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void User_Click(object sender, RoutedEventArgs e)
        {
            selTipo = 2;

            switch(sel)
            {
                case 1:
                    Actualizar2.Visibility = Visibility.Visible;
                    txtb3_2.Visibility = Visibility.Collapsed;
                    txt3_2.Visibility = Visibility.Collapsed;
                    Tipo.Visibility = Visibility.Collapsed;

                    txtb3_1.Text = "Id usuario";
                    break;

                case 2:
                    Actualizar3.Visibility= Visibility.Visible;
                    Tipo.Visibility = Visibility.Collapsed;

                    txtb2_1.Text = "Nombre";
                    txtb2_2.Text = "Contraseña";
                    txtb2_3.Text = "Rol";

                    break;

                case 3:
                    Actualizar3.Visibility = Visibility.Visible;
                    Tipo.Visibility = Visibility.Collapsed;

                    txtb2_1.Text = "Id";
                    txtb2_2.Text = "Contraseña";
                    txtb2_3.Text = "Rol";

                    break;
                case 4:

                    Tipo.Visibility = Visibility.Collapsed;
                    datos.MostrarUsuarios(ListVer);
                    ListVer.Visibility = Visibility.Visible;

                    break;
            }
        }

        /// <summary>
        /// Organiacion de los elementos visuales para realizar acciones en la tabla de Opiniones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Opiniones_Click(object sender, RoutedEventArgs e)
        {
            selTipo = 3;

            switch (sel)
            {
                case 1:
                    Actualizar2.Visibility = Visibility.Visible;
                    Tipo.Visibility = Visibility.Collapsed;

                    txtb3_1.Text = "Id usuario";
                    txtb3_2.Text = "Id Obra";
                    
                    break;

                case 2:
                    Actualizar3.Visibility = Visibility.Visible;
                    Tipo.Visibility = Visibility.Collapsed;

                    txtb2_1.Text = "Id Obra";
                    txtb2_2.Text = "Id Usuario";
                    txtb2_3.Text = "Opinion";


                    break;

                case 3:
                    Actualizar3.Visibility = Visibility.Visible;
                    Tipo.Visibility = Visibility.Collapsed;

                    txtb2_1.Text = "Id Obra";
                    txtb2_2.Text = "Id Usuario";
                    txtb2_3.Text = "Opinion";

                    break;
                case 4:

                    Tipo.Visibility = Visibility.Collapsed;
                    datos.MostrarOpinion(ListVer);
                    ListVer.Visibility = Visibility.Visible;

                    break;
            }
        }


        /// <summary>
        /// Organiacion de los elementos visuales para realizar acciones en la tabla de opiniones de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Op_Us_Click(object sender, RoutedEventArgs e)
        {
            selTipo = 4;

            switch (sel)
            {
                case 1:
                    Actualizar2.Visibility = Visibility.Visible;
                    Tipo.Visibility = Visibility.Collapsed;

                    txtb3_1.Text = "Id usuario";
                    txtb3_2.Text = "Id Obra";

                    break;

                case 2:

                    Agregar5.Visibility = Visibility.Visible;
                    Tipo.Visibility = Visibility.Collapsed;

                    txtb1_1.Text = "Id obra";
                    txtb1_2.Text = "Tipo obra";
                    txtb1_3.Text = "Id Usuario";
                    txtb1_4.Text = "Like o Dislike";

                    txtb1_5.Visibility = Visibility.Collapsed;
                    txt1_5.Visibility = Visibility.Collapsed;



                    break;

                case 3:
                    Agregar5.Visibility = Visibility.Visible;
                    Tipo.Visibility = Visibility.Collapsed;

                    txtb1_1.Text = "Id obra";
                    txtb1_2.Text = "Tipo obra";
                    txtb1_3.Text = "Id Opinion";
                    txtb1_4.Text = "Like o Dislike";

                    txtb1_3.Visibility = Visibility.Collapsed;
                    txt1_3.Visibility = Visibility.Collapsed;
                    txt1_5.Visibility = Visibility.Visible;
                    txtb1_5.Visibility = Visibility.Visible;

                    break;
                case 4:

                    Tipo.Visibility = Visibility.Collapsed;
                    datos.MostrarOpinion_us(ListVer);
                    ListVer.Visibility = Visibility.Visible;

                    break;
            }

        }



        /// <summary>
        /// Organiacion de los elementos visuales para realizar acciones en las tablas de tipos de arte
        /// </summary>

        //Musica
        private void rbtnMusica_Checked(object sender, RoutedEventArgs e)
        {

            selArt = 1;

            try
            {
                switch (sel)
                {
                    case 1:

                        TipoArte.Visibility = Visibility.Collapsed;
                        Actualizar2.Visibility = Visibility.Visible;

                        txtb3_1.Text = "Id";


                        txtb3_2.Visibility = Visibility.Collapsed;
                        txt3_2.Visibility = Visibility.Collapsed;

                        break;


                    case 2:

                        TipoArte.Visibility = Visibility.Collapsed;
                        Actualizar2.Visibility = Visibility.Visible;

                        txtb3_1.Text = "Id Api";
                        txtb3_2.Text = "Nombre";

                        break;
                    case 3:

                        TipoArte.Visibility = Visibility.Collapsed;
                        Actualizar2.Visibility = Visibility.Visible;

                        txtb3_1.Text = "Id Api";
                        txtb3_2.Text = "Id base de datos";

                        break;

                    case 4:

                        TipoArte.Visibility = Visibility.Collapsed;
                        Tipo.Visibility = Visibility.Collapsed;
                        datos.MostrarObras(ListVer, selArt);
                        ListVer.Visibility = Visibility.Visible;

                        break;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, vuelve a intentarlo");
            }

        }

        private void rbtnLibros_Checked(object sender, RoutedEventArgs e)
        {
            selArt = 4;
            TipoArte.Visibility = Visibility.Collapsed;
            try
            {
                switch (sel)
                {
                    case 1:

                        TipoArte.Visibility = Visibility.Collapsed;
                        Actualizar2.Visibility = Visibility.Visible;

                        txtb3_1.Text = "Id";


                        txtb3_2.Visibility = Visibility.Collapsed;
                        txt3_2.Visibility = Visibility.Collapsed;

                        break;


                    case 2:


                        TipoArte.Visibility = Visibility.Collapsed;
                        Actualizar2.Visibility = Visibility.Visible;

                        txtb3_1.Text = "Id Api";
                        txtb3_2.Text = "Nombre";
                        break;

                    case 3:

                        TipoArte.Visibility = Visibility.Collapsed;
                        Actualizar2.Visibility = Visibility.Visible;

                        txtb3_1.Text = "Id Api";
                        txtb3_2.Text = "Id base de datos";

                        break;

                    case 4:

                        TipoArte.Visibility = Visibility.Collapsed;
                        Tipo.Visibility = Visibility.Collapsed;
                        datos.MostrarObras(ListVer, selArt);
                        ListVer.Visibility = Visibility.Visible;

                        break;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, vuelve a intentarlo");
            }
        }

        private void rbtnPelis_Checked(object sender, RoutedEventArgs e)
        {
            selArt = 3;
            TipoArte.Visibility = Visibility.Collapsed;
            try
            {
                switch (sel)
                {
                    case 1:

                       
                        Actualizar2.Visibility = Visibility.Visible;

                        txtb3_1.Text = "Id";

                        txtb3_2.Visibility = Visibility.Collapsed;
                        txt3_2.Visibility = Visibility.Collapsed;

                        break;


                    case 2:

                        Actualizar3.Visibility = Visibility.Visible;
                        TipoArte.Visibility = Visibility.Collapsed;

                        txtb2_1.Text = "Id Api";
                        txtb2_2.Text = "Nombre";
                        txtb2_3.Text = "Genero";


                        break;
                    case 3:

                        Actualizar3.Visibility = Visibility.Visible;
                        TipoArte.Visibility = Visibility.Collapsed;

                        txtb2_1.Text = "Id Api";
                        txtb2_2.Text = "Id base datos";
                        txtb2_3.Text = "Genero";

                        break;

                    case 4:

                        Tipo.Visibility = Visibility.Collapsed;
                        datos.MostrarObras(ListVer, selArt);
                        ListVer.Visibility = Visibility.Visible;

                        break;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, vuelve a intentarlo");
            }
        }

        private void rbtnPint_Checked(object sender, RoutedEventArgs e)
        {
            selArt = 2;
            TipoArte.Visibility = Visibility.Collapsed;
            try
            {
                switch (sel)
                {
                    case 1:

                        TipoArte.Visibility = Visibility.Collapsed;
                        Actualizar2.Visibility = Visibility.Visible;

                        txtb3_1.Text = "Id";

                        txtb3_2.Visibility = Visibility.Collapsed;
                        txt3_2.Visibility = Visibility.Collapsed;

                        break;


                    case 2:

                        Actualizar3.Visibility = Visibility.Visible;
                        TipoArte.Visibility = Visibility.Collapsed;

                        txtb2_1.Text = "Id Api";
                        txtb2_2.Text = "Nombre";
                        txtb2_3.Text = "Genero";


                        break;
                    case 3:

                        Actualizar3.Visibility = Visibility.Visible;
                        TipoArte.Visibility = Visibility.Collapsed;

                        txtb2_1.Text = "Id Api";
                        txtb2_2.Text = "Id base datos";
                        txtb2_3.Text = "Genero";

                        break;

                    case 4:

                        Tipo.Visibility = Visibility.Collapsed;
                        datos.MostrarObras(ListVer, selArt);
                        ListVer.Visibility = Visibility.Visible;

                        break;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, vuelve a intentarlo");
            }
        }




        /// <summary>
        /// Acciones de tipo CRUD que se realizan con los elementos visuales organizados por las diferentes tablas
        /// Para 5 campos, este se usa solo en Agregar y editar opinion de usuario
        /// </summary>

      
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            try{ 
                switch(sel)
                {
                    case 2:

                        datos.NuevaOpinion_us(txt1_1.Text.ToString(), Int32.Parse(txt1_2.Text.ToString()), Int32.Parse(txt1_4.Text.ToString()), Int32.Parse(txt1_5.Text.ToString()));

                        break;
                    case 3:

                        if(txt1_2.Text.ToString() == "")
                        {
                            txt1_2.Text = "0";
                        }

                        if (txt1_4.Text.ToString() == "")
                        {
                            txt1_4.Text = "0";
                        }

                        datos.ActualizarOpinion_us(txt1_1.Text.ToString(), Int32.Parse(txt1_2.Text.ToString()), Int32.Parse(txt1_4.Text.ToString()));

                        

                        break;
                }
            
            }catch(Exception ex){
            
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, vuelve a intentarlo");
            }
                
        }


        /// <summary>
        /// Para tres espacios se usan para usuarios, opiniones, pinturas y peliculas en los procesos de agregar y editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Aceptar2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (selTipo)
                {

                    case 1:

                        switch(selArt)
                        {
                            case 2:

                                switch (sel)
                                {
                                    case 2:

                                        datos.NuevaObra(txt2_2.Text.ToString(), txt2_1.Text.ToString(), selArt, Int32.Parse(txt2_3.Text.ToString()), "");


                                        break;

                                    case 3:

                                        if(txt2_1.Text.ToString() == "")
                                        {
                                            txt2_1.Text = "0";
                                        }
                                         
                                        if(txt2_3.Text.ToString() == "")
                                        {
                                            txt2_3.Text = "0";
                                        }


                                        datos.ActualizarObra(Int32.Parse(txt2_2.Text.ToString()), selArt, Int32.Parse(txt2_3.Text.ToString()), txt2_1.Text.ToString());
                                        
                                        break;
                                }

                                break;

                            case 3:

                                switch (sel)
                                {
                                    case 2:

                                        datos.NuevaObra(txt2_2.Text.ToString(), txt2_1.Text.ToString(), selArt, Int32.Parse(txt2_3.Text.ToString()), "");

                                        break;

                                    case 3:

                                        if (txt2_1.Text.ToString() == "")
                                        {
                                            txt2_1.Text = "0";
                                        }

                                        if (txt2_3.Text.ToString() == "")
                                        {
                                            txt2_3.Text = "0";
                                        }


                                        datos.ActualizarObra(Int32.Parse(txt2_2.Text.ToString()), selArt, Int32.Parse(txt2_3.Text.ToString()), txt2_1.Text.ToString());


                                        break;
                                }

                                break;
                        }

                        break;

                    case 2:

                        switch (sel)
                        {
                            case 2:

                                string rol = txt2_3.Text.ToString();
                                if (rol == "1")
                                {
                                    datos.NuevoUsuario(txt2_1.Text.ToString(), txt2_2.Text.ToString(), 1);
                                }else
                                {
                                    datos.NuevoUsuario(txt2_1.Text.ToString(), txt2_2.Text.ToString(), 2);
                                }

                                                                  

                                break;
                            case 3:

                               
                                string conta;

                                if (txt2_3.Text.ToString() == "")
                                {
                                    txt2_3.Text = "0";
                                }

                                if (txt2_2.Text.ToString() == "")
                                {
                                   conta = "";
                                }
                                else
                                {
                                    conta = txt2_2.Text.ToString();
                                }

                                datos.ActualizarUsuario(Int32.Parse(txt2_1.Text.ToString()), Int32.Parse(txt2_3.Text.ToString()), conta);


                                break;
                        }

                        break;
                    case 3:

                        switch (sel)
                        {
                            case 2:

                                datos.NuevaOpinion(txt2_1.Text.ToString(), Int32.Parse(txt2_2.Text.ToString()), txt2_3.Text.ToString());

                                break;
                            case 3:

                                datos.ActualizarOpinion(txt2_1.Text.ToString(), Int32.Parse(txt2_2.Text.ToString()), txt2_3.Text.ToString());

                                break;
                        }

                        break;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, vuelve a intentarlo");
            }
        }

       

        /// <summary>
        /// Para dos espacios se usa el de usuarios, opiniones, opiniones de usuarios y obras de arte para eliminar , agregar y editar Musica y libros
        /// </summary>
        
        private void Aceptar3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (selTipo)
                {
                    case 1:

                        switch (selArt)
                        {
                            case 1:

                                switch(sel)
                                {
                                    case 1:
                                        datos.EliminarObra(Int32.Parse(txt3_1.Text.ToString()), selArt);
                                        break;

                                    case 2:
                                        datos.NuevaObra(txt3_2.Text.ToString(), txt3_1.Text.ToString(), selArt, 0, "");
                                        break;

                                    case 3:
                                        datos.ActualizarObra(Int32.Parse(txt3_2.Text.ToString()), selArt, 0, txt3_1.Text.ToString());
                                        break;

                                }

                                break;

                            case 2:

                                datos.EliminarObra(Int32.Parse(txt3_1.Text.ToString()), selArt);

                                break;

                            case 3:

                                datos.EliminarObra(Int32.Parse(txt3_1.Text.ToString()), selArt);

                                break;

                            case 4:

                                switch (sel)
                                {
                                    case 1:
                                        datos.EliminarObra(Int32.Parse(txt3_1.Text.ToString()), selArt);
                                        break;

                                    case 2:
                                        datos.NuevaObra(txt3_2.Text.ToString(), txt3_1.Text.ToString(), selArt, 0, "");
                                        break;

                                    case 3:
                                        datos.ActualizarObra(Int32.Parse(txt3_2.Text.ToString()), selArt, 0, txt3_1.Text.ToString());
                                        break;

                                }

                                break;
                        }

                        break;

                    case 2:

                        datos.EliminarUsuario(Int32.Parse(txt3_1.Text.ToString()));

                        break;
                    case 3:

                        datos.EliminarOpinion(Int32.Parse(txt3_1.Text.ToString()), txt3_2.Text.ToString());

                        break;

                    case 4:

                        datos.EliminarOpinion_us(Int32.Parse(txt3_1.Text.ToString()), txt3_2.Text.ToString());

                        break;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, vuelve a intentarlo");
            }
        }


       

    }
}
