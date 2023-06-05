using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Galeria_de_Artes.Modelo.Clases
{
    /// <summary>
    ///  Clase de metodos auxiliares 
    /// </summary>
    public class Metodos
    {
        public Metodos()
        { }

        public async void EsperarCargaDatos(int tiempoEspera)
        {
            Console.WriteLine($"Esperando {tiempoEspera} segundos para cargar los datos...");
            await Task.Delay(TimeSpan.FromSeconds(tiempoEspera));
            Console.WriteLine("Carga de datos completada.");
        }

        public void Propiedades_Json(JsonDocument json)
        {
            foreach (JsonProperty property in json.RootElement.EnumerateObject())
            {
                MessageBox.Show($"Nombre de propiedad: {property.Name}");
            }
        }
    }
}
