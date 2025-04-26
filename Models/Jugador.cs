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

        [Range(15, 50, ErrorMessage = "La edad debe estar entre 15 y 50 años")]
        public int Edad { get; set; }

        public string? Posicion { get; set; }

        public ICollection<Asociacion> Asociaciones { get; set; } = new List<Asociacion>();

        [Required]
        public string? EquipoActual => Asociaciones?.FirstOrDefault()?.Equipo?.Nombre;
    }
}

