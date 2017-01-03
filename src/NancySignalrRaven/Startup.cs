using System;
using System.Collections.Generic;
using System.Linq;
using Nancy.Owin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Raven.Client;
using Raven.Client.Document;

namespace NancySignalrRaven
{
    public class Startup
    {
        IDocumentStore documentStore = new DocumentStore() { Url = "http://slbsqldev005v:8081/" , DefaultDatabase = "Chat" };
        public Startup()
        {
            documentStore.Initialize();
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(documentStore);
            services.AddSignalR(options => {
                options.Hubs.EnableDetailedErrors = true;
               
            });
           
        }

      
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSignalR();
            app.UseWebSockets();
            
            app.UseOwin(x => x.UseNancy(y => y.Bootstrapper = new MyBootStrapper(documentStore))); 
        }
    }
}
