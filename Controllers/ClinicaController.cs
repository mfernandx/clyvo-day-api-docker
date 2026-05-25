using ClyvoDayApiDocker.Data;
using ClyvoDayApiDocker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApiDocker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClinicaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinica>>> GetAll()
        {
            var clinicas = await _context.Clinicas.Include(c => c.Veterinarios).ToListAsync();

            return Ok(clinicas);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Clinica>> GetById(int id)
        {
            var clinica = await _context.Clinicas.Include(c => c.Veterinarios).FirstOrDefaultAsync(c => c.ClinicaId == id);

            if (clinica == null)
                return NotFound("Clínica não encontrada.");

            return Ok(clinica);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Clinica newClinica)
        {
            _context.Clinicas.Add(newClinica);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newClinica.ClinicaId }, newClinica);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var clinica = await _context.Clinicas.Include(c => c.Veterinarios).FirstOrDefaultAsync(c => c.ClinicaId == id);

            if (clinica == null)
                return NotFound("Clínica não encontrada.");

            _context.Clinicas.Remove(clinica);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

