// Os controladores, que são responsáveis por receber as requisições (como GET, POST, PUT, DELETE) e retornar as respostas apropriadas. 
//Eles atuam como intermediários entre o cliente e o banco de dados, manipulando os dados e retornando as informações.

using Microsoft.AspNetCore.Mvc;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;
using API.Models;
using AppContext = HotelApi.Models.AppDataContext;
using System.Collections.Generic;


namespace HotelApi.Controllers{

    [Route("api/[controller]")]  // Define que a rota será /api/hospedes
    [ApiController]  // Indica que este é um controller de API
    public class HospedesController : ControllerBase
    {
        
        private readonly HotelApi.Models.AppDataContext _context;

       public HospedesController(HotelApi.Models.AppDataContext context)
{
    _context = context;
}

        // GET: api/hospedes
        // Este método retorna todos os hóspedes do banco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospede>>> GetHospedes()
        {
            // Retorna todos os hóspedes como uma lista
            return await _context.Hospedes.ToListAsync();
        }

        // GET: api/hospedes/{id}
        // Este método retorna um hóspede específico pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Hospede>> GetHospede(int id)
        {
            var hospede = await _context.Hospedes.FindAsync(id);

            // Se o hóspede não for encontrado, retorna um erro 404 (não encontrado)
            if (hospede == null)
            {
                return NotFound();
            }

            return hospede; // Retorna o hóspede encontrado
        }

        // POST: api/hospedes
        // Este método permite adicionar um novo hóspede
        [HttpPost]
        public async Task<ActionResult<Hospede>> PostHospede(Hospede hospede)
        {
            // Adiciona o hóspede ao contexto do banco de dados
            _context.Hospedes.Add(hospede);

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Retorna uma resposta que inclui o local do novo hóspede
            return CreatedAtAction(nameof(GetHospede), new { id = hospede.Id }, hospede);
        }

        // PUT: api/hospedes/{id}
        // Este método permite atualizar os dados de um hóspede existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospede(int id, Hospede hospede)
        {
            // Verifica se o ID passado na URL corresponde ao ID do hóspede
            if (id != hospede.Id)
            {
                return BadRequest();  // Retorna um erro 400 (bad request) se os IDs não coincidirem
            }

            // Atualiza o hóspede no banco de dados
            _context.Entry(hospede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();  // Salva as alterações
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Hospedes.Any(e => e.Id == id))
                {
                    return NotFound();  // Retorna erro 404 se o hóspede não for encontrado
                }
                else
                {
                    throw;  // Caso contrário, lança a exceção
                }
            }

            return NoContent();  // Retorna 204 (No Content) após a atualização bem-sucedida
        }

        // DELETE: api/hospedes/{id}
        // Este método permite remover um hóspede pelo ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hospede>> DeleteHospede(int id)
        {
            var hospede = await _context.Hospedes.FindAsync(id);

            if (hospede == null)
            {
                return NotFound();  // Retorna erro 404 se o hóspede não for encontrado
            }

            _context.Hospedes.Remove(hospede);  // Remove o hóspede do banco de dados
            await _context.SaveChangesAsync();  // Salva as alterações

            return hospede;  // Retorna o hóspede removido
        }
    }
}
