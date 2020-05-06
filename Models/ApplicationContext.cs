using Microsoft.EntityFrameworkCore;

namespace ChimeraInterview.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}