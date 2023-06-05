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
    /// Obtemcion de datos de la api ThemovieDB
    /// Repositorio: https://developer.themoviedb.org/reference/movie-details
    /// </summary>
    public class ApiCine
    {
        string respuesta;
        JsonDocument lectorPeli, lectorPerso, lectorGen, lectorBusqPal, lectorBusqTit;

        /// <summary>
        /// Metodos que piden a la pagina web los elementos y caracteristicas de las peliculas mas populares con lenguaje original en ingles y el que devuelven las consultas en formaoto de JSON para poder utilizarlo
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task Pelicula(int num)
        {
            var direccion = new Uri("https://api.themoviedb.org/3/movie/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "popular?api_key=7cce8a6001b6a66034b9c33454b9297e&language=en-US&page=" + num;
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorPeli = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerPelicula()
        {
            return lectorPeli;
        }

        public async Task Genero()
        {
            var direccion = new Uri("https://api.themoviedb.org/3/genre/movie/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "list?api_key=7cce8a6001b6a66034b9c33454b9297e&language=en-US";
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
        /// Metodo que realiza una consulta a partir de palabras claves con el fin de encontrar una pelicula parecida
        /// </summary>
        /// <param name="pal"></param>
        /// <returns></returns>

        public async Task PalabraClave(string pal)
        {
            var direccion = new Uri("https://api.themoviedb.org/3/search/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "movie?api_key=7cce8a6001b6a66034b9c33454b9297e&language=en-US&include_adult=false&page=1&query=" + pal;
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorBusqPal = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerPalabraClave()
        {
            return lectorBusqPal;
        }


        /// <summary>
        /// Al seleccionar una pleicula se buscarran las caracteristicas de ella.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Personal(int id)
        {
            var direccion = new Uri("https://api.themoviedb.org/3/movie/" + id + "/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "credits?api_key=7cce8a6001b6a66034b9c33454b9297e";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorPerso = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerPersonal()
        {
            return lectorPerso;
        }
    }
}
