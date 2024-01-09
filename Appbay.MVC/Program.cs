using Appbay.Core.Models;
using Appbay.DAL.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Appbay.MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
			});

			builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
			{
				opt.Password.RequiredLength = 8;
				opt.Password.RequireNonAlphanumeric = true;
				opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(3);
				opt.Lockout.MaxFailedAccessAttempts = 3;

			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
			var app = builder.Build();


			app.MapControllerRoute(
				name: "areas",
				pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

			app.MapControllerRoute(
				 name: "default",
				 pattern: "{controller=Home}/{action=Index}/{id?}");

			app.UseStaticFiles();
			app.Run();
		}
	}
}