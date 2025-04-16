using API.Models;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]  // Define a rota /api/quartos
    [ApiController]
    public class QuartosController : ControllerBase{
        private readonly AppDataContext _context;  // readonly serve para garantir que o contexto não seja alterado depois de inicializado

        public QuartosController(AppDataContext context)
        {
            _context = context;
        }

        // GET: api/quartos
        [HttpGet]  // Retorna todos os quartos
        public async Task<ActionResult<IEnumerable<Quarto>>> GetQuartos(){ 

            return await _context.Quartos.ToListAsync();  // Retorna todos os quartos como uma lista
        }
    }
}

