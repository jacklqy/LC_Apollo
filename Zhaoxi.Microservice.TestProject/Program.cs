using Microsoft.Extensions.Configuration;
using System;

namespace Zhaoxi.Microservice.TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                #region 命令行参数
                var builder = new ConfigurationBuilder()
                   .AddCommandLine(args);
                var configuration = builder.Build();
                string port = configuration["port"] ?? "8500";
                #endregion
                {
                    //JsonVSProtobuf.Show();
                }
                {
                    DistributedLockTest.Show(port);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
