using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria_de_Artes.Modelo.Clases
{
    /// <summary>
    ///  Clase para referenciar a un dato de la tabla de usuarios
    /// </summary>
    public class Usuarios
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string contraseña { get; set; }
        public int rol { get; set; }

        public Usuarios(int id, string nombre, string contraseña, int rol)
        {
            this.id = id;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.rol = rol;
        }

        public string ToString()
        {
            return id + ". "+ nombre + ", rol: " + rol;
        }
    }
}
