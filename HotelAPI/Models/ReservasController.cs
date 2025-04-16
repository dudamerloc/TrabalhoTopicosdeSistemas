using API.Models;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ReservasController(AppDataContext context)
        {
            _context = context;
        }

        // POST: api/reservas
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            var hospede = await _context.Hospedes.FindAsync(reserva.HospedeId);
            var quarto = await _context.Quartos.FindAsync(reserva.QuartoId);

            if (hospede == null || quarto == null)
            {
                return NotFound("Hospede ou Quarto não encontrados.");
            }

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            // Corrigido para o nome correto do método
            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reserva);
        }

        // GET: api/reservas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }
    }
}
