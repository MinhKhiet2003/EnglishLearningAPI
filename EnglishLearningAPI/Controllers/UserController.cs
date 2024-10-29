using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnglishLearningAPI.Data;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using EnglishLearningAPI.Dtos;

[Authorize(Roles = "Admin")] // Chỉ cho phép Admin truy cập controller này
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly EnglishLearningDbContext _context;

    public UsersController(EnglishLearningDbContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        return await _context.Users
            .Select(u => new UserDto
            {
                UserId = u.user_id,
                Email = u.email,
                Role = u.role
            })
            .ToListAsync();
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        var user = await _context.Users
            .Where(u => u.user_id == id)
            .Select(u => new UserDto
            {
                UserId = u.user_id,
                Email = u.email,
                Role = u.role
            })
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<UserDto>> PostUser(User user)
    {
        // Kiểm tra xem email đã tồn tại chưa
        if (_context.Users.Any(u => u.email == user.email))
        {
            return Conflict("Email đã tồn tại.");
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Trả về UserDto sau khi tạo thành công
        var userDto = new UserDto
        {
            UserId = user.user_id,
            Email = user.email,
            Role = user.role
        };

        return CreatedAtAction("GetUser", new { id = user.user_id }, userDto);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, UserDto userDto)
    {
        if (id != userDto.UserId)
        {
            return BadRequest();
        }

        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        // Cập nhật thông tin người dùng
        user.role = userDto.Role;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
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

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok("Người dùng đã được xóa thành công.");
    }

    private bool UserExists(int id)
    {
        return _context.Users.Any(e => e.user_id == id);
    }
}
