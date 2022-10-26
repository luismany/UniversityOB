using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityApi.Models.DataModels
{
    public class Indice : BaseEntity
    {
        public string Capitulos { get; set; } = string.Empty;
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; } = new Curso();
    }
}
