using IdentityModel.Client;
using Newtonsoft.Json;
//using Ocelot.Configuration.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Microservice.TestProject
{
    public class OcelotConfigureTest
    {
        public static void Show()
        {
            var result1 = UpdateAsync().Result;
            var result2 = ClearCacheAsync().Result;
            Console.Read();
        }

        private static string token = @"eyJhbGciOiJSUzI1NiIsImtpZCI6Imc0TlhXdm9YMTFJZ21ybUNScHR5aFEiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE1OTY2MTIxNzUsImV4cCI6MTU5NjYxNTc3NSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo3MjAwIiwiYXVkIjoiVXNlckFwaSIsImNsaWVudF9pZCI6IlpoYW94aS5Bc3BOZXRDb3JlMzEuQXV0aERlbW8iLCJjbGllbnRfcm9sZSI6IkFkbWluIiwiY2xpZW50X25pY2tuYW1lIjoiRWxldmVuIiwiY2xpZW50X2VNYWlsIjoiNTcyNjUxNzdAcXEuY29tIiwic2NvcGUiOlsiVXNlckFwaSJdfQ.T9cfLimluHPOI83l5t0paYB-Q-NlLztjmUO8zJYEkT5y0wcQD0BVl4phn0Z5whNET6JL9jZXzADljrMX_v3BueIrg2XmyUXZM2jDV7rHLov03J3Nuu6tOjxj0U1kTGhhB8g8PXny0LKwByM7weA4TdKttKjTkvY7GZrf1UhiIzozJzvJYsDWsr6BxtTSLYElSDU9nUfzW7tU_uld9zkembR9JMBGKxWlDYaLP1ZDwTFsXgFefo89el-mnVdOhP9ZojEbYwN1lxBNAw4f3vLQSAI1od8lY2RIWNGYXkmG0xrELwyL8_i6o8iFtPt-A_d4gUugFMbXNhpMoX5hnvZZOw";
        private static async Task<HttpResponseMessage> UpdateAsync()
        {
            string conf = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configuration.json"));
            var client = new HttpClient();
            client.SetBearerToken(token);

            HttpContent content = new StringContent(conf);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://localhost:6299/administration/configuration", content);

            return response;
        }

        private static async Task<HttpResponseMessage> ClearCacheAsync()
        {
            var client = new HttpClient();
            client.SetBearerToken(token);
            var response = await client.DeleteAsync(" http://localhost:6299/administration/outputcache/UserCache");
            return response;
        }
    }
}
