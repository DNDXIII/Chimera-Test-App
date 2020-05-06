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
    public class LeaderboardsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LeaderboardsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Leaderboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetLeaderboards()
        {
            // Get all users that have at least one Score
            List<User> users = await _context.Users.Include(u => u.Scores).Where(u => u.Scores.Count > 0).ToListAsync();

            // Sort the users based on their highest score
            List<User> leaderboard = users.OrderByDescending(u => u.Scores.OrderByDescending(s => s.FinalScore).First().FinalScore).ToList();
            return leaderboard;
        }


    }
}
