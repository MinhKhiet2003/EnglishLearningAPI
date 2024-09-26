using EnglishLearningAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EnglishLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EnglishLearningContext _context;

        public  UserController(EnglishLearningContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);   
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }


        [HttpPut("{id}")]
        public IActionResult EditUser(int id , [FromBody] User user)
        {
            var userEdit = _context.Users.Find(id);
            if (userEdit == null)
            {
                return NotFound();
            }
            userEdit.subscription_plan = user.subscription_plan;
            userEdit.email = user.email;
            userEdit.password = user.password;
            _context.SaveChanges();

            return Ok(userEdit);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }

    }
}
