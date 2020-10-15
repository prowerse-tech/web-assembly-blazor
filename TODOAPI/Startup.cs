using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using TODOAPI.Models;

namespace TODOAPI
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
          
           
            services.AddMvc().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            
            var connection = Configuration.GetConnectionString("ToDoDatabase");
            services.AddDbContext<Blazor_TodoDbContext>(options => options.UseSqlServer(connection));

            //services.AddScoped<IToDoAccessLayer, ToDoAccessLayer>();
            services.AddControllers();

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
            app.UseCors(methods => { methods.AllowAnyOrigin(); methods.AllowAnyMethod(); methods.AllowAnyHeader(); });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute(); 
            });
        }
    }
}
