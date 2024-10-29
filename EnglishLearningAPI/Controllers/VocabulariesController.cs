using EnglishLearningAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VocabulariesController : ControllerBase
{
    private readonly EnglishLearningDbContext _context;

    public VocabulariesController(EnglishLearningDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vocabulary>>> GetVocabularies()
    {
        return await _context.Vocabularies.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vocabulary>> GetVocabulary(int id)
    {
        var vocabulary = await _context.Vocabularies.FindAsync(id);

        if (vocabulary == null)
        {
            return NotFound();
        }

        return vocabulary;
    }

    [HttpPost]
    public async Task<ActionResult<Vocabulary>> CreateVocabulary(Vocabulary vocabulary)
    {
        _context.Vocabularies.Add(vocabulary);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVocabulary), new { id = vocabulary.vocab_id }, vocabulary);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVocabulary(int id, Vocabulary vocabulary)
    {
        if (id != vocabulary.vocab_id)
        {
            return BadRequest();
        }

        _context.Entry(vocabulary).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VocabularyExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVocabulary(int id)
    {
        var vocabulary = await _context.Vocabularies.FindAsync(id);
        if (vocabulary == null)
        {
            return NotFound();
        }

        _context.Vocabularies.Remove(vocabulary);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VocabularyExists(int id)
    {
        return _context.Vocabularies.Any(e => e.vocab_id == id);
    }
}
