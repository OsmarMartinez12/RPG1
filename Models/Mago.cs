using RPG1.Models;

namespace RPG1.Models
{
    public class Mago : Personaje
    {
        public string EscuelaMagia { get; set; } = string.Empty;

        public int Mana { get; set; }
    }
}