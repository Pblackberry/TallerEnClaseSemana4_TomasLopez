using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TallerEnClaseSemana4_TomasLopez.Models
{
    public class Jugador
    {
        [Key]
        public int IdJugador { get; set; }
        public string NombreJugador { get; set; }
        public string Posicion { get; set; }
        [ForeignKey("Equipos")]
        [Required]
        public int IdEquipo { get; set; }
        public Equipos? Equipo { get; set; }
    };
}
