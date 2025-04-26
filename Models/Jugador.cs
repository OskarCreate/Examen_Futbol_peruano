using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_Futbol_peruano.Models
{
    [Table("t_Jugadores")]
    public class Jugador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public DateTime? Cumpleaños { get; set; }

        public string? Posicion { get; set; }

        public ICollection<Asociacion> Asociaciones { get; set; } = new List<Asociacion>();

        [NotMapped]
        public int? Edad => Cumpleaños.HasValue ? 
            (int)((DateTime.Now - Cumpleaños.Value).TotalDays / 365.25) : null;
    }
}
