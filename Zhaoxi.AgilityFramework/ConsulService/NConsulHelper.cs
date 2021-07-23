using NConsul;
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
    /// 支持gRPC模式
    /// </summary>
    public static class NConsulHelper
    {
        public static async Task UseGRPCConsul(this IApplicationBuilder app, ConsulConfigModel consulModel, HealthConfigModel healthConfigModel)
        {
            string ip = healthConfigModel.IP;
            int port = healthConfigModel.Port;

            using (ConsulClient client = new ConsulClient(c =>
              {
                  c.Address = new Uri($"http://{consulModel.IP}:{consulModel.Port}/");
                  c.Datacenter = "dc1";
              }))
            {
                await client.Agent.ServiceRegister(new AgentServiceRegistration()
                {
                    ID = "grpcService" + ip + ":" + port,//唯一的
                    Name = healthConfigModel.GroupName,//组名称-Group
                    Address = ip,
                    Port = port,
                    Tags = healthConfigModel.Tag,
                    Check = new AgentServiceCheck()//配置心跳检查的
                    {
                        Interval = TimeSpan.FromSeconds(12),
                        Timeout = TimeSpan.FromSeconds(5),
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(20),
                        GRPC = $"{ip}:{port}",//直接gRPC
                        GRPCUseTLS = false
                    }
                });
                Console.WriteLine($"http://{ip}:{port}完成注册");
            }
        }
    }
}
