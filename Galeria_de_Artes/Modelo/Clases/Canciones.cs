using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria_de_Artes.Modelo.Clases
{
    /// <summary>
    ///  Clase para referenciar a un dato de la tabla de musica
    /// </summary>
    public class Canciones
    {
        public string IdCancionApi { get; set; }
        public string Cancion { get; set; }
        public string Opinion { get; set; }

        public Canciones(string idCancionApi, string cancion, string opinion)
        {
            IdCancionApi = idCancionApi;
            Cancion = cancion;
            Opinion = opinion;
        }

        public string ToString()
        {
            return "Cancion: " + Cancion + "\n Id cancion IP: " + IdCancionApi;
        }
    }
}
