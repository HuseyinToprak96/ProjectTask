using CoreLayer.Entities.UserEntity;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Repository.HerbRepository;
using CoreLayer.Interfaces.Service;
using CoreLayer.Interfaces.Service.Herb;
using CoreLayer.Interfaces.UnitOfWork;
using Identity.Web.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepositoryLayer.Repositories;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Mapping;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpClient<HerbAPI>(opt =>
            {
                opt.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
            services.AddHttpClient<ComplaintAPI>(opt =>
            {
                opt.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddDbContext<RepositoryLayer.IdentityDBContext.DbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("Project")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GeneralRepository<>));
            services.AddScoped<IHerbRepository, HerbRepository>();
            services.AddScoped<IHerbService, HerbService>();
            services.AddAutoMapper(typeof(MapperProfile));

            CookieBuilder cookieBuilder = new CookieBuilder();
            cookieBuilder.Name = "MyCookie";
            cookieBuilder.HttpOnly = false;
          //  cookieBuilder.Expiration = System.TimeSpan.FromDays(60);
            cookieBuilder.SameSite = SameSiteMode.Lax;
            cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;

            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = new PathString("/Login/Index");
                // opts.LogoutPath=new PathString("/Login/Index");
                opts.Cookie = cookieBuilder;
                opts.SlidingExpiration = true;

            });
            services.AddIdentity<UserApp, IdentityRole>().AddEntityFrameworkStores<RepositoryLayer.IdentityDBContext.DbContext>();
            services.AddDataProtection();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaDefault",
                    pattern: "{area:exists}/{controller=Herbs}/{action=List}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
