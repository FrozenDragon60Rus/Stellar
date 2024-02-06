using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Domain
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<ServiceItem> ServiceItems { get; set; }
		public DbSet<TextField> TextFields { get; set; }

		private Guid roleGuid = new Guid("9538d32c-93ef-4b5d-9fad-9edb5763e936");
		private Guid userGuid = new Guid("e360f027-6ddf-4a22-a40a-11ca38551f65");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = roleGuid.ToString(),
				Name = "admin",
				NormalizedName = "ADMIN"
			});

			modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = userGuid.ToString(),
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password"),
				SecurityStamp = string.Empty
			});

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = roleGuid.ToString(),
				UserId = userGuid.ToString()
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("182808c5-a391-4119-901a-19ae51c297fd"),
				CodeWord = "PageIndex",
				Title = "Глвная"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("9abb5bb5-c00f-4f0a-b586-1c5629b5d268"),
				CodeWord = "PageServices",
				Title = "Наши услуги"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("831014fa-973f-49b0-a409-7120910f153f"),
				CodeWord = "PageContacts",
				Title = "Контакты"
			});
		}
	}
}
