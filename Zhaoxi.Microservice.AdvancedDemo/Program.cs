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

namespace Zhaoxi.Microservice.AdvancedDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
             {
                 //注入配置 把阿波罗的日志级别调整为最低
                 LogManager.UseConsoleLogging(Com.Ctrip.Framework.Apollo.Logging.LogLevel.Trace);
                 configurationBuilder
                     .AddApollo(configurationBuilder.Build().GetSection("apollo"))
                     .AddDefault()
                  .AddNamespace(ConfigConsts.NamespaceApplication);
                 ;//Apollo中NameSpace的名称
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
