using RPG1.Models;
using System.Text.Json;

namespace RPG.Services
{
    public class PersonajeService
    {
        private string ruta = "personajes.json";

        public List<Personaje> personajes = new();

        public void Guardar()
        {
            var json = JsonSerializer.Serialize(personajes);

            File.WriteAllText(ruta, json);
        }

        public void Cargar()
        {
            if (File.Exists(ruta))
            {
                string json = File.ReadAllText(ruta);

                personajes = JsonSerializer.Deserialize<List<Personaje>>(json)
                             ?? new List<Personaje>();
            }
        }
    }
}