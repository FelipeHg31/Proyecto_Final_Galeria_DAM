using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria_de_Artes.Modelo.Clases
{
    /// <summary>
    ///  Clase para referenciar una obra general
    /// </summary>
    public class obras
    {
        public int tipo { get; set; }
        public string id { get; set; }

        public obras(int tipo, string id)
        {
            this.tipo = tipo;
            this.id = id;
        }

    }
}
