using ClyvoDayApiDocker.Models;
using ClyvoDayApiDocker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApiDocker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoramentoAnimalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MonitoramentoAnimalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonitoramentoAnimal>>> GetAll()
        {
            var monitoramentos = await _context.Monitoramentos.Include(m => m.AnimalEstimacao).ToListAsync();

            return Ok(monitoramentos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MonitoramentoAnimal>> GetById(int id)
        {
            var monitoramento = await _context.Monitoramentos.Include(m => m.AnimalEstimacao).FirstOrDefaultAsync(m => m.MonitoramentoAnimalId == id);

            if (monitoramento == null)
                return NotFound();

            return Ok(monitoramento);
        }


        [HttpGet("pet/{animalEstimacaoId}")]
        public async Task<ActionResult<IEnumerable<MonitoramentoAnimal>>> GetByAnimalId(int animalEstimacaoId)
        {
            var monitoramentos = await _context.Monitoramentos.Where(m => m.AnimalEstimacaoId == animalEstimacaoId).ToListAsync();

            return Ok(monitoramentos);
        }



        [HttpPost]
        public async Task<ActionResult> Create(MonitoramentoAnimal newMonitoramento)
        {
            var animalEstimacao = await _context.AnimaisEstimacao.FindAsync(newMonitoramento.AnimalEstimacaoId);

            if (animalEstimacao == null)
                return NotFound("Pet não encontrado.");

            _context.Monitoramentos.Add(newMonitoramento);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newMonitoramento.MonitoramentoAnimalId }, newMonitoramento);
        }

    }
}

