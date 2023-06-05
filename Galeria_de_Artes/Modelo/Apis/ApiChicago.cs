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
    /// Obtemcion de datos de la api de la Universidad de chicago
    /// Repositorio: https://api.artic.edu/docs/#quick-start
    /// </summary>
    public class ApiChicago
    {
        string respuesta;
        JsonDocument lectorPint, lectorAut, busqAutor, busqImg;

        /// <summary>
        /// Metodos que piden a la pagina web los elementos y caracteristicas de las primeras 100 pinturas o autores de estas y los metodos que devuelven las consultas en formato de JSON para poder utilizarlo
        /// </summary>
        /// <returns></returns>

        public async Task Pintura()
        {
            var direccion = new Uri("https://api.artic.edu/api/v1/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "artworks?page=1&limit=100";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    lectorPint = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerPintura()
        {
            return lectorPint;
        }

        public async Task Autor()
        {
            var direccion = new Uri("https://api.artic.edu/api/v1/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "artists?page=1&limit=100";
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
        /// Metodo que al seleccionar un autor buscara por el id de este los elementos y devolvera el json nuevo de uso 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task BusqAut(int id)
        {
            var direccion = new Uri("https://api.artic.edu/api/v1/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "artworks/search?=artist_id:" + id;
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    busqAutor = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerBusqAut()
        {
            return busqAutor;
        }

        /// <summary>
        /// Al haber seleccionado una pintura a esta se le buscaran ciertas caracteristicas como el nombre, artista y id del elemento de media que posean
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task BusqImgs(int id)
        {
            var direccion = new Uri("https://api.artic.edu/api/v1/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "artworks/" + id + "?fields=id,title,image_id,artist_id,artist_title,style_titles";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    busqImg = JsonDocument.Parse(respuesta);

                }
            }
        }

        public JsonDocument ObtenerImgs()
        {
            return busqImg;
        }


        public async Task BusqImgstitle(int id)
        {
            var direccion = new Uri("https://api.artic.edu/api/v1/");
            using (var httpClient = new HttpClient { BaseAddress = direccion })
            {
                string consulta = "artworks/" + id + "?fields=id,title,image_id,artist_id,artist_title,style_titles";
                using (var reponse = await httpClient.GetAsync(consulta))
                {
                    respuesta = await reponse.Content.ReadAsStringAsync();
                    busqImg = JsonDocument.Parse(respuesta);

                }
            }
        }


    }
}
