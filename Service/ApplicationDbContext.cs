using Microsoft.EntityFrameworkCore;
using ProjetDotNet.Models.Entities;

namespace ProjetDotNet.Service
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
