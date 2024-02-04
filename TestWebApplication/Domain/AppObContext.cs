using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Domain
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<TextField> TextFields { get; set; }
		public DbSet<ServiceItem> ServiceItems { get; set; }

		private Guid roleGuid = Guid.NewGuid();
		private Guid userGuid = Guid.NewGuid();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = roleGuid.ToString(),
				Name = "admin",
				NormalizedName = "ADMIN"
			});

			modelBuilder.Entity<IdentityRole>().HasData(new IdentityUser
			{
				Id = userGuid.ToString(),
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password")
			});

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = roleGuid.ToString(),
				UserId = userGuid.ToString()
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = Guid.NewGuid(),
				CodeWord = "PageIndex",
				Title = "Глвная"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = Guid.NewGuid(),
				CodeWord = "PageServices",
				Title = "Наши услуги"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = Guid.NewGuid(),
				CodeWord = "PageContacts",
				Title = "Контакты"
			});
		}
	}
}
