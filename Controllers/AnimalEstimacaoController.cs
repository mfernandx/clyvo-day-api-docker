using ClyvoDayApiDocker.Models;
using ClyvoDayApiDocker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApiDocker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalEstimacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnimalEstimacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var animaisEstimacao = await _context.AnimaisEstimacao.ToListAsync();

            if (animaisEstimacao == null)
                return NotFound();

            return Ok(animaisEstimacao);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var animalEstimacao = await _context.AnimaisEstimacao.FindAsync(id);

            if (animalEstimacao == null)
                return NotFound();

            return Ok(animalEstimacao);
        }


        [HttpPost]
        public async Task<ActionResult> Create(AnimalEstimacao newAnimalEstimacao)
        {
            var animaisEstimacao = new AnimalEstimacao(newAnimalEstimacao.Name, newAnimalEstimacao.Species, newAnimalEstimacao.Breed, newAnimalEstimacao.Gender, newAnimalEstimacao.Age, newAnimalEstimacao.Weight, newAnimalEstimacao.BirthDate, newAnimalEstimacao.TutoresId);

            _context.AnimaisEstimacao.Add(animaisEstimacao);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = animaisEstimacao.AnimalEstimacaoId }, animaisEstimacao);
        }


        [HttpPut("{id}/atualizapeso")]
        public async Task<ActionResult> UpdateWeight(int id, [FromBody] decimal newWeight)
        {
            var animalEstimacao = await _context.AnimaisEstimacao.FindAsync(id);

            if (animalEstimacao == null)
                return NotFound("Pet não encontrado.");

            animalEstimacao.UpdateWeight(newWeight);

            await _context.SaveChangesAsync();

            return Ok(animalEstimacao);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var animalEstimacao = await _context.AnimaisEstimacao.FindAsync(id);

            if (animalEstimacao == null)
                return NotFound("Pet não encontrado.");

            _context.AnimaisEstimacao.Remove(animalEstimacao);

            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}

