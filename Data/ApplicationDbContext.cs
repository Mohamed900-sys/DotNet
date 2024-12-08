using Microsoft.EntityFrameworkCore;
using ProjetDotNet.Models.Entities;

namespace ProjetDotNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }
        public DbSet <User> Users         { get; set; }
    }
}
