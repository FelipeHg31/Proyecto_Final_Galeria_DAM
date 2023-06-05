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

namespace Galeria_de_Artes.VistaControlador.Ventanas
{
    /// <summary>
    /// Lógica de interacción para libros.xaml
    /// </summary>
    public partial class libros : Page
    {
        ApiLibros api = new ApiLibros();
        JsonDocument libr, aut, busqAut, busqTit;
        int selec = -1;
        int likeODis = 0;
        CRUD datos = new CRUD();
        int TipoArte;

        public libros()
        {
            InitializeComponent();
            api.Libro();
            api.Autore();
            api.BusquedaAutor("");
            
            TipoArte = 4;
        }

        /// <summary>
        /// Metodos de obtencion de datos de las apis
        /// </summary>
        
        private void titulos_MouseEnter(object sender, MouseEventArgs e)
        {
            api.Libro();
            libr = api.ObtenerLibro();

            if (titulos.Items.Count < 1)
            {
                titulos.ToolTip = "Por favor esperar la carga de los datos";
                if (libr != null)
                {
                    
                    int Cant = libr.RootElement.GetProperty("works").GetArrayLength();

                    for (int i = 0; i < Cant; i++)
                    {
                        titulos.Items.Add(libr.RootElement.GetProperty("works")[i].GetProperty("title").ToString());
                    }

                    selec = 0;
                }
            }
            else
            {
                titulos.ToolTip = "Selecciona un titulo";
            }

        }

        private void autores_MouseEnter(object sender, MouseEventArgs e)
        {
            api.Autore();
            aut = api.ObtenerAutor();

            if (autores.Items.Count < 1)
            {
                autores.ToolTip = "Por favor esperar la carga de los datos";

                if (aut != null)
                {
                    int Cant = aut.RootElement.GetProperty("works").GetArrayLength();

                    for (int i = 0; i < Cant; i++)
                    {
                        autores.Items.Add(aut.RootElement.GetProperty("works")[i].GetProperty("authors")[0].GetProperty("name").ToString());
                    }
                }
            }
            else
            {
                autores.ToolTip = "Selecciona un autor";
            }
        }


        
        /// <summary>
        /// Interacciones del usuario
        /// </summary>
        
        //Seleccion de autor
        private void autores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autores.Items.Count > 0)
            {
                int pos = autores.SelectedIndex;

                string Autores = aut.RootElement.GetProperty("works")[pos].GetProperty("authors")[0].GetProperty("name").ToString();

                api.BusquedaAutor(Autores);

                busqAut = api.ObtenerBusqAut();

                if (busqAut != null)
                {

                    titulos.Items.Clear();

                    int Cant = busqAut.RootElement.GetProperty("docs").GetArrayLength();

                    for (int i = 0; i < Cant; i++)
                    {
                        titulos.Items.Add(busqAut.RootElement.GetProperty("docs")[i].GetProperty("title").ToString());
                    }
                    selec = 1;
                }

            }
        }



        /// <summary>
        /// Acciones con los botones
        /// </summary>

        //Busqueda por ingreso de datos en los textbox

        private void buscar_Click(object sender, RoutedEventArgs e)
        {
            if ((txtAut.Text != "") && (txtTit.Text != ""))
            {
                MessageBox.Show("Por favor quita uno de los campos escritos para realizar la busqueda");
            }
            else
            {
                if (txtTit.Text != "")
                {
                    api.BusquedaTit(txtTit.Text);

                    busqTit = api.ObtenerBusqTit();

                    if (busqTit != null)
                    {
                        titulos.Items.Clear();
                        autores.Items.Clear();

                        int Cant = busqTit.RootElement.GetProperty("docs").GetArrayLength();


                        for (int i = 0; i < Cant; i++)
                        {
                            titulos.Items.Add(busqTit.RootElement.GetProperty("docs")[i].GetProperty("title").ToString());
                        }

                        selec = 2;
                    }

                }
                else if (txtAut != null)
                {
                    api.BusquedaAutor(txtAut.Text);

                    busqAut = api.ObtenerBusqAut();

                    if (busqAut != null)
                    {
                        titulos.Items.Clear();
                        autores.Items.Clear();

                        int Cant = busqAut.RootElement.GetProperty("docs").GetArrayLength();

                        for (int i = 0; i < Cant; i++)
                        {
                            titulos.Items.Add(busqAut.RootElement.GetProperty("docs")[i].GetProperty("title").ToString());

                        }
                        autores.Items.Add(busqAut.RootElement.GetProperty("docs")[0].GetProperty("author_name").ToString());

                        selec = 1;
                    }
                }
            }

        }

       //Boton de nueva busqueda

        private void Busq_Click(object sender, RoutedEventArgs e)
        {
            txtAut.Text = "";
            txtPal.Text = "";
            txtTit.Text = "";
            opinion.Text = "";

            titulos.Items.Clear();
            autores.Items.Clear();

            gusta.Background = Brushes.Black;
            No_Gusta.Background = Brushes.Black;
            opinion.Text = "";
        }

        
        /// <summary>
        /// Boton que guarda los datos en la base de datos
        /// </summary>
       
        private void opi_Click(object sender, RoutedEventArgs e)
        {
            string idApi = "";
            string lib = "";
            string op = "";
            int idUS = UsuarioIngresado.id;

            switch (selec)
            {
                case 0:
                    idApi =libr.RootElement.GetProperty("works")[titulos.SelectedIndex].GetProperty("key").ToString();
                    lib = libr.RootElement.GetProperty("works")[titulos.SelectedIndex].GetProperty("title").ToString();

                    break;

                case 1:
                    idApi = busqAut.RootElement.GetProperty("docs")[titulos.SelectedIndex].GetProperty("key").ToString();
                    lib = busqAut.RootElement.GetProperty("docs")[titulos.SelectedIndex].GetProperty("title").ToString();
                    break;

                case 2:
                    idApi = busqTit.RootElement.GetProperty("docs")[titulos.SelectedIndex].GetProperty("key").ToString();
                    lib = busqTit.RootElement.GetProperty("docs")[titulos.SelectedIndex].GetProperty("title").ToString();
                    break;


            }
            if (opinion.Text != "")
            {
                op = opinion.Text.ToString();
            }
            else
            {
                op = "";
            }

            IngresoDatos(idApi, lib, op, idUS);

            Libros l = new Libros(idApi, lib, op);

            MessageBox.Show(l.ToString());
        }

        private void gusta_Click(object sender, RoutedEventArgs e)
        {
            likeODis = 1;
            gusta.Background = Brushes.DarkGreen;
            No_Gusta.Background = Brushes.Black;

        }

        private void No_Gusta_Click(object sender, RoutedEventArgs e)
        {
            likeODis = -1;
            gusta.Background = Brushes.Black;
            No_Gusta.Background = Brushes.DarkRed;
        }


        /// <summary>
        /// Metodo que ingresa las interacciones realizadas por el usuario en la aplicacion.
        /// </summary>
        /// <param name="idApi"></param>
        /// <param name="libr"></param>
        /// <param name="opi"></param>
        /// <param name="idUs"></param>
        /// <returns></returns>

        public async Task IngresoDatos(string idApi, string libr, string opi, int idUs)
        {
            int hayObra = 0, hayOpi = 0, hayOpiUs = 0, hayLike = 0;
            string opin = "";

            await Task.Run(() =>
            {
                hayObra = datos.BuscarObras(idApi, TipoArte);
            });

            if (hayObra == 0)
            {
                datos.NuevaObra(libr, idApi, TipoArte, 0, "");

                await Task.Run(() =>
                {
                    datos.NuevaOpinion(idApi, idUs, opi);
                });

                await Task.Run(() =>
                {
                    if (likeODis == 1)
                    {
                        datos.NuevoOpinionApp(idApi, 0, likeODis);
                    }
                    else if (likeODis == -1)
                    {
                        datos.NuevoOpinionApp(idApi, likeODis, 0);
                    }
                });

                await Task.Run(() =>
                {
                    datos.NuevaOpinion_us(idApi, TipoArte, idUs, likeODis);
                });
                MessageBox.Show("Nueva obra guardada");

            }
            else
            {
                await Task.Run(() =>
                {
                    hayOpi = datos.BuscarOpiniones(idApi, idUs);
                });

                if (hayOpi == 0)
                {
                    await Task.Run(() =>
                    {
                        datos.NuevaOpinion(idApi, idUs, opi);
                    });

                }
                else
                {
                    if (opi != "")
                    {
                        await Task.Run(() =>
                        {
                            opin = datos.ObtOpinion(idApi, idUs);
                        });
                        if (opi != opin)
                        {
                            await Task.Run(() =>
                            {
                                datos.ActualizarOpinion(idApi, idUs, opi);
                            });

                        }
                    }
                }

                await Task.Run(() =>
                {
                    hayOpiUs = datos.BuscarOpinion_Us(idApi, idUs);
                });

                if (hayOpiUs == 0)
                {
                    await Task.Run(() =>
                    {
                        datos.NuevaOpinion_us(idApi, TipoArte, idUs, likeODis);
                    });

                }

                await Task.Run(() =>
                {
                    hayLike = datos.ObtLikes(idApi, idUs);
                });

                if (hayLike != likeODis)
                {
                    await Task.Run(() =>
                    {
                        datos.ActualizarOpinion_us(idApi, idUs, likeODis);
                    });
                }
            }
        }
    }
}
