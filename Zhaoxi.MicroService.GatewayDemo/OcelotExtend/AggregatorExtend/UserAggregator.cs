//using Ocelot.Middleware;
//using Ocelot.Middleware.Multiplexer;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//namespace Zhaoxi.MicroService.GatewayDemo
//{
//    /// <summary>
//    /// 自定义聚合器
//    /// </summary>
//    public class UserAggregator : IDefinedAggregator
//    {
//        public async Task<DownstreamResponse> Aggregate(List<DownstreamContext> responses)
//        {
//            List<string> results = new List<string>();
//            var contentBuilder = new StringBuilder();

//            contentBuilder.Append("{");

//            foreach (var down in responses)
//            {
//                string content = await down.DownstreamResponse.Content.ReadAsStringAsync();
//                results.Add($"\"{Guid.NewGuid()}\":{content}");
//            }
//            //来自leader的声音
//            results.Add($"\"{Guid.NewGuid()}\":{{comment:\"我是leader，我组织了他们两个进行调查\"}}");

//            contentBuilder.Append(string.Join(",", results));
//            contentBuilder.Append("}");

//            var stringContent = new StringContent(contentBuilder.ToString())
//            {
//                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
//            };

//            var headers = responses.SelectMany(x => x.DownstreamResponse.Headers).ToList();
//            return new DownstreamResponse(stringContent, HttpStatusCode.OK, headers, "some reason");
//        }
//    }
//}
