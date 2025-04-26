using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Examen_Futbol_peruano.Models
{
    [Table("t_Asociaciones")]
    [Index(nameof(JugadorId), nameof(EquipoId), IsUnique = true)]
    public class Asociacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int JugadorId { get; set; }

        [Required]
        public int EquipoId { get; set; }

        public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;

        [ForeignKey("JugadorId")]
        public Jugador Jugador { get; set; }

        [ForeignKey("EquipoId")]
        public Equipo Equipo { get; set; }
    }
}
