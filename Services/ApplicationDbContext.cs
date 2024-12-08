using FitnessWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWebApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<Packs> Packs { get; set; }

	}
}
