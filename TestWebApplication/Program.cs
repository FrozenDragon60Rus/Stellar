using Microsoft.EntityFrameworkCore;
using TestWebApplication.Domain;
using TestWebApplication.Service;
using TestWebApplication.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using TestWebApplication.Domain.Repositories.EntityFramework;
using TestWebApplication.Areas.Admin;

var builder = WebApplication.CreateBuilder(args);

#region Services

var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

TestWebApplication.Configuration.Bind(ref builder, [new Config()]);

services.AddTransient<ITextFieldRepository, EFTextFieldRepository>();
services.AddTransient<IServiceItemRepository, EFServiceItemRepository>();
services.AddTransient<DataManager>();

services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
	options.User.RequireUniqueEmail = true;
	options.Password.RequiredLength = 6;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>()
  .AddDefaultTokenProviders();

services.ConfigureApplicationCookie(options =>
{
	options.Cookie.Name = "StelareAuthorization";
	options.Cookie.HttpOnly = true;
	options.LoginPath = "/account/login";
	options.AccessDeniedPath = "/account/accessdenied";
	options.SlidingExpiration = true;
});

services.AddAuthorizationBuilder()
		.AddPolicy("AdminArea", policy => policy.RequireRole("admin"));

services.AddControllersWithViews(x =>
	x.Conventions.Add(new AdminAreaAutorization("Admin", "AdminArea"))
).AddSessionStateTempDataProvider();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area=exists}/{controller=Admin}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
