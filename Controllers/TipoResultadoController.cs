using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoQuiniela.Context;
using ProyectoQuiniela.Models;

namespace ProyectoQuiniela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoResultadoController : ControllerBase
    {
        private readonly QuinielaContext _context;

        public TipoResultadoController(QuinielaContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("TiposResultados")]
        public async Task<IActionResult> Lista()
        {
            List<TipoResultado> lista = new List<TipoResultado>();
            try
            {
                lista = await _context.TipoResultados.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

    }
}
