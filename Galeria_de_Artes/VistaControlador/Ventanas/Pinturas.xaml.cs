using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Lógica de interacción para Pinturas.xaml
    /// </summary>
    public partial class Pinturas : Page
    {
        ApiChicago api = new ApiChicago();
        JsonDocument pint, aut, busqaut, imag, selecc;
        int selec = -1;
        Metodos met = new Metodos();
        int likeODis = 0;
        CRUD datos = new CRUD();
        int TipoArte;

        public Pinturas()
        {
            InitializeComponent();
            api.Pintura();
            api.Autor();
            api.BusqAut(0);

            TipoArte = 2;
        }


        /// <summary>
        /// Metodos de obtencion de datos de las apis
        /// </summary>

        private void titulos_MouseEnter(object sender, MouseEventArgs e)
        {
            api.Pintura();


            if (titulos.Items.Count < 1)
            {
                titulos.ToolTip = "Por favor esperar la carga de los datos";

                pint = api.ObtenerPintura();

                if (pint != null)
                {
                    int Cant = pint.RootElement.GetProperty("data").GetArrayLength();

                    for (int i = 0; i < Cant; i++)
                    {
                        titulos.Items.Add(pint.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                    }
                }

                selec = 0;
            }
            else
            {
                titulos.ToolTip = "Selecciona una pintura";
            }

        }


        private void Director_MouseEnter(object sender, MouseEventArgs e)
        {
            api.Autor();
            aut = api.ObtenerAutor();

            if (Autor.Items.Count < 1)
            {

                Autor.ToolTip = "Por favor esperar la carga de los datos";

                if (aut != null)
                {
                    int Cant = aut.RootElement.GetProperty("data").GetArrayLength();

                    for (int i = 0; i < Cant; i++)
                    {
                        Autor.Items.Add(aut.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                    }
                }
            }
            else
            {
                Autor.ToolTip = "Selecciona un artista";
            }
           

        }

        /// <summary>
        /// Acciones del seleccionar un elemento de los combobox
        /// </summary>

        private void Autor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int pos = Autor.SelectedIndex;
            int Canti = aut.RootElement.GetProperty("data").GetArrayLength();

            if ((-1 < pos) && (pos < Canti))
            {
                int data = Convert.ToInt32(aut.RootElement.GetProperty("data")[pos].GetProperty("id").ToString());

                api.BusqAut(data);
                busqaut = api.ObtenerBusqAut();

                titulos.Items.Clear();
                if (busqaut != null)
                {
                    int Cant = busqaut.RootElement.GetProperty("data").GetArrayLength();

                    for (int i = 0; i < Cant; i++)
                    {
                        titulos.Items.Add(busqaut.RootElement.GetProperty("data")[i].GetProperty("title").ToString());
                    }
                    selec = 1;
                }


            }

        }

        private void titulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pos = titulos.SelectedIndex;

            if (titulos.Items.Count > 0)
            {
                if (selec == 0)
                {
                    string idImag = pint.RootElement.GetProperty("data")[pos].GetProperty("image_id").ToString();
                    int id = pint.RootElement.GetProperty("data")[pos].GetProperty("id").GetInt32();
                    api.BusqImgs(id);
                    imag = api.ObtenerImgs();
                    Pintura.Source = new BitmapImage(new Uri("https://www.artic.edu/iiif/2/" + idImag + "/full/843,/0/default.jpg"));
                }
                else if (selec == 1)
                {

                    int id = busqaut.RootElement.GetProperty("data")[pos].GetProperty("id").GetInt32();
                    api.BusqImgs(id);
                    

                    imag = api.ObtenerImgs();
                    if (imag != null)
                    {
                        string idImag = imag.RootElement.GetProperty("data").GetProperty("image_id").ToString();
                        Pintura.Source = new BitmapImage(new Uri("https://www.artic.edu/iiif/2/" + idImag + "/full/843,/0/default.jpg"));
                    }
                }
            }
            
        }



        /// <summary>
        /// Acciones de los botones
        /// </summary>


        /// <summary>
        /// Boton que guarda los datos en la base de datos
        /// </summary>
        
        private void opi_Click(object sender, RoutedEventArgs e)
        {
            string idPintApi = "", Pintura = "", opi, media = "", genero ="";
            int idUs;
            int pos = titulos.SelectedIndex;


            if (selec == 0)
            {
                idPintApi = pint.RootElement.GetProperty("data")[pos].GetProperty("id").GetInt32().ToString();
                Pintura = pint.RootElement.GetProperty("data")[pos].GetProperty("title").ToString();
                idUs = UsuarioIngresado.id;
                media = pint.RootElement.GetProperty("data")[pos].GetProperty("image_id").ToString();
                
            }
            else
            {
                idPintApi = imag.RootElement.GetProperty("data").GetProperty("id").GetInt32().ToString();
                Pintura = imag.RootElement.GetProperty("data").GetProperty("title").ToString();
                idUs = UsuarioIngresado.id;
                media = imag.RootElement.GetProperty("data").GetProperty("image_id").ToString();
                
            }

            if (opinion.Text != "")
            {
               opi = opinion.Text.ToString();
            }
            else
            {
                opi = "";
            }

                Pintur pintu = new Pintur(idPintApi, Pintura, opi, "");

                IngresoDatos(idPintApi, Pintura, opi, idUs, media);

                MessageBox.Show(pintu.ToString());
            
        }


        /// <summary>
        /// Boton de nueva busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Busq_Click(object sender, RoutedEventArgs e)
        {
            titulos.Items.Clear();
            Autor.Items.Clear();
            opinion.Text = "";
            Pintura.Source = new BitmapImage();
            gusta.Background = Brushes.Black;
            No_Gusta.Background = Brushes.Black;
            opinion.Text = "";

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
        /// Interaccion con la imagen proporcionada por la obra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pintura_MouseEnter(object sender, MouseEventArgs e)
        {
            Pintura.Width = 400;
            Pintura.Height = 400;
        }

        private void Pintura_MouseLeave(object sender, MouseEventArgs e)
        {
            Pintura.Width = 150;
            Pintura.Height = 150;

        }

        /// <summary>
        /// Metodo que ingresa las interacciones realizadas por el usuario en la aplicacion.
        /// </summary>
        /// <param name="idApi"></param>
        /// <param name="Pin"></param>
        /// <param name="opi"></param>
        /// <param name="idUs"></param>
        /// <param name="media"></param>
        /// <returns></returns>

        public async Task IngresoDatos(string idApi, string Pin, string opi, int idUs, string media)
        {
            int hayObra = 0, hayOpi = 0, hayOpiUs = 0, hayLike = 0;
            string opin = "";

            await Task.Run(() =>
            {
                hayObra = datos.BuscarObras(idApi, TipoArte);
            });

            if (hayObra == 0)
            {
                datos.NuevaObra(Pin, idApi, TipoArte, 0, media);
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
                    if (likeODis == -1)
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
