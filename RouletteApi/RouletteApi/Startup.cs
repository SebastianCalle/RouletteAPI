using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using RouletteApi.Data;
using RouletteApi.Validations;
using System;
using System.IO;
using System.Reflection;

namespace RouletteApi
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
            services.AddControllers();

            // Connect with the Database
            services.AddDbContext<RouletteApiContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("RouletteApi"))
            );

            // Solve dependency injection
            services.AddScoped<IRouletteRepository, MockRouletteRepository>();
            services.AddScoped<IBetRepository, MockBetRepository>();

            // Mapper Models to DTO's
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Serialization for PATCH
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            // Validation with fluetnValidation
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BetCreateValidation>());

            // Swagger Documentation
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Documentation Roulette Game Api",
                    Version = "v1",
                    Description = "REST API  for the Roulette game by: SebastianCalle",
                    Contact = new OpenApiContact()
                    {
                        Name = "Sebastian Calle",
                        Email = "jusemonca@gmail.com"
                    }

                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Roulette Game Api V1");
            });



        }
    }
}
