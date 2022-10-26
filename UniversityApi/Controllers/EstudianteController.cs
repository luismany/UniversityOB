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
    public class EstudianteController : ControllerBase
    {
        private readonly UniversityDbContext _universityDb;
        public EstudianteController(UniversityDbContext universityDb)
        {
            _universityDb = universityDb;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> Get()
        {

            return await _universityDb.Estudiantes.ToListAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudianteSeleccionado = await _universityDb.Estudiantes.FindAsync(id);

            if (estudianteSeleccionado != null)
                return Ok(estudianteSeleccionado);
            else
                return BadRequest("No existe la categoria");
        }
        [HttpPost]
        public IActionResult Agregar(Estudiante agregarEstudiante)
        {
            if (agregarEstudiante == null)
                return BadRequest("Debe ingresar algun Estudiante");
            if (ModelState.IsValid)
            {
                _universityDb.Estudiantes.Add(agregarEstudiante);
                _universityDb.SaveChanges();
                return Ok(agregarEstudiante);
            }
            else
                return BadRequest("Modelo Invalido");
        }
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, Estudiante actualizarEstudiante)
        {
            if (id != actualizarEstudiante.Id)
                return BadRequest("El Id es incorrecto");
            else
            {
                _universityDb.Entry(actualizarEstudiante).State = EntityState.Modified;
                _universityDb.SaveChanges();
                return Ok(actualizarEstudiante);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var estudiante = _universityDb.Estudiantes.Find(id);

            if (estudiante.Id != id)
                return BadRequest("No existe la categoria");
            else
            {
                _universityDb.Estudiantes.Remove(estudiante);
                _universityDb.SaveChanges();
                return Ok("Eliminado correctamente");
            }

        }
    }
}
