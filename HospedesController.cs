// Os controladores, que são responsáveis por receber as requisições (como GET, POST, PUT, DELETE) e retornar as respostas apropriadas. 
//Eles atuam como intermediários entre o cliente e o banco de dados, manipulando os dados e retornando as informações.

using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class HospedesController : ControllerBase{
    private readonly AppDataContext _context;

    public HospedesController(AppDataContext context){
        _context = context;
    }

    // GET: api/hospedes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hospede>>> GetHospedes(){
        return await _context.Hospedes.ToListAsync();
    }

    // GET: api/hospedes/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Hospede>> GetHospede(int id){
        var hospede = await _context.Hospedes.FindAsync(id);

        if (hospede == null){
            return NotFound();
        }
return hospede;
    }

    // POST: api/hospedes
    [HttpPost]
    public async Task<ActionResult<Hospede>> PostHospede(Hospede hospede){
        _context.Hospedes.Add(hospede);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetHospede), new { id = hospede.Id }, hospede);
    }
}
