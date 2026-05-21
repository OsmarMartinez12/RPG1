
using RPG1.Models;
using System.Text.Json;

namespace RPG1.Services
{
    public class PersonajeService
    {
        public List<Personaje> personajes = new();

        private readonly string ruta =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "personajes.json");

        public PersonajeService()
        {
            Cargar();
        }

        public void Guardar()
        {
            var listaGuardar = new List<object>();

            foreach (var p in personajes)
            {
                if (p is Guerrero g)
                {
                    listaGuardar.Add(new
                    {
                        Tipo = "Guerrero",
                        Nombre = g.Nombre,
                        Nivel = g.Nivel,
                        Vida = g.Vida,
                        XP = g.XP,
                        TipoArma = g.TipoArma,
                        DefensaFisica = g.DefensaFisica
                    });
                }

                else if (p is Mago m)
                {
                    listaGuardar.Add(new
                    {
                        Tipo = "Mago",
                        Nombre = m.Nombre,
                        Nivel = m.Nivel,
                        Vida = m.Vida,
                        XP = m.XP,
                        EscuelaMagia = m.EscuelaMagia,
                        Mana = m.Mana
                    });
                }

                else if (p is Arquero a)
                {
                    listaGuardar.Add(new
                    {
                        Tipo = "Arquero",
                        Nombre = a.Nombre,
                        Nivel = a.Nivel,
                        Vida = a.Vida,
                        XP = a.XP,
                        TipoArco = a.TipoArco,
                        Precision = a.Precision
                    });
                }
            }

            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json =
                JsonSerializer.Serialize(listaGuardar, opciones);

            File.WriteAllText(ruta, json);
        }

        public void Cargar()
        {
            personajes.Clear();

            if (!File.Exists(ruta))
                return;

            string json = File.ReadAllText(ruta);

            if (string.IsNullOrWhiteSpace(json))
                return;

            try
            {
                JsonDocument documento =
                    JsonDocument.Parse(json);

                foreach (JsonElement item in documento.RootElement.EnumerateArray())
                {
                    if (!item.TryGetProperty("Tipo", out JsonElement tipoElement))
                        continue;

                    string tipo = tipoElement.GetString();

                    switch (tipo)
                    {
                        case "Guerrero":

                            Guerrero g = new Guerrero
                            {
                                Nombre = item.GetProperty("Nombre").GetString(),
                                Nivel = item.GetProperty("Nivel").GetInt32(),
                                Vida = item.GetProperty("Vida").GetInt32(),
                                XP = item.GetProperty("XP").GetInt32(),
                                TipoArma = item.GetProperty("TipoArma").GetString(),
                                DefensaFisica = item.GetProperty("DefensaFisica").GetInt32()
                            };

                            personajes.Add(g);

                            break;

                        case "Mago":

                            Mago m = new Mago
                            {
                                Nombre = item.GetProperty("Nombre").GetString(),
                                Nivel = item.GetProperty("Nivel").GetInt32(),
                                Vida = item.GetProperty("Vida").GetInt32(),
                                XP = item.GetProperty("XP").GetInt32(),
                                EscuelaMagia = item.GetProperty("EscuelaMagia").GetString(),
                                Mana = item.GetProperty("Mana").GetInt32()
                            };

                            personajes.Add(m);

                            break;

                        case "Arquero":

                            Arquero a = new Arquero
                            {
                                Nombre = item.GetProperty("Nombre").GetString(),
                                Nivel = item.GetProperty("Nivel").GetInt32(),
                                Vida = item.GetProperty("Vida").GetInt32(),
                                XP = item.GetProperty("XP").GetInt32(),
                                TipoArco = item.GetProperty("TipoArco").GetString(),
                                Precision = item.GetProperty("Precision").GetInt32()
                            };

                            personajes.Add(a);

                            break;
                    }
                }
            }
            catch
            {
                personajes = new List<Personaje>();
            }
        }
    }
}