using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria_de_Artes.Modelo.Clases
{

    /// <summary>
    ///  Clase para referenciar a un dato de la tabla de pinturas
    /// </summary>
    public class Pintur
    {
        public string IdPinturaApi { get; set; }
        public string Pintura { get; set; }
        public string Opinion { get; set; }
        public string Genero { get; set; }

        public Pintur(string idPinturaApi, string pintura, string opinion, string genero)
        {
            IdPinturaApi = idPinturaApi;
            this.Pintura = pintura;
            Opinion = opinion;
            Genero = genero;
        }

        public string ToString()
        {
            return "Pintura: " + Pintura + "\n Id pintura IP: " + IdPinturaApi + "\n Genero: "+ Genero;
        }
    }
}
