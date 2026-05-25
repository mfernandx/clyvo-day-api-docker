using ClyvoDayApiDocker.Data;
using ClyvoDayApiDocker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApiDocker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoCuidadoController : ControllerBase
    {

        private readonly AppDbContext _context;

        public EventoCuidadoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoCuidado>>> GetAll()
        {
            var eventos = await _context.Eventos.Include(e => e.AnimalEstimacao).ToListAsync();

            return Ok(eventos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EventoCuidado>> GetById(int id)
        {
            var eventoCuidado = await _context.Eventos.Include(e => e.AnimalEstimacao).FirstOrDefaultAsync(e => e.EventoCuidadoId == id);

            if (eventoCuidado == null)
                return NotFound("Evento não encontrado.");

            return Ok(eventoCuidado);
        }



        [HttpPost]
        public async Task<ActionResult> Create(EventoCuidado newEvento)
        {
            var animalEstimacao = await _context.AnimaisEstimacao.FindAsync(newEvento.AnimalEstimacaoId);

            if (animalEstimacao == null)
                return NotFound("Pet não encontrado.");

            _context.Eventos.Add(newEvento);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newEvento.EventoCuidadoId }, newEvento);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eventoCuidado = await _context.Eventos.FindAsync(id);

            if (eventoCuidado == null)
                return NotFound("Evento não encontrado.");

            _context.Eventos.Remove(eventoCuidado);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

