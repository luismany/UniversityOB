using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UniversityApi.Models.DataModels
{
    public class Estudiante: BaseEntity
    {
        [Required]
        public string Nombres { get; set; } = string.Empty;
        [Required]
        public string Apellidos { get; set; } = string.Empty;
        public DateTime FechaDeNacimiento { get; set; }
        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    }
}
