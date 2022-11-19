using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoQuiniela.Context;
using ProyectoQuiniela.Models;

namespace ProyectoQuiniela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigaController : ControllerBase
    {

        private readonly QuinielaContext _context;

        public LigaController(QuinielaContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("ListaLiga")]
        public async Task<IActionResult> Lista()
        {
            List<Liga> lista = new List<Liga>();
            try
            {
                lista = await _context.Ligas.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Liga request)
        {
            try
            {
                await _context.Ligas.AddAsync(request);
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
        public async Task<IActionResult> Editar([FromBody] Liga request)
        {
            try
            {

                _context.Ligas.Update(request);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [HttpDelete]
        [Route("Borrar/{id:int}")]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {


            var tipoLigas = await _context.Ligas.FindAsync(id);
            if (tipoLigas == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not found");
            }




            _context.Ligas.Remove(tipoLigas);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        private bool LigaExists(int id)
        {
            return _context.Ligas.Any(e => e.IdLiga == id);
        }
    }
}
