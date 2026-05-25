using ClyvoDayApiDocker.Models;
using ClyvoDayApiDocker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApiDocker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TutoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutores>>> GetAll()
        {
            var tutores = await _context.Tutores.Include(t => t.AnimaisEstimacao).ToListAsync();
            return Ok(tutores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tutores>> GetById(int id)
        {
            var tutor = await _context.Tutores.Include(t => t.AnimaisEstimacao).FirstOrDefaultAsync(t => t.TutoresId == id);

            if (tutor == null)
                return NotFound();

            return Ok(tutor);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Tutores tutor)
        {
            _context.Tutores.Add(tutor);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = tutor.TutoresId }, tutor);
        }


        [HttpPut("{id}/atualizacontato")]
        public async Task<ActionResult> UpdateContact(int id, [FromBody] Tutores updatedContact)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
                return NotFound("Tutor não encontrado.");

            tutor.UpdateContact(updatedContact.Email, updatedContact.PhoneNumber);

            await _context.SaveChangesAsync();

            return Ok(tutor);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var tutor = await _context.Tutores.Include(t => t.AnimaisEstimacao).FirstOrDefaultAsync(t => t.TutoresId == id);

            if (tutor == null)
                return NotFound("Tutor não encontrado.");

            _context.Tutores.Remove(tutor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

