using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PresentationAPILayer
{
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
            //services.AddIdentity<IUserService, IUserRoleService>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddClaimsPrincipalFactory<ConfigurationFactory>();
            services.AddCors();
            services.AddMemoryCache();

            services.AddSingleton<IConfigurationFactory>(new ConfigurationFactory(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAirlineRepository, AirlineRepository>();
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped<IAirplaneSchemaRepository, AirplaneSchemaRepository>();
            services.AddScoped<IAirplaneSubTypeRepository, AirplaneSubTypeRepository>();
            services.AddScoped<IAirplaneTypeRepository, AirplaneTypeRepository>();
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IClassTypeRepository, ClassTypeRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IPassengerSeatRepository, PassengerSeatRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IUserPasswordRepository, UserPasswordRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddScoped<IAirlineService, AirlineService>();
            services.AddScoped<IAirplaneService, AirplaneService>();
            services.AddScoped<IAirplaneSchemaService, AirplaneSchemaService>();
            services.AddScoped<IAirplaneSubTypeService, AirplaneSubTypeService>();
            services.AddScoped<IAirplaneTypeService, AirplaneTypeService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IClassTypeService, ClassTypeService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IDocumentTypeService, DocumentTypeService>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IPassengerSeatService, PassengerSeatService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                });
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
