using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Zhaoxi.AgilityFramework.ConsulClientExtend;
using Zhaoxi.MicroService.ServiceInstance.Utility;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using IGeekFan.AspNetCore.Knife4jUI;
using System.IO;

namespace Zhaoxi.Microservice.WebApiDemo
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
            services.AddControllers();
            services.AddTransient<IConsulIDistributed, ConsulIDistributed>();


            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SwaggerDemo.xml"), true);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API V1", Version = "v1" });
                c.AddServer(new OpenApiServer()
                {
                    Url = "",
                    Description = "vvv"
                });
                c.CustomOperationIds(apiDesc =>
                {
                    var controllerAction = apiDesc.ActionDescriptor as ControllerActionDescriptor;
                    return controllerAction.ControllerName + "-" + controllerAction.ActionName;
                });
            });


            #region IdentityServer4--Client
            //services.AddAuthentication("Bearer")//告诉token从哪里获取
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = "http://localhost:7200";//ids4的地址-拿公钥
            //        options.ApiName = "UserApi";
            //        options.RequireHttpsMetadata = false;
            //    });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("eMailPolicy",
            //        policyBuilder => policyBuilder
            //        .RequireAssertion(context =>
            //        context.User.HasClaim(c => c.Type == "client_eMail")
            //        && context.User.Claims.First(c => c.Type.Equals("client_eMail")).Value.EndsWith("@qq.com")));//Client
            //});
            #endregion

            #region Options

            services.Configure<EmailOption>(op => op.Title = "services.Configure<EmailOption>--DefaultName");//默认--名称empty
            services.Configure<EmailOption>("FromMemory", op => op.Title = "services.Configure<EmailOption>---FromMemory");//指定名称,程序里面配置

            services.Configure<EmailOption>("FromConfiguration", Configuration.GetSection("Email"));//从配置文件读取
            services.Configure<EmailOption>("FromConfigurationNew", Configuration.GetSection("EmailNew"));//从配置文件读取

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine(this.Configuration["Email"]);
            Console.WriteLine(this.Configuration["EmailNew"]);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();

            app.UseKnife4UI(c =>
            {
                c.RoutePrefix = ""; // serve the UI at root
                c.SwaggerEndpoint("/v1/api-docs", "V1 Docs");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger("{documentName}/api-docs");
            });



            #region MyRegion
            //this.Configuration.ConsulRegist();
            #endregion
        }
    }
}
