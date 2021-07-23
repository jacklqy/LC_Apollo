using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zhaoxi.MicroService.GatewayDemo.OcelotExtend.MiddlewareExtend
{
    /// <summary>
    /// 注册中间件的方法
    /// </summary>
    public static class CustomServiceExtension
    {
        public static IApplicationBuilder UseCustomResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomResponseMiddleware>();
        }
    }
}
