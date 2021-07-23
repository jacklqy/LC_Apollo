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
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Cache.CacheManager;
using Ocelot.Cache;
using Zhaoxi.MicroService.GatewayDemo.OcelotExtend.CacheExtend;
using Ocelot.Provider.Polly;
using Zhaoxi.MicroService.GatewayDemo.OcelotExtend.AggregatorExtend;
using IdentityServer4.AccessTokenValidation;
using Ocelot.Administration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Zhaoxi.MicroService.GatewayDemo.OcelotExtend.MiddlewareExtend;

namespace Zhaoxi.MicroService.GatewayDemo
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
            //var authenticationProviderKey1 = "UserGatewayKey";
            //Action<IdentityServerAuthenticationOptions> configureOptions = options =>
            //{
            //    options.Authority = "http://localhost:7200";
            //    options.ApiName = "UserApi";
            //    options.RequireHttpsMetadata = false;
            //    options.SupportedTokens = SupportedTokens.Both;
            //};

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddIdentityServerAuthentication(authenticationProviderKey1, configureOptions);


            #region Ids4
            //var authenticationProviderKey = "UserGatewayKey";
            //services.AddAuthentication("Bearer")
            //   .AddIdentityServerAuthentication(authenticationProviderKey, options =>
            //   {
            //       options.Authority = "http://localhost:7200";
            //       options.ApiName = "UserApi";
            //       options.RequireHttpsMetadata = false;
            //       options.SupportedTokens = SupportedTokens.Both;
            //   });
            #endregion


            services.AddOcelot()
                .AddConsul()
                .AddCacheManager(x =>
                {
                    x.WithDictionaryHandle();//默认字典存储
                })
                .AddPolly()
                //.AddSingletonDefinedAggregator<CustomUserAggregator>()
                //.AddAdministration("/administration", configureOptions)
                ;

            #region 自定义缓存
            services.AddSingleton<IOcelotCache<CachedResponse>, CustomCacheExtend>();
            #endregion

            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            Console.WriteLine(this.Configuration["Remark"]);
            Console.WriteLine(this.Configuration["Routes"]);

            #region 管道事件扩展  复古式的 跟Asp.Net那套基于事件扩展的套路，下面这些就是IHttpModule
            var logger = loggerFactory.CreateLogger<Startup>();
            var configuration = new OcelotPipelineConfiguration
            {
                PreErrorResponderMiddleware = async (ctx, next) =>
                {
                    logger.LogWarning("This is Custom PreErrorResponderMiddleware....");
                    await next.Invoke();
                },
                PreAuthenticationMiddleware = async (ctx, next) =>
                {
                    logger.LogWarning("This is Custom PreAuthenticationMiddleware....");
                    await next.Invoke();
                },
                AuthenticationMiddleware = async (ctx, next) =>
                {
                    logger.LogWarning("This is Custom AuthenticationMiddleware....");
                    await next.Invoke();
                },
                PreAuthorisationMiddleware = async (ctx, next) =>
                {
                    logger.LogWarning("This is Custom PreAuthorisationMiddleware....");
                    await next.Invoke();
                },
                AuthorisationMiddleware = async (ctx, next) =>
                {
                    logger.LogWarning("This is Custom AuthorisationMiddleware....");
                    await next.Invoke();
                },
                PreQueryStringBuilderMiddleware = async (ctx, next) =>
                {
                    logger.LogWarning("This is Custom PreQueryStringBuilderMiddleware....");
                    await next.Invoke();
                }
            };
            //app.UseOcelot(configuration);
            app.UseOcelotEleven(configuration).Wait();
            #endregion


            //app.UseOcelot();//要有光--中间件

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
