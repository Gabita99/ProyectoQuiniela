using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoQuiniela.Context;
using ProyectoQuiniela.Models;

namespace ProyectoQuiniela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {

        private readonly QuinielaContext _context;

        public GruposController(QuinielaContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("ListaGrupos")]
        public async Task<IActionResult> Lista()
        {
            List<Grupo> lista = new List<Grupo>();
            try
            {
                lista = await _context.Grupos.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }
    }
}
