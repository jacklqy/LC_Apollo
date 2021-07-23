using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NConsul;
using NConsul.AspNetCore;
using Zhaoxi.AgilityFramework.ConsulService;

namespace Zhaoxi.gRPCDemo.RecordServer
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
            services.AddGrpc();

            //services.AddConsul("http://localhost:8500")
            //        .AddGRPCHealthCheck("localhost:7001")
            //        .RegisterService("RecordService", "localhost", 7001, new[] { "123" }); //晓晨master-李志强
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGrpcService<StudyRecordService>();
                endpoints.MapGrpcService<HealthCheckService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });

            #region MyRegion
            app.UseGRPCConsul(new ConsulConfigModel() { IP = "127.0.0.1", Port = 8500 },
               new HealthConfigModel() { IP = this.Configuration["ip"], GroupName = "RecordService", Port = int.Parse(this.Configuration["port"]), Tag = new string[] { this.Configuration["weight"] }, CheckPort = int.Parse(this.Configuration["port"]) }
               );//CheckPort和Port是一个
            #endregion
        }
    }
}
