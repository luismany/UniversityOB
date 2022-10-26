using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UniversityApi.Models.DataModels
{
    public class Categoria: BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
