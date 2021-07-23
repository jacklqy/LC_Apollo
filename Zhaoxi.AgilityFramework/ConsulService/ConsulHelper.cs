using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.AgilityFramework.ConsulService
{
    /// <summary>
    /// HTTP模式
    /// </summary>
    public static class ConsulHelper
    {
        public static async Task UseConsul(this IApplicationBuilder app, ConsulConfigModel consulService, HealthConfigModel healthService)
        {

            string ip = healthService.IP;// configuration["ip"];
            int port = healthService.Port;// int.Parse(configuration["port"]);//命令行参数必须传入
            //int weight = string.IsNullOrWhiteSpace(configuration["weight"]) ? 1 : int.Parse(configuration["weight"]);//命令行参数必须传入

            using (ConsulClient client = new ConsulClient(c =>
             {
                 c.Address = new Uri($"http://{consulService.IP}:{consulService.Port}/");
                 c.Datacenter = "dc1";
             }))
            {
                await client.Agent.ServiceRegister(new AgentServiceRegistration()
                {
                    ID = "grpcService" + ip + ":" + port,//唯一的
                    Name = healthService.GroupName,//组名称-Group
                    Address = ip,
                    Port = port,
                    Tags = healthService.Tag,
                    Check = new AgentServiceCheck()
                    {
                        Interval = TimeSpan.FromSeconds(12),
                        HTTP = $"http://{ip}:{healthService.CheckPort}/Health",
                        Timeout = TimeSpan.FromSeconds(5),
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5)
                    }
                });
                Console.WriteLine($"http://{ip}:{port}完成注册");

                //client.KV.Put(new KVPair("Eleven") { Value = Encoding.UTF8.GetBytes("This is Teacher") });
                //Console.WriteLine(client.KV.Get("Eleven"));
                //client.KV.Delete("Eleven");

                //client.KV.Delete("Eleven");
                //直接查看KV类里面的封装

                //client.ACL.

                //client.ExecuteLocked
            }
        }
    }
}
