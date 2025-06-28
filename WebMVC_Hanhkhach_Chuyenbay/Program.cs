using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebMVC_Hanhkhach_Chuyenbay.Data;
namespace WebMVC_GiaoVien_LichGiangDay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebMVC_Hanhkhach_ChuyenbayContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WebMVC_GiaoVien_LichGiangDayContext") ?? throw new InvalidOperationException("Connection string 'WebMVC_GiaoVien_LichGiangDayContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}