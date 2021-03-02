using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        //constructor injection
        public Startup(IConfiguration config)
        {
            //config is an injected service
            //an object of type IConfiguration was injected into the constructor
            _config = config;
            

        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //adding all the required MVC services to the dependency injection container
            services.AddMvcCore();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // The value of env is coming from launchSettings.json
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILogger<Startup> logger)
        {
            //checks in launchsettings.json as to what the environment is and if it is 
            //development 
            if (env.IsDevelopment())
            {
                //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                //{
                //    SourceCodeLineCount = 5

                //};

                //app.UseDeveloperExceptionPage(developerExceptionPageOptions);
                app.UseDeveloperExceptionPage();
            }
            //else if(env.IsEnvironment("CUSTOM") || env.IsStaging() | env.IsProduction())
            //{
            //    app.UseDeveloperExceptionPage("/Error"); 
            //}

            #region addingothermiddleware
            //app.Use(async (context , next) =>
            //{
            //    //The context parameter passed in is actually, in its base an HttpContext type object
            //    //gives which host we are running on
            //    //await context.Response.WriteAsync(context.Request.Host.Port.ToString());
            //    logger.LogInformation("MW1: Incoming Request");
            //    await next();
            //    logger.LogInformation("MW1: Outgoing Response");
            //});


            //app.Use(async (context, next) =>
            //{
            //    //The context parameter passed in is actually, in its base an HttpContext type object
            //    //gives which host we are running on
            //    //await context.Response.WriteAsync(context.Request.Host.Port.ToString());
            //    logger.LogInformation("MW2: Incoming Request");
            //    await next();
            //    logger.LogInformation("MW3: Outgoing Response");
            //});
            #endregion

            #region directing to one defaultfileoption
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseDefaultFiles(defaultFilesOptions);
            //app.UseStaticFiles();
            #endregion

            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("hi.html");
            //app.UseFileServer(fileServerOptions);

            //app.UseDefaultFiles();
            //Use Static Files is put before UserMvcWithDefaultRoute because if
            //there is a request for a static file, the UseStaticFiles will complete this 
            //and short circuit the middleware. 
            app.UseStaticFiles();
            //If we go to the definition of UseMvcWithDefaultRoute, the route requires
            //a controller, action
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                //The context parameter passed in is actually, in its base an HttpContext type object
                //gives which host we are running on
                //throw new Exception("Error Processing");
                //await context.Response.WriteAsync(context.Request.Host.Port.ToString());
                //logger.LogInformation("Request Handled");
                await context.Response.WriteAsync("Hello World");


            });

            
        }
    }
}
