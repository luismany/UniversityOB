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
    public class UserController : ControllerBase
    {
        private readonly UniversityDbContext _universityDb;
        public UserController(UniversityDbContext universityDb)
        {
            _universityDb = universityDb;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {

            return await _universityDb.Users.ToListAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userSeleccionado = await _universityDb.Users.FindAsync(id);

            if (userSeleccionado != null)
                return Ok(userSeleccionado);
            else
                return BadRequest("No existe el Usuario");
        }
        [HttpPost]
        public IActionResult Agregar(User agregarUser)
        {
            if (agregarUser == null)
                return BadRequest("Debe ingresar algun Usuerio");
            if (ModelState.IsValid)
            {
                _universityDb.Users.Add(agregarUser);
                _universityDb.SaveChanges();
                return Ok(agregarUser);
            }
            else
                return BadRequest("Modelo Invalido");
        }
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, User actualizarUser)
        {
            if (id != actualizarUser.Id)
                return BadRequest("El Id es incorrecto");
            else
            {
                _universityDb.Entry(actualizarUser).State = EntityState.Modified;
                _universityDb.SaveChanges();
                return Ok(actualizarUser);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var user = _universityDb.Users.Find(id);

            if (user.Id != id)
                return BadRequest("No existe el Usuario");
            else
            {
                _universityDb.Users.Remove(user);
                _universityDb.SaveChanges();
                return Ok("Eliminado correctamente");
            }

        }
    }
}
