using Microsoft.AspNetCore.Http;
using Ocelot.Infrastructure.Extensions;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.MicroService.GatewayDemo.OcelotExtend.AggregatorExtend
{
    /// <summary>
    /// 自定义聚合器
    /// </summary>
    public class CustomUserAggregator : IDefinedAggregator
    {
        //public Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            Dictionary<string, string> dicResult = new Dictionary<string, string>();
            for (int i = 0; i < responses.Count; i++)
            {
                string content = await responses[i].Items.DownstreamResponse().Content.ReadAsStringAsync();//这里还有各种信息
                dicResult.Add($"No{i}", content);
            }
            dicResult.Add("OtherCustom", "This is From Ocelot");
            string totalContent = Newtonsoft.Json.JsonConvert.SerializeObject(dicResult);
            var stringContent = new StringContent(totalContent)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            var headers = responses.SelectMany(x => x.Items.DownstreamResponse().Headers).ToList();

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, headers, "custom Aggregator");
        }
    }
}
