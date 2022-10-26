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
    public class IndiceController : ControllerBase
    {
        private readonly UniversityDbContext _universityDb;

        public IndiceController(UniversityDbContext universityDb)
        {
            _universityDb = universityDb;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Indice>>> Get()
        {

            return await _universityDb.Indices.ToListAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var indiceSeleccionado = await _universityDb.Indices.FindAsync(id);

            if (indiceSeleccionado != null)
                return Ok(indiceSeleccionado);
            else
                return BadRequest("No existe el Indice");
        }
        [HttpPost]
        public IActionResult Agregar(Indice agregarIndice)
        {
            if (agregarIndice == null)
                return BadRequest("Debe ingresar algun Indice");
            if (ModelState.IsValid)
            {
                _universityDb.Indices.Add(agregarIndice);
                _universityDb.SaveChanges();
                return Ok(agregarIndice);
            }
            else
                return BadRequest("Modelo Invalido");
        }
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, Indice actualizarIndice)
        {
            if (id != actualizarIndice.Id)
                return BadRequest("El Id es incorrecto");
            else
            {
                _universityDb.Entry(actualizarIndice).State = EntityState.Modified;
                _universityDb.SaveChanges();
                return Ok(actualizarIndice);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var indice = _universityDb.Indices.Find(id);

            if (indice.Id != id)
                return BadRequest("No existe el Indice");
            else
            {
                _universityDb.Indices.Remove(indice);
                _universityDb.SaveChanges();
                return Ok("Eliminado correctamente");
            }

        }
    }

}
