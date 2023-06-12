using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAnaliz.BLL;
using MyAnaliz.BLL.Services;
using MyAnaliz.BLL.Services.IServices;
using MyAnaliz.DAL;
using MyAnaliz.DAL.Models.Response.Account;
using MyAnaliz.DAL.Repositories;
using MyAnaliz.DAL.Repositories.IRepositories;

namespace MyAnaliz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Connect AutoMapper
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            // Connect DataBase
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection))
                .AddIdentity<User, IdentityRole>(opts =>
                {
                    opts.Password.RequiredLength = 5;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                }).AddEntityFrameworkStores<AppDbContext>();

            // Services AddSingletons/Transient
            builder.Services
                .AddSingleton(mapper)
                .AddTransient<IAccountService, AccountService>()
                .AddTransient<IHomeService, HomeService>()
                .AddTransient<IEventService, EventService>()
                .AddTransient<ITransactionRepository, TransactionRepository>();

            // Start WebApplication
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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