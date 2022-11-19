using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoQuiniela.Context;
using ProyectoQuiniela.Models;

namespace ProyectoQuiniela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly QuinielaContext _context;

        public RolesController(QuinielaContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Role> lista = new List<Role>();
            try
            {
                lista = await _context.Roles.ToListAsync();
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }
    }
}
