using Identity.API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RepositoryLayer.IdentityDBContext;
using ServiceLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using ServiceLayer.Validations;
using CoreLayer.Interfaces.UnitOfWork;
using RepositoryLayer.UnitOfWork;
using CoreLayer.Interfaces.Service;
using ServiceLayer.Services;
using CoreLayer.Interfaces.Repository;
using RepositoryLayer.Repositories;
using CoreLayer.Interfaces.Repository.HerbRepository;
using CoreLayer.Interfaces.Service.Herb;

namespace Identity.API
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

            services.AddControllers(opt => opt.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserValidator>());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddDbContext<RepositoryLayer.IdentityDBContext.DbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("Project")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GeneralRepository<>));
            services.AddScoped<IHerbRepository, HerbRepository>();
            services.AddScoped<IHerbService, HerbService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSites",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:14541").AllowAnyHeader().AllowAnyMethod();
                    });
            });
                services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity.App", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity.App v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
