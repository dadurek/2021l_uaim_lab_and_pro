namespace ExaminationRoomsSelectorApp.Web
{
    using Application.Configuration;
    using Application.DataServiceClients;
    using Application.Queries;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ExaminationRoomSelector.Web", Version = "v1"});
            });
            services.AddHttpClient();
            services.AddTransient<IExaminationRoomsSelectorHandler, ExaminationRoomsSelectorQueryHandler>();
            services.AddTransient<IExaminationRoomsServiceClient, ExaminationRoomsServiceClient>();
            services.AddTransient<IDoctorsServiceClient, DoctorsServiceClient>();

            var config = Configuration.GetSection("ServiceConfiguration").Get<ServiceConfiguration>();
            services.AddSingleton(config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LaboratoriesInventory.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}