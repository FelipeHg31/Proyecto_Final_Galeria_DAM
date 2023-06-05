using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Threading.Tasks;
using System.Threading;
using Galeria_de_Artes.Modelo.Apis;
using Galeria_de_Artes.Modelo.Bases_Datos;
using Galeria_de_Artes.Modelo.Clases;
using System.IO.Packaging;

namespace Galeria_de_Artes.VistaControlador.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Peliculas.xaml
    /// </summary>
    public partial class Peliculas : Page
    {
        ApiCine api = new ApiCine();
        JsonDocument peli, personal, gen, pal_clv;
        int selec = -1;
        int likeODis = 0;
        InicioSesion init = new InicioSesion();
        CRUD datos = new CRUD();
        int TipoArte;

        public Peliculas()
        {
            InitializeComponent();
            api.Pelicula(1);
            TipoArte = 3;

        }

        /// <summary>
        /// Metodos de obtencion de datos de las apis
        /// </summary>

        private void Genero_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Genero.Items.Count < 1)
            {
                Genero.ToolTip = "Por favor esperar la carga de los datos";

                api.Genero();

                gen = api.ObtenerGenero();

                if (gen != null)
                {
                    int Cant = gen.RootElement.GetProperty("genres").GetArrayLength();

                    for (int j = 0; j < Cant; j++)
                    {
                        Genero.Items.Add(gen.RootElement.GetProperty("genres")[j].GetProperty("name").ToString());
                    }
                }


            }
            else
            {
                Genero.ToolTip = "Selecciona un genero";
            }
        }

        private void titulos_MouseEnter(object sender, MouseEventArgs e)
        {
            if (titulos.Items.Count < 1)
            {
                titulos.ToolTip = "Por favor esperar la carga de los datos";

                for (int i = 1; i < 6; i++)
                {
                    if (i != 1) { api.Pelicula(i); }

                    peli = api.ObtenerPelicula();

                    if (peli != null)
                    {
                        int Cant = peli.RootElement.GetProperty("results").GetArrayLength();

                        for (int j = 0; j < Cant; j++)
                        {
                            titulos.Items.Add(peli.RootElement.GetProperty("results")[j].GetProperty("original_title").ToString());
                        }

                        selec = 0;
                    }

                }
            }
            else
            {
                titulos.ToolTip = "Selecciona una pelicula";
            }

        }


        /// <summary>
        /// Acciones del seleccionar un elemento de los combobox
        /// </summary>


        private void titulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idImag = "";
            int id = 0;
            try
            {
                if (titulos.SelectedIndex != -1)
                {

                    if (selec == 0)
                    {
                        id = Int32.Parse(peli.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("id").ToString());
                        idImag = peli.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("poster_path").ToString();
                    }
                    else if (selec == 1)
                    {
                        id = Int32.Parse(pal_clv.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("id").ToString());
                        idImag = pal_clv.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("poster_path").ToString();
                    }

                    api.Personal(id);

                    personal = api.ObtenerPersonal();

                    if (personal != null)
                    {
                       
                        int Cant = personal.RootElement.GetProperty("cast").GetArrayLength();

                        Actores.Items.Clear();
                        Director.Items.Clear();

                        for (int j = 0; j < Cant; j++)
                        {

                            if (personal.RootElement.GetProperty("cast")[j].GetProperty("known_for_department").ToString() == "Acting")
                            {
                                Actores.Items.Add(personal.RootElement.GetProperty("cast")[j].GetProperty("name").ToString());
                            }
                            else
                            if (personal.RootElement.GetProperty("cast")[j].GetProperty("known_for_department").ToString() == "Directing")
                            {
                                Director.Items.Add(personal.RootElement.GetProperty("cast")[j].GetProperty("name").ToString());
                            }
                        }


                        Peli.Source = new BitmapImage(new Uri("https://image.tmdb.org/t/p/w500/" + idImag));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cambia de seleccion porfavor");
                titulos.SelectedIndex = 0;
            }

        }


        /// <summary>
        /// Acciones de los botones
        /// Busqueda por ingreso de datos en los textbox
        /// </summary>
   
        private void Busqueda_Click(object sender, RoutedEventArgs e)
        {
            if (pal_calve.Text != "")
            {
                api.PalabraClave(pal_calve.Text.ToString());
                pal_clv = api.ObtenerPalabraClave();

                if (pal_clv != null)
                {
                    int Cant = pal_clv.RootElement.GetProperty("results").GetArrayLength();

                    titulos.Items.Clear();

                    for (int j = 0; j < Cant; j++)
                    {
                        titulos.Items.Add(pal_clv.RootElement.GetProperty("results")[j].GetProperty("original_title").ToString());
                    }

                    selec = 1;

                }
            }
            else
            {
                MessageBox.Show("Ingresa un valor en el campo de palabras clave");
            }
        }

        /// <summary>
        /// Boton que guarda los datos en la base de datos
        /// </summary>

        private void opi_Click(object sender, RoutedEventArgs e)
        {
            string idPeliApi = "";
            string Pelis = "";
            string opi = "";
            int genero = 0;
            int idUs = UsuarioIngresado.id;
            string media = "";

            if (selec == 0)
            {
                idPeliApi = peli.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("id").ToString();
                Pelis = peli.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("original_title").ToString();
                genero = Int32.Parse(peli.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("genre_ids")[0].ToString());
                media = peli.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("poster_path").ToString();

            }
            else if (selec == 1)
            {
                idPeliApi = pal_clv.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("id").ToString();
                Pelis = pal_clv.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("original_title").ToString();
                genero = Int32.Parse(pal_clv.RootElement.GetProperty("results")[titulos.SelectedIndex - 1].GetProperty("genre_ids")[0].ToString());
                media = pal_clv.RootElement.GetProperty("results")[titulos.SelectedIndex].GetProperty("poster_path").ToString();
            }


            if (opinion.Text != "")
            {
                opi = opinion.Text.ToString();
            }
            else
            {
                opi = "";
            }

            IngresoDatos(idPeliApi, Pelis, genero, opi, idUs, media);

            Pelicula pelicul = new Pelicula(idPeliApi, Pelis, opi, genero);

            MessageBox.Show(pelicul.ToString());
        }


        /// <summary>
        /// Boton de nueva busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Busq_Click(object sender, RoutedEventArgs e)
        {
            titulos.Items.Clear();
            Actores.Items.Clear();
            opinion.Text = "";
            pal_calve.Text = "";
            Peli.Source = new BitmapImage();
            gusta.Background = Brushes.Black;
            No_Gusta.Background = Brushes.Black;
            opinion.Text = "";
        }

        private void No_Gusta_Click(object sender, RoutedEventArgs e)
        {
            likeODis = -1;
            gusta.Background = Brushes.Black;
            No_Gusta.Background = Brushes.DarkRed;
        }

        private void gusta_Click(object sender, RoutedEventArgs e)
        {
            likeODis = 1;
            gusta.Background = Brushes.DarkGreen;
            No_Gusta.Background = Brushes.Black;
        }


        

        private void Peli_MouseEnter(object sender, MouseEventArgs e)
        {
            Peli.Width = 400;
            Peli.Height = 400;
        }

        private void Peli_MouseLeave(object sender, MouseEventArgs e)
        {
            Peli.Width = 150;
            Peli.Height = 150;
        }


        /// <summary>
        /// Metodo que ingresa las interacciones realizadas por el usuario en la aplicacion.
        /// </summary>
        /// <param name="idPeliApi"></param>
        /// <param name="Pelis"></param>
        /// <param name="genero"></param>
        /// <param name="opi"></param>
        /// <param name="idUs"></param>
        /// <param name="media"></param>
        /// <returns></returns>

        public async Task IngresoDatos(string idPeliApi, string Pelis, int genero, string opi, int idUs, string media)
        {
            int hayObra = 0, hayOpi = 0, hayOpiUs = 0, hayLike = 0;
            string opin = "";

            await Task.Run(() =>
            {
                hayObra = datos.BuscarObras(idPeliApi, TipoArte);
            });

            if (hayObra == 0)
            {
                datos.NuevaObra(Pelis, idPeliApi, TipoArte, genero, media);
                await Task.Run(() =>
                {
                    datos.NuevaOpinion(idPeliApi, idUs, opi);
                });

                await Task.Run(() =>
                {
                    if (likeODis == 1)
                    {
                        datos.NuevoOpinionApp(idPeliApi, 0, likeODis);
                    }
                    if (likeODis == -1)
                    {
                        datos.NuevoOpinionApp(idPeliApi, likeODis, 0);
                    }
                });

                await Task.Run(() =>
                {
                    datos.NuevaOpinion_us(idPeliApi, TipoArte, idUs, likeODis);
                });
                MessageBox.Show("Nueva obra guardada");
            }
            else
            {
                await Task.Run(() =>
                {
                    hayOpi = datos.BuscarOpiniones(idPeliApi, idUs);
                });

                if (hayOpi == 0)
                {
                    await Task.Run(() =>
                    {
                        datos.NuevaOpinion(idPeliApi, idUs, opi);
                    });
                   
                }
                else
                {
                    if (opi != "")
                    {
                        await Task.Run(() =>
                        {
                            opin = datos.ObtOpinion(idPeliApi, idUs);
                        });
                        if (opi != opin)
                        {
                            await Task.Run(() =>
                            {
                                datos.ActualizarOpinion(idPeliApi, idUs, opi);
                            });

                        }
                    }
                }

                await Task.Run(() =>
                {
                    hayOpiUs = datos.BuscarOpinion_Us(idPeliApi, idUs);
                });

                if (hayOpiUs == 0)
                {
                    await Task.Run(() =>
                    {
                        datos.NuevaOpinion_us(idPeliApi, TipoArte, idUs, likeODis);
                    });

                }

                await Task.Run(() =>
                {
                    hayLike = datos.ObtLikes(idPeliApi, idUs);
                });

                if (hayLike != likeODis)
                {
                    await Task.Run(() =>
                    {
                        datos.ActualizarOpinion_us(idPeliApi, idUs, likeODis);
                    });
                }
            }

           
        }
    
    }
}
