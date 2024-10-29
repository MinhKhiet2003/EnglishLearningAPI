using EnglishLearningAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly EnglishLearningDbContext _context;

    public PaymentsController(EnglishLearningDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
    {
        return await _context.Payments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Payment>> GetPayment(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment == null)
        {
            return NotFound();
        }

        return payment;
    }

    [HttpPost]
    public async Task<ActionResult<Payment>> CreatePayment(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPayment), new { id = payment.payment_id }, payment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment(int id, Payment payment)
    {
        if (id != payment.payment_id)
        {
            return BadRequest();
        }

        _context.Entry(payment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PaymentExists(id))
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
    public async Task<IActionResult> DeletePayment(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null)
        {
            return NotFound();
        }

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PaymentExists(int id)
    {
        return _context.Payments.Any(e => e.payment_id == id);
    }
}
