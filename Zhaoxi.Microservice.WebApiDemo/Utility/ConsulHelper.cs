using Consul;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zhaoxi.MicroService.ServiceInstance.Utility
{
    public static class ConsulHelper
    {
        public static async void ConsulRegist(this IConfiguration configuration)
        {
            string ip = configuration["ip"];
            int port = int.Parse(configuration["port"]);
            int weight = string.IsNullOrWhiteSpace(configuration["weight"]) ? 1 : int.Parse(configuration["weight"]);
            using (ConsulClient client = new ConsulClient(c =>
             {
                 c.Address = new Uri(configuration["ConsulAddress"]);
                 c.Datacenter = configuration["ConsulCenter"];
             }))
            {
                await client.Agent.ServiceRegister(new AgentServiceRegistration()
                {
                    ID = "service " + ip + ":" + port,//Eleven  独一无二
                    Name = "ZhaoxiUserService",//分组---朝夕教育的老师
                    Address = ip,
                    Port = port,
                    Tags = new string[] { weight.ToString() },
                    Check = new AgentServiceCheck()
                    {
                        Interval = TimeSpan.FromSeconds(12),
                        HTTP = $"http://{ip}:{port}/Api/Health/Index",
                        Timeout = TimeSpan.FromSeconds(5),
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(20)
                    }
                });
                //命令行参数获取
                Console.WriteLine($"{ip}:{port}--weight:{weight}");

                //client.KV.del
            }
        }
    }
}
