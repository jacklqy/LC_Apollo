using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Grpc.Net.ClientFactory;
using Zhaoxi.gRPCDemo.LessonServer;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Zhaoxi.AgilityFramework.ConsulClientExtend;

namespace Zhaoxi.Microservice.AdvancedDemo
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
            services.AddControllersWithViews();

            #region gRPC
            AppContext.SetSwitch(
  "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            services.AddGrpcClient<ZhaoxiLesson.ZhaoxiLessonClient>(options =>
            {
                options.Address = new Uri("http://localhost:7000");
                //options.Address = new Uri("https://localhost:6001");
                //options.Interceptors.Add(new CustomClientLoggerInterceptor());
            }).ConfigureChannel(grpcOptions =>
            {
                //var callCredentials = CallCredentials.FromInterceptor(async (context, metadata) =>
                //{
                //    string token = JWTTokenHelper.GetJWTToken().Result;//即时获取的--加一层缓存
                //    Console.WriteLine($"token:{token}");
                //    metadata.Add("Authorization", $"Bearer {token}");
                //});
                //grpcOptions.Credentials = ChannelCredentials.Create(new SslCredentials(), callCredentials);
                ////请求都带上token，也可以在调用方法时传递： var replyPlus = await client.PlusAsync(requestPara, headers);
            });
            #endregion

            #region 注册调度策略
            services.AddSingleton<IConsulDispatcher, WeightDispatcher>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
