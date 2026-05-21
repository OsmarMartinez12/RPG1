using RPG1.Models;

namespace RPG1.Models
{
    public class Guerrero : Personaje
    {
        public string TipoArma { get; set; } = string.Empty;

        public int DefensaFisica { get; set; }
    }
}