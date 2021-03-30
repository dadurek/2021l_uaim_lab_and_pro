namespace ExaminationRooms.Web
{
    using Application;
    using Domain.ExaminationRoomAggregate;
    using EntityFramework;
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Web.Application.Configuration;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ExaminationRooms.Web", Version = "v1"});
            });
            services.AddScoped<IExaminationRoomsRepository, ExaminationRoomsRepository>();
            services.AddTransient<IExaminationRoomQueriesHandler, ExaminationRoomQueriesHandler>();

            services.AddDbContext<ExaminationRoomContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("MyConnection")); //connection string in appsettings.json
            });
            
            var config = Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
            services.AddSingleton(config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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