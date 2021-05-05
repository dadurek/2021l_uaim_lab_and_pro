namespace ExaminationRooms
{
    using Application.Queries;
    using Infrastructure.EntityFramework;
    using Infrastructure.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ExaminationRoomsData.Web.Web", Version = "v1"});
            });
            services.AddScoped<IExaminationRoomsRepository, ExaminationRoomsRepository>();
            services.AddTransient<IExaminationRoomQueriesHandler, ExaminationRoomQueriesHandler>();

            services.AddDbContext<ExaminationRoomContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("MyConnection")); //connection string in appsettings.json
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Laboratories.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}