using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalRServerExample.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServerExample
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt => opt.AddDefaultPolicy(policy =>
              policy.AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .SetIsOriginAllowed(origin=>true)
            )) ;
            services.AddSignalR(); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MyHub>("/myhub"); //myhub endpointine bir istek(bağlantı talebi) gelirse, buradaki hub tarafından karşılanır.
            });
        }
    }
}
