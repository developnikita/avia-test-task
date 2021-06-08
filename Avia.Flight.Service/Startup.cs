using Avia.Flight.Service.Entities;
using Avia.Flight.Service.Models;
using Avia.Flight.Service.Models.Extensions;
using Avia.Flight.Service.Repositories;
using Avia.Flight.Service.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Avia.Flight.Service
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
            services.AddSingleton<IReadOnlyRepository<FlightInfo>>(serviceProvider =>
            {
                var csvFileLocation = Configuration.GetSection(nameof(CsvFileLocationSettings)).Get<CsvFileLocationSettings>();
                return new CsvRepository<FlightInfoCsv, FlightInfo>(csvFileLocation.FileLocation, FlightExtension.AsEntity);
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Avia.Flight.Service", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Avia.Flight.Service v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
