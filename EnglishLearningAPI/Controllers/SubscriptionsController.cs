using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EnglishLearningAPI.Data;
using Microsoft.EntityFrameworkCore;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : ControllerBase
{
    private readonly EnglishLearningDbContext _context;

    public SubscriptionsController(EnglishLearningDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptions()
    {
        return await _context.Subscriptions.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Subscription>> GetSubscription(int id)
    {
        var subscription = await _context.Subscriptions.FindAsync(id);

        if (subscription == null)
        {
            return NotFound();
        }

        return subscription;
    }

    [HttpPost]
    public async Task<ActionResult<Subscription>> CreateSubscription(Subscription subscription)
    {
        _context.Subscriptions.Add(subscription);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSubscription), new { id = subscription.subscription_id }, subscription);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubscription(int id, Subscription subscription)
    {
        if (id != subscription.subscription_id)
        {
            return BadRequest();
        }

        _context.Entry(subscription).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SubscriptionExists(id))
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
    public async Task<IActionResult> DeleteSubscription(int id)
    {
        var subscription = await _context.Subscriptions.FindAsync(id);
        if (subscription == null)
        {
            return NotFound();
        }

        _context.Subscriptions.Remove(subscription);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SubscriptionExists(int id)
    {
        return _context.Subscriptions.Any(e => e.subscription_id == id);
    }
}
