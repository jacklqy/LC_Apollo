using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Core;
using Com.Ctrip.Framework.Apollo.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace Zhaoxi.MicroService.GatewayDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             //.ConfigureAppConfiguration(configurationBuilder =>
             //{
             //    configurationBuilder.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
             //})
             .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
             {
                 configurationBuilder.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);

                 //注入配置 把阿波罗的日志级别调整为最低
                 LogManager.UseConsoleLogging(Com.Ctrip.Framework.Apollo.Logging.LogLevel.Trace);
                 configurationBuilder
                     .AddApollo(configurationBuilder.Build().GetSection("apollo"))
                     .AddDefault()
                  .AddNamespace(ConfigConsts.NamespaceApplication);
                 ;//Apollo中NameSpace的名称
             })
              .ConfigureLogging((context, loggingBuilder) =>
              {
                  //loggingBuilder.AddFilter("System", LogLevel.Warning);//过滤掉命名空间
                  //loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                  //loggingBuilder.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.Warning);
                  //loggingBuilder.AddFilter("Ocelot.Logging.OcelotDiagnosticListener", LogLevel.Warning);
                  //loggingBuilder.AddFilter("Ocelot.Authorisation.Middleware.AuthorisationMiddleware", LogLevel.Warning);
                  loggingBuilder.AddLog4Net();//使用log4net
              })//扩展日志
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             });
    }
}
