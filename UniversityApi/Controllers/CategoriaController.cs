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
    public class CategoriaController : ControllerBase
    {
        private readonly UniversityDbContext _universityDb;
        public CategoriaController(UniversityDbContext universityDb)
        {
            _universityDb = universityDb;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {

            return await _universityDb.Categorias.ToListAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoriaSeleccionada = await _universityDb.Categorias.FindAsync(id);

            if (categoriaSeleccionada != null)
                return Ok(categoriaSeleccionada);
            else
                return BadRequest("No existe la categoria");
        }
        [HttpPost]
        public IActionResult Agregar(Categoria agregarCategoria)
        {
            if (agregarCategoria == null)
                return BadRequest("Debe ingresar alguna categoria");
            if (ModelState.IsValid)
            {
                _universityDb.Categorias.Add(agregarCategoria);
                _universityDb.SaveChanges();
                return Ok(agregarCategoria);
            }
            else
                return BadRequest("Modelo Invalido");
        }
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, Categoria actualizarCategoria)
        {
            if (id != actualizarCategoria.Id)
                return BadRequest("El Id es incorrecto");
            else
            {
                _universityDb.Entry(actualizarCategoria).State = EntityState.Modified;
                _universityDb.SaveChanges();
                return Ok(actualizarCategoria);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var categoria = _universityDb.Categorias.Find(id);

            if (categoria.Id != id)
                return BadRequest("No existe la categoria");
            else
            {
                _universityDb.Categorias.Remove(categoria);
                _universityDb.SaveChanges();
                return Ok("Eliminado correctamente");
            }
                
       }
    }
}

