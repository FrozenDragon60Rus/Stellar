using Microsoft.EntityFrameworkCore;
using TestWebApplication.Domain;
using TestWebApplication.Service;
using TestWebApplication.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TestWebApplication.Domain.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

#region Services

var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

new TestWebApplication.BindConfiguration(ref builder, [new Config()]);

services.AddTransient<IRepository, EFRepository>();
services.AddTransient<ITextFieldRepository, EFRepository>();
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
	options.LoginPath = "/admin";
	options.AccessDeniedPath = "/access/accessdenied";
	options.SlidingExpiration = true;
});

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
