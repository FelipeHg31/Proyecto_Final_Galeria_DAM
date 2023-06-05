using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Galeria_de_Artes.Modelo.Apis
{
    /// <summary>
    /// Obtencion de datos de la api de la pagina de Deezer
    /// Repositorio: https://developers.deezer.com/api/search
    /// </summary>

    public class ApiMusica
    {
        String respuesta;
        JsonDocument lectorAlb, lectorArt, lectorTit, lectorGen, busqAlb, busqArt, busqTit2;
        String ImagenEntrante;

        /// <summary>
        /// Metodos que piden a la pagina web los elementos y caracteristicas de los albumes, artistas y canciones organizadas por el ranking de de Deezer y los metrodos que devuelven las consultas en formaoto de JSON para poder utilizarlos
        /// </summary>
        
        public async Task Albumes(int index)
        {
            var direccion = new Uri("https://api.deezer.com/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "search?q=album&index=" + index + "&order=RANKING";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorAlb = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerAlbum()
        {
            return lectorAlb;
        }

        public async Task Artistass(int index)
        {
            var direccion = new Uri("https://api.deezer.com/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "search?q=artist&index=" + index + "&order=RANKING";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorArt = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerArtista()
        {
            return lectorArt;
        }


        public async Task Tituloss(int index)
        {
            var direccion = new Uri("https://api.deezer.com/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "search?q=track&index=" + index + "&order=RANKING";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorTit = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerTitulo()
        {
            return lectorTit;
        }


        public async Task Geneross()
        {
            var direccion = new Uri("https://api.deezer.com/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "genre";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorGen = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerGenero()
        {
            return lectorGen;
        }


        /// <summary>
        /// Al seleccionar un artista, un album o una cancion o al escribir en el alguno de los textbox de consulta se haran consultas para que solo salga su informacion
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        public async Task BusquedaArtista(string art)
        {
            var direccion = new Uri("https://api.deezer.com/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "search?q='" + art + "'";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    busqArt = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerArtBusq()
        {
            return busqArt;
        }


        public async Task BusquedaAlbum(string alb)
        {
            var direccion = new Uri("https://api.deezer.com/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "search?q=album:'" + alb + "'";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    busqAlb = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerAlbBusq()
        {
            return busqAlb;
        }

       
        public async Task BusquedaTitulo(string tit)
        {
            var direccion = new Uri("https://api.deezer.com/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "search?q=track:'" + tit + "'";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    busqTit2 = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerTitBusq()
        {
            return busqTit2;
        }


        public async Task BusquedaTituloArtistaAlbum(string tit)
        {
            var direccion = new Uri("https://api.deezer.com/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "search?q=track:'" + tit + "'";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    busqTit2 = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerTitArtAlbBusq()
        {
            return busqTit2;
        }
    }
}
