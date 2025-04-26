using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_Futbol_peruano.Models
{
    [Table("t_Equipos")]
    public class Equipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string? Ciudad { get; set; }

        public ICollection<Asociacion> Asociaciones { get; set; } = new List<Asociacion>();
    }
}
