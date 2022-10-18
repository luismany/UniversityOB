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
        public string Nombre { get; set; }
        [Required, StringLength(280)]
        public string DescripcionCorta { get; set; }
        public string DescripcionLarga { get; set; }
        public string PublicoObjetivo { get; set; }
        public string Objetivo { get; set; }
        public string Requisitos { get; set; }
        public Nivel Nivel { get; set; } = Nivel.Basico;
    }
}
