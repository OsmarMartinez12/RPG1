using System.ComponentModel.DataAnnotations;

namespace RPG1.Models
{
    public class Personaje
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Range(1, 99)]
        public int Nivel { get; set; }

        [Range(1, int.MaxValue)]
        public int Vida { get; set; }

        [Range(0, int.MaxValue)]
        public int XP { get; set; }
    }
}