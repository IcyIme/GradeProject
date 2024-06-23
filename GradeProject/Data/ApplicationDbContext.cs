using GradeProject.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GradeProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // DbSet for your custom entity

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Other DbSet declarations can also be added here if needed
        public DbSet<ForumRoom> ForumRooms { get; set; }
        public DbSet<ForumComment> ForumComments { get; set; } 
    }
}
