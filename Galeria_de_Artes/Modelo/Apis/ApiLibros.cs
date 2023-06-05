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
    /// Obtemcion de datos de la api de la pagina Openlibrary
    /// Repositorio: https://github.com/internetarchive/openlibrary/tree/master/openlibrary
    /// </summary>
    public class ApiLibros
    {
        string respuesta;
        JsonDocument lectorLib, lectorAut, busqAut, busqTit;
        string ImagenEntrante;


        /// <summary>
        /// Metodos que piden a la pagina web los elementos y caracteristicas de las primeras 50 libros o autores de estos y los metodos que devuelven las consultas en formato de JSON para poder utilizarlo
        /// </summary>
        /// <returns></returns>

        public async Task Libro()
        {
            var direccion = new Uri("http://openlibrary.org/subjects/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "fantasy.json?limit=50";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorLib = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerLibro()
        {
            return lectorLib;
        }

        public async Task Autore()
        {
            var direccion = new Uri("https://openlibrary.org/subjects/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "fantasy.json?";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorAut = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerAutor()
        {
            return lectorAut;
        }

        /// <summary>
        /// Al seleccionar un autor o un libro se haran consultas sobre las obras de este o sus caracteristicas respectivamente, estos se devolvera en JSON's
        /// </summary>
        /// <param name="tit"></param>
        /// <returns></returns>
        public async Task BusquedaAutor(string autr)
        {
            var direccion = new Uri("https://openlibrary.org/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "search.json?author=" + autr;
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    busqAut = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerBusqAut()
        {
            return busqAut;
        }


        
        public async Task BusquedaTit(string tit)
        {
            var direccion = new Uri("https://openlibrary.org/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "search.json?title=" + tit;
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    busqTit = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerBusqTit()
        {
            return busqTit;
        }
    }
}
