using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoQuiniela.Context;
using ProyectoQuiniela.Models;

namespace ProyectoQuiniela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly  QuinielaContext _context;

        public UsuarioController(QuinielaContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("ListaUsuarios")]
        public async Task<IActionResult> Lista()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                lista = await _context.Usuarios.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Usuario request)
        {
            try
            {
                await _context.Usuarios.AddAsync(request);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Usuario request)
        {
            try
            {
               
                _context.Usuarios.Update(request);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       // [HttpDelete("{id}")]
        [HttpDelete]
        [Route("Borrar/{id:int}")]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {
            
            
                var tipoUsuarios = await _context.Usuarios.FindAsync(id);
                if (tipoUsuarios == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Not found");
            }
            
            
            

                _context.Usuarios.Remove(tipoUsuarios);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
        }

        private bool TipoResultadoExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}

