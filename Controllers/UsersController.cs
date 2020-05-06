using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChimeraInterview.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChimeraInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.Include(u => u.Scores).ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _context.Entry(user).Collection(u => u.Scores).LoadAsync();

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // POST: api/Users/gamer/Scores
        [HttpPost("{username}/Scores")]
        public async Task<ActionResult<User>> PostScore(string username, Score score)
        {
            // Should be SingleOrDefault but at this time we are not enforcing the uniqueness of the username
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return NotFound();
            }


            score.User = user;
            _context.Scores.Add(score);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
