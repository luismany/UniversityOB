using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UniversityApi.Models.DataModels
{

    public enum Nivel
    {
        Basico,
        Intermedio,
        Avanzado
    }
    public class Curso: BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public Nivel Nivel { get; set; } = Nivel.Basico;
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
        public ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        public ICollection<Indice> Indices { get; set; } = new List<Indice>();
    }
}
