using Microsoft.EntityFrameworkCore;
using tuwiq.Data;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Identity;
using tuwiq.Areas.Identity.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

		builder.Services.AddDbContext<CatUserContext>(options =>
		{
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
		});

		builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

		builder.Services.AddDefaultIdentity<CatUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CatUserContext>();
		builder.Services.AddRazorPages();// added
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

        app.UseAuthorization();
        app.MapRazorPages();//added
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=dashboard}/{action=Index}/{id?}");

        app.Run();
        
    }
}
