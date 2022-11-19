using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoQuiniela.Context;
using ProyectoQuiniela.Models;

namespace ProyectoQuiniela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {

        private readonly QuinielaContext _context;

        public EquiposController(QuinielaContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("ListaEquipo")]
        public async Task<IActionResult> Lista()
        {
            List<Equipo> lista = new List<Equipo>();
            try
            {
                lista = await _context.Equipos.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }
    }
}
