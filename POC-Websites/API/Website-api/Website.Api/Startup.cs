using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Website.Api.Data;
using Website.Api.Interfaces;
using Website.Api.Logic;

namespace Website.Api
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
            services.AddMvc();

            services.AddSwaggerGen(s =>
           {
               s.SwaggerDoc("v1", new Info { Title = "Website.API", Version = "v0.01" });
           });

            //Dependency Injection
            services.AddTransient<IBase, FirebaseRepository>();
            services.AddTransient<WebsiteLogic, WebsiteLogic>();
            services.AddTransient<IWebsite, WebsiteRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Website.Api");
                s.DocumentTitle = "Website.Api";
                s.DocExpansion(DocExpansion.None);
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
