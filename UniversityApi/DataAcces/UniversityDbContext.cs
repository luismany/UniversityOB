using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApi.Models.DataModels;

namespace UniversityApi.DataAcces
{
    public class UniversityDbContext: DbContext
    {
        public UniversityDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Indice> Indices { get; set; }
    }
}
