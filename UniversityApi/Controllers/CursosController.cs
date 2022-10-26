using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApi.DataAcces;
using UniversityApi.Models.DataModels;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly UniversityDbContext _dbContext;
        public CursosController( UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> Get() 
        {
            return await _dbContext.Cursos.ToListAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cursoSeleccionado = await (from curso in _dbContext.Cursos
                                           where curso.Id == id
                                           select curso).FirstOrDefaultAsync();
            if (cursoSeleccionado != null)
                return Ok(cursoSeleccionado);
            else
                return BadRequest("no existe el curso");

        }
        [HttpPost]
        public IActionResult Agregar(Curso agregarCurso)
        {
            if (agregarCurso == null)
                return BadRequest("El modelo no puede ser nullo");
            if (ModelState.IsValid)
            { 
            _dbContext.Cursos.Add(agregarCurso);
              _dbContext.SaveChanges();

            return Ok(agregarCurso);
        }
            else
                return BadRequest("Modelo Invalido");
        }
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, Curso actualizarCurso)
        {
            if (id != actualizarCurso.Id)
                return BadRequest("El Id es incorrecto");
            else
            {
                _dbContext.Entry(actualizarCurso).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return Ok(actualizarCurso);
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var curso = _dbContext.Cursos.Find(id);
            if (curso.Id != id)
                return BadRequest("No existe el curso");
            _dbContext.Cursos.Remove(curso);
            _dbContext.SaveChanges();
            return Ok("Eliminado correctamente");
        }

    }
}
