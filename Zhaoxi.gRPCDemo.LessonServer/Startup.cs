using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Zhaoxi.AgilityFramework.ConsulService;

namespace Zhaoxi.gRPCDemo.LessonServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();

            #region jwt校验  HS
            //JWTTokenOptions tokenOptions = new JWTTokenOptions();
            //this.Configuration.Bind("JWTTokenOptions", tokenOptions);

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//Scheme
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        //JWT有一些默认的属性，就是给鉴权时就可以筛选了
            //        ValidateIssuer = true,//是否验证Issuer
            //        ValidateAudience = true,//是否验证Audience
            //        ValidateLifetime = true,//是否验证失效时间
            //        ValidateIssuerSigningKey = true,//是否验证SecurityKey
            //        ValidAudience = tokenOptions.Audience,//
            //        ValidIssuer = tokenOptions.Issuer,//Issuer，这两项和前面签发jwt的设置一致
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),//拿到SecurityKey
            //        //AudienceValidator = (m, n, z) =>
            //        //{
            //        //    //等同于去扩展了下Audience的校验规则---鉴权
            //        //    return m != null && m.FirstOrDefault().Equals(this.Configuration["audience"]);
            //        //},
            //        //LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
            //        //{
            //        //    return notBefore <= DateTime.Now
            //        //    && expires >= DateTime.Now;
            //        //    //&& validationParameters
            //        //}//自定义校验规则
            //    };
            //});
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("grpcEMail", policyBuilder =>
            //    policyBuilder.RequireAssertion(context =>
            //       context.User.HasClaim(c => c.Type == "EMail")
            //       && context.User.Claims.First(c => c.Type.Equals("EMail")).Value.EndsWith("@qq.com")));
            //});
            #endregion

            #region 获取consul配置信息
            //其他信息也可以配置文件
            services.Configure<ConsulConfigModel>(Configuration.GetSection(nameof(ConsulConfigModel)));
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<ConsulConfigModel> consulService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region HealthCheck
            app.Map("/Health", applicationBuilder => applicationBuilder.Run(async context =>
              {
                  Console.WriteLine($"This is Health Check");
                  context.Response.StatusCode = (int)HttpStatusCode.OK;
                  await context.Response.WriteAsync("OK");
              }));
            #endregion

            app.UseRouting();

            #region MyRegion
            //app.UseAuthentication();
            //app.UseAuthorization();
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ZhaoxiLessonService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });

            #region Consul
            ////命令行参数必须传入  或者配置文件夹
            //string ip = this.Configuration["ip"];
            //int port = int.Parse(this.Configuration["port"]);
            //int weight = string.IsNullOrWhiteSpace(this.Configuration["weight"]) ? 1 : int.Parse(this.Configuration["weight"]);

            ////ConsulService consulService = new ConsulService()
            ////{
            ////    IP = ip,
            ////    Port = port
            ////};//注入进来

            //HealthService healthService = new HealthService()
            //{
            //    IP = ip,
            //    Port = port,
            //    Name = "LessonService",
            //    Tag = new string[] { weight.ToString() }
            //};
            //app.UseConsul(consulService.Value, healthService);

            //dotnet run --urls=https://*:6001 ip=127.0.0.1 port=6001 weight=1


            app.UseConsul(new ConsulConfigModel() { IP = "127.0.0.1", Port = 8500 },
                new HealthConfigModel() { IP = "127.0.0.1", GroupName = "LessonService", Port = int.Parse(this.Configuration["port"]), CheckPort = int.Parse(this.Configuration["checkport"]) }
                );
            #endregion

        }
    }
}
