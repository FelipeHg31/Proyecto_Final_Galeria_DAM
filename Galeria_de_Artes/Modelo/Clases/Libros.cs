using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria_de_Artes.Modelo.Clases
{
    /// <summary>
    ///  Clase para referenciar a un dato de la tabla de libros
    /// </summary>
    public class Libros
    {
        public string IdLibroApi { get; set; }
        public string Libro { get; set; }
        public string Opinion { get; set; }

        public Libros(string idLibroApi, string libro, string opinion)
        {
            IdLibroApi = idLibroApi;
            this.Libro = libro;
            Opinion = opinion;
        }

        public string ToString()
        {
            return "Libro: " + Libro + "\n Id libro IP: " + IdLibroApi;
        }
    }
}
