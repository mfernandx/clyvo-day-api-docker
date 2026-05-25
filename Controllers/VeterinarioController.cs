using ClyvoDayApiDocker.Data;
using ClyvoDayApiDocker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApiDocker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeterinarioController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinario>>> GetAll()
        {
            var veterinarios = await _context.Veterinarios.Include(v => v.Clinica).ToListAsync();

            return Ok(veterinarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinario>> GetById(int id)
        {
            var veterinario = await _context.Veterinarios.Include(v => v.Clinica).FirstOrDefaultAsync(v => v.VeterinarioId == id);

            if (veterinario == null)
                return NotFound("Veterinário não encontrado.");

            return Ok(veterinario);
        }


        [HttpGet("clinica/{clinicaId}")]
        public async Task<ActionResult<IEnumerable<Veterinario>>> GetByClinicaId(int clinicaId)
        {
            var veterinarios = await _context.Veterinarios.Where(v => v.ClinicaId == clinicaId).ToListAsync();

            return Ok(veterinarios);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Veterinario newVeterinario)
        {
            var clinica = await _context.Clinicas.FindAsync(newVeterinario.ClinicaId);

            if (clinica == null)
                return NotFound("Clínica não encontrada.");

            _context.Veterinarios.Add(newVeterinario);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newVeterinario.VeterinarioId }, newVeterinario);
        }


        [HttpPut("{id}/atualizacontato")]
        public async Task<ActionResult> UpdateContact(int id, [FromBody] Veterinario updatedVeterinario)
        {
            var veterinario = await _context.Veterinarios.FindAsync(id);

            if (veterinario == null)
                return NotFound("Veterinário não encontrado.");

            veterinario.UpdateContact(updatedVeterinario.Email, updatedVeterinario.PhoneNumber);

            await _context.SaveChangesAsync();

            return Ok(veterinario);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var veterinario = await _context.Veterinarios.FindAsync(id);

            if (veterinario == null)
                return NotFound("Veterinário não encontrado.");

            _context.Veterinarios.Remove(veterinario);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}