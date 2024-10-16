using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TallerEnClaseSemana4_TomasLopez.Models
{
    public class Equipos
    {
        [Key]

        public int IdEquipo { get; set; }
        public String Nombre { get; set; }
        public String Ciudad {  get; set; }
        public int Titulos { get; set; }
        public bool AceptExtr {  get; set; }
        public Estadio Estadio { get; set; }
        [ForeignKey("Estadio")]
        [AllowNull]
        public int IdEstadio { get; set; }

    }
}
