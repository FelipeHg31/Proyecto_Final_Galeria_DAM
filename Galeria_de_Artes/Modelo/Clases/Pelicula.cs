using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria_de_Artes.Modelo.Clases
{
    /// <summary>
    ///  Clase para referenciar a un dato de la tabla de peliculas
    /// </summary>
    public class Pelicula
    {
        public string IdPeliculaApi { get; set; }
        public string pelicula { get; set; }
        public string Opinion { get; set; }
        public int Genero { get; set; }


        public Pelicula(string idPeliculaApi, string pelicula, string opinion, int genero)
        {
            IdPeliculaApi = idPeliculaApi;
            this.pelicula = pelicula;
            Opinion = opinion;
            Genero = genero;
        }

        public string ToString()
        {
            return "Pelicula: " + pelicula + "\n Id pelicula IP: " + IdPeliculaApi + "\n Genero " + Genero;
        }
    }
}
