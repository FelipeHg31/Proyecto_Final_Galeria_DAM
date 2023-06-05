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
using Galeria_de_Artes.VistaControlador.User_control;

namespace Galeria_de_Artes.VistaControlador.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Musica.xaml
    /// </summary>
    public partial class Musica : Page
    {
        ApiMusica api = new ApiMusica();
        JsonDocument albumes, artistas, tituloss, geneross, busqArt, busqAlb, busqTit, busqGen;
        int sel = -1;
        int likeODis = 0;
        CRUD datos = new CRUD();
        int TipoArte;
        public Musica()
        {
            InitializeComponent();
            api.Albumes(0);
            api.Tituloss(0);
            api.Artistass(0);
            api.Geneross();

            TipoArte = 1;

        }

        /// <summary>
        /// Metodos de obtencion de datos de las apis
        /// </summary>

        private void Album_MouseEnter(object sender, MouseEventArgs e)
        {
            int index = 0;

            if (Album.Items.Count < 1)
            {
                Album.ToolTip = "Por favor esperar la carga de los datos";

                for (int num = 0; num < 4; num++)
                {
                    api.Albumes(index);

                    albumes = api.ObtenerAlbum();

                    if (albumes != null)
                    {
                        int Cant = albumes.RootElement.GetProperty("data").GetArrayLength();

                        for (int i = 0; i < Cant; i++)
                        {
                            Album.Items.Add(albumes.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                        }

                        if (num == 0)
                        {
                            index = 25;
                        }
                        else
                        {
                            index = index * num;
                        }
                    }

                }

            }else
            {
                Album.ToolTip = "Selecciona un album";
            }
        }


        private void titulos_MouseEnter(object sender, MouseEventArgs e)
        {
            int index = 0;

            if (titulos.Items.Count < 1)
            {
                titulos.ToolTip = "Por favor esperar la carga de los datos";

                for (int num = 0; num < 4; num++)
                {
                    api.Tituloss(index);

                    tituloss = api.ObtenerTitulo();

                    if (tituloss != null)
                    {
                        int Cant = tituloss.RootElement.GetProperty("data").GetArrayLength();

                        for (int i = 0; i < Cant; i++)
                        {
                            titulos.Items.Add(tituloss.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                        }

                        if (num == 0)
                        {
                            index = 25;
                        }
                        else
                        {
                            index = index * num;
                        }
                    }
                    else
                    {
                        num = 0;
                    }
                    sel = 0;
                }
            }
            else
            {
                titulos.ToolTip = "Selecciona una cancion";
            }
        }

       

       

        private void artista_MouseEnter(object sender, MouseEventArgs e)
        {
            int index = 0;
            try
            {
                if (artista.Items.Count < 1)
                {
                    artista.ToolTip = "Por favor esperar la carga de los datos";

                    for (int num = 0; num < 4; num++)
                    {
                        api.Artistass(index);

                        artistas = api.ObtenerArtista();
                        int Cant = artistas.RootElement.GetProperty("data").GetArrayLength();

                        for (int i = 0; i < Cant; i++)
                        {
                            artista.Items.Add(artistas.RootElement.GetProperty("data")[i].GetProperty("artist").GetProperty("name").ToString());
                        }

                        if (num == 0)
                        {
                            index = 25;
                        }
                        else
                        {
                            index = index * num;
                        }
                    }
                }
                else
                {
                    artista.ToolTip = "Selecciona un artista";
                }
            }
            catch (Exception ex) { }
            

           
        }


        /// <summary>
        /// Acciones del seleccionar un elemento de los combobox
        /// AL seleccionar una cancion dependiendo de las interacciones con el usuario se accedera al elemento de media por los diferentes JSON que se tienen
        /// </summary>

        private void titulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string dir = "";

                if (sel == 0)
                {
                    dir = tituloss.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("preview").ToString();
                    Music.Source = new Uri(dir, UriKind.Absolute);
                }
                else if (sel == 1)
                {
                    dir = busqArt.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("preview").ToString();
                    Music.Source = new Uri(dir, UriKind.Absolute);
                }
                else if (sel == 2)
                {
                    dir = busqAlb.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("preview").ToString();
                    Music.Source = new Uri(dir, UriKind.Absolute);
                }

                Music.LoadedBehavior = MediaState.Manual;
                Music.Play();
            }
            catch (Exception)
            { }


        }

        private void artista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string nombre = "";

                if ((-1 < artista.SelectedIndex) && (artista.SelectedIndex < artista.Items.Count))
                {
                    if (sel == 0)
                    {
                        nombre = artistas.RootElement.GetProperty("data")[artista.SelectedIndex].GetProperty("artist").GetProperty("name").ToString();

                    }

                    else if (sel == 2)
                    {
                        nombre = busqAlb.RootElement.GetProperty("data")[artista.SelectedIndex].GetProperty("artist").GetProperty("name").ToString();
                    }


                    api.BusquedaArtista(nombre);

                    busqArt = api.ObtenerArtBusq();

                    sel = 1;
                }

                if (busqArt != null)
                {
                    int Canti = busqArt.RootElement.GetProperty("data").GetArrayLength();

                    titulos.Items.Clear();
                    Album.Items.Clear();

                    for (int i = 0; i < Canti; i++)
                    {
                        titulos.Items.Add(busqArt.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                        Album.Items.Add(busqArt.RootElement.GetProperty("data")[i].GetProperty("album").GetProperty("title").ToString());
                    }


                }

            }
            catch (Exception) { }

        }

        private void Album_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nombre = "";

            if ((-1 < Album.SelectedIndex) && (Album.SelectedIndex < Album.Items.Count))
            {
                if (sel == 0)
                {
                    nombre = albumes.RootElement.GetProperty("data")[Album.SelectedIndex].GetProperty("title").ToString();
                }
                else if (sel == 1)
                {
                    nombre = busqArt.RootElement.GetProperty("data")[Album.SelectedIndex].GetProperty("album").GetProperty("title").ToString();
                }


                api.BusquedaAlbum(nombre);

                busqAlb = api.ObtenerArtBusq();

                sel = 2;
            }


            if (busqAlb != null)
            {
                int Canti = busqAlb.RootElement.GetProperty("data").GetArrayLength();

                titulos.Items.Clear();
                artista.Items.Clear();

                for (int i = 0; i < Canti; i++)
                {
                    titulos.Items.Add(busqAlb.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                    artista.Items.Add(busqAlb.RootElement.GetProperty("data")[i].GetProperty("artist").GetProperty("name").ToString());
                }


            }
        }

        /// <summary>
        /// Acciones de los botones
        /// Boton que guarda los datos en la base de datos
        /// </summary>

        private void selecCan_Click(object sender, RoutedEventArgs e)
        {
            string Capi = "";
            string canc = "";
            string op = "";
            int idUs = UsuarioIngresado.id;
            string media = "";

            switch (sel)
            {
                case 0:
                    Capi = tituloss.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("id").ToString();
                    canc = tituloss.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("title").ToString();
                    media = tituloss.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("preview").ToString();
                    break;

                case 1:
                    Capi = busqArt.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("id").ToString();
                    canc = busqArt.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("title").ToString();
                    media = busqArt.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("preview").ToString();

                    break;

                case 2:
                    Capi = busqAlb.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("id").ToString();
                    canc = busqAlb.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("title").ToString();
                    media = busqAlb.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("preview").ToString();

                    break;
                case 3:
                    Capi = busqTit.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("id").ToString();
                    canc = busqTit.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("title").ToString();
                    media = busqTit.RootElement.GetProperty("data")[titulos.SelectedIndex].GetProperty("preview").ToString();

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
            

            IngresoDatos(Capi, canc, op, idUs, media);

            Canciones can = new Canciones(Capi, canc, op);

            MessageBox.Show(can.ToString());

        }

        /// <summary>
        /// Boton de nueva busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Selec_Click(object sender, RoutedEventArgs e)
        {
            Album.SelectedValue = null;
            artista.SelectedValue = null;
            titulos.SelectedValue = null;
            AlbumEsc.Text = "";
            artistaEsc.Text = "";
            titulosEsc.Text = "";
            artista.Items.Clear();
            Album.Items.Clear();
            titulos.Items.Clear();
            sel = 0;
            gusta.Background = Brushes.Black;
            No_Gusta.Background = Brushes.Black;
            opinion.Text = "";

        }

        private void Pausa_Click(object sender, RoutedEventArgs e)
        {
            Music.Pause();
        }

        /// <summary>
        /// Busqueda por ingreso de datos en los textbox o al seleccionar un item de los combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Busq_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;

            if (titulosEsc.Text != "")
            {
                string titu = titulosEsc.Text.ToString();

                api.BusquedaTitulo(titu);

                sel = 3;

                busqTit = api.ObtenerTitBusq();

                if (busqTit != null)
                {
                    int Cant = busqTit.RootElement.GetProperty("data").GetArrayLength();

                    titulos.Items.Clear();
                    artista.Items.Clear();
                    Album.Items.Clear();

                    for (int i = 0; i < Cant; i++)
                    {
                        titulos.Items.Add(busqTit.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                        artista.Items.Add(busqTit.RootElement.GetProperty("data")[i].GetProperty("artist").GetProperty("name").ToString());
                        Album.Items.Add(busqTit.RootElement.GetProperty("data")[i].GetProperty("album").GetProperty("title").ToString());
                    }
                }

            }

            if (artistaEsc.Text != "")
            {
                string art = artistaEsc.Text.ToString();
                sel = 1;
                api.BusquedaArtista(art);

                busqArt = api.ObtenerArtBusq();

                titulos.Items.Clear();
                artista.Items.Clear();
                Album.Items.Clear();

                if (busqArt != null)
                {
                    int Cant = busqArt.RootElement.GetProperty("data").GetArrayLength();

                    for (int i = 0; i < Cant; i++)
                    {
                        artista.Items.Add(busqArt.RootElement.GetProperty("data")[i].GetProperty("artist").GetProperty("name").ToString());
                        titulos.Items.Add(busqArt.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                        Album.Items.Add(busqArt.RootElement.GetProperty("data")[i].GetProperty("album").GetProperty("title").ToString());
                    }
                }

            }

            if (AlbumEsc.Text != "")
            {
                string alb = AlbumEsc.Text.ToString();
                sel = 2;
                api.BusquedaAlbum(alb);
                titulos.Items.Clear();
                artista.Items.Clear();
                Album.Items.Clear();

                busqAlb = api.ObtenerAlbBusq();

                if (busqAlb != null)
                {
                    int Cant = busqAlb.RootElement.GetProperty("data").GetArrayLength();

                    for (int i = 0; i < Cant; i++)
                    {
                        titulos.Items.Add(busqAlb.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                        artista.Items.Add(busqAlb.RootElement.GetProperty("data")[i].GetProperty("artist").GetProperty("name").ToString());
                        Album.Items.Add(busqAlb.RootElement.GetProperty("data")[i].GetProperty("album").GetProperty("title").ToString());
                    }
                }

            }


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
        /// <param name="Music"></param>
        /// <param name="opi"></param>
        /// <param name="idUs"></param>
        /// <param name="media"></param>
        /// <returns></returns>


        public async Task IngresoDatos(string idApi, string Music, string opi, int idUs, string media)
        {
            int hayObra = 0, hayOpi = 0, hayOpiUs = 0, hayLike = 0;
            string opin = "";

            await Task.Run(() =>
            {
                hayObra = datos.BuscarObras(idApi, TipoArte);
            });

            if (hayObra == 0)
            {
                datos.NuevaObra(Music, idApi, TipoArte, 0, media);
                await Task.Run(() =>
                {
                    datos.NuevaOpinion(idApi, idUs, opi);
                });

                await Task.Run(() =>
                {
                   if(likeODis == 1)
                    {
                        datos.NuevoOpinionApp(idApi, 0, likeODis);
                    }
                   if(likeODis == -1)
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
