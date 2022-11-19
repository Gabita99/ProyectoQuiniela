using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoQuiniela.Context;
using ProyectoQuiniela.Models;

namespace ProyectoQuiniela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {

        private readonly QuinielaContext _context;

        public PartidosController(QuinielaContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("ListaPartidos")]
        public async Task<IActionResult> Lista()
        {
            List<Partido> lista = new List<Partido>();
            try
            {
                lista = await _context.Partidos.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }
    }
}
