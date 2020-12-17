using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Autofac;
using Cars.API.Mappings;
using Cars.Repository;
using Cars.Service;
using Microsoft.OpenApi.Models;
using Cars.DAL;
using Microsoft.AspNetCore.Identity;

namespace Cars
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("Cars.DAL")));
            
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>();
            
            var mappingConfig = new MapperConfiguration(mc => 
            {
                mc.AddProfile(new ServiceMaps());
                mc.AddProfile(new ApiMaps());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddControllers();
            
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CarsAPI",
                    Description = "for Mono"
                });
                                
            });

            
        }    
        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterModule(new AutofacRepo());
            builder.RegisterModule(new AutofacService());
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseRouting();

            
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars API V1");
            });



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");                
            });           

        }
    }
}