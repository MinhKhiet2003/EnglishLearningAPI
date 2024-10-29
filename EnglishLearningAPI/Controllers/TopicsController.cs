using EnglishLearningAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TopicsController : ControllerBase
{
    private readonly EnglishLearningDbContext _context;

    public TopicsController(EnglishLearningDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Topic>>> GetTopics()
    {
        return await _context.Topics.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Topic>> GetTopic(int id)
    {
        var topic = await _context.Topics.FindAsync(id);

        if (topic == null)
        {
            return NotFound();
        }

        return topic;
    }

    [HttpPost]
    public async Task<ActionResult<Topic>> CreateTopic(Topic topic)
    {
        _context.Topics.Add(topic);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTopic), new { id = topic.topic_id }, topic);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTopic(int id, Topic topic)
    {
        if (id != topic.topic_id)
        {
            return BadRequest();
        }

        _context.Entry(topic).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TopicExists(id))
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
    public async Task<IActionResult> DeleteTopic(int id)
    {
        var topic = await _context.Topics.FindAsync(id);
        if (topic == null)
        {
            return NotFound();
        }

        _context.Topics.Remove(topic);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TopicExists(int id)
    {
        return _context.Topics.Any(e => e.topic_id == id);
    }
}
