using DesafionMetatron.Domain;
using Microsoft.EntityFrameworkCore;

namespace DesafioMetatron.Infra.DataBase
{
	public class MetatronContext : DbContext
	{
		private string strConn { get; set; }

		public DbSet<Usuario> Usuario { get; set; }
		public DbSet<Categoria> Categoria { get; set; }
		public DbSet<Lista> Lista { get; set; }
		public DbSet<Tarefa> Tarefa { get; set; }

		public MetatronContext(DbContextOptions<MetatronContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
			modelBuilder.Entity<Categoria>().HasKey(x => x.Id);
			modelBuilder.Entity<Lista>().HasKey(x => x.Id);
			modelBuilder.Entity<Tarefa>().HasKey(x => x.Id);

		}
	}
}
