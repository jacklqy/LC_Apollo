using Microsoft.AspNetCore.Http;
using Ocelot.Logging;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.MicroService.GatewayDemo.OcelotExtend.MiddlewareExtend
{
    /// <summary>
    /// 自定义中间件
    /// </summary>
    public class CustomResponseMiddleware : OcelotMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomResponseMiddleware(RequestDelegate next, IOcelotLoggerFactory loggerFactory)
            : base(loggerFactory.CreateLogger<CustomResponseMiddleware>())
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var response = httpContext.Items.DownstreamResponse();

            if (!IsOptionsHttpMethod(httpContext))
            {
                string content = await response.Content.ReadAsStringAsync();
                base.Logger.LogWarning($"This is CustomResponseMiddleware {response.StatusCode}  {content}");

                //httpContext.Response.Body.Write(Encoding.UTF8.GetBytes(content));//直接操作结果 然后终结掉
            }
            await _next.Invoke(httpContext);
        }

        private static bool IsOptionsHttpMethod(HttpContext httpContext)
        {
            return httpContext.Request.Method.ToUpper() == "OPTIONS";
        }
    }
}
