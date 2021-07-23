using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Zhaoxi.AgilityFramework;
using Zhaoxi.AgilityFramework.ConsulClientExtend;
using Zhaoxi.gRPCDemo.LessonServer;
using Zhaoxi.gRPCDemo.RecordServer;
using Zhaoxi.gRPCDemo.ScoreServer;
using Zhaoxi.Microservice.AdvancedDemo.Models;

namespace Zhaoxi.Microservice.AdvancedDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ZhaoxiLesson.ZhaoxiLessonClient _lessonClient;
        private readonly IConsulDispatcher _IConsulDispatcher = null;
        private readonly IConfiguration _iConfiguration = null;
        public HomeController(ILogger<HomeController> logger
            , ZhaoxiLesson.ZhaoxiLessonClient lessonClient
            , IConsulDispatcher consulDispatcher
            ,IConfiguration configuration)
        {
            _logger = logger;
            this._lessonClient = lessonClient;
            this._IConsulDispatcher = consulDispatcher;
            this._iConfiguration = configuration;
        }
        /// <summary>
        /// Core WebApi
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            //常规是去读数据库---这会儿换成调用服务--这里不要维护那么多服务地址

            {
                string url = "http://ZhaoxiUserService/api/users/all";
                Uri uri = new Uri(url);
                string serviceName = uri.Host;

                string addressPort = this._IConsulDispatcher.ChooseAddress(serviceName);
                url = $"{uri.Scheme}://{addressPort}{uri.PathAndQuery}";

                string content = HttpHelper.InvokeApi(url);
                base.ViewBag.Users = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<User>>(content);
                Console.WriteLine($"This is {url} Invoke");
            }

            //{
            //    string targetUrl = "https://localhost:5001";
            //    using (var channel = GrpcChannel.ForAddress(targetUrl))
            //    {
            //        var client = new Score.ScoreClient(channel);

            //        Console.WriteLine("***************单次调用************");
            //        {
            //            var reply = await client.GetScoreAsync(new ScoreRequest() { LessonId = "123" });
            //            string result = Newtonsoft.Json.JsonConvert.SerializeObject(reply.Score);
            //            Console.WriteLine($"ScoreClient {Thread.CurrentThread.ManagedThreadId} 服务返回数据1:{result} ");
            //            base.ViewBag.Result = result;
            //        }
            //    }
            //}

            return View();
        }

        public async Task<IActionResult> Info()
        {
            //{
            //    //加权轮询
            //    var services = new List<string>();
            //    foreach (var service in healthServices)
            //    {
            //        services.AddRange(Enumerable.Repeat(service.IP + ":" + service.Port, service.Weight));
            //    }
            //}

            {
                string targetUrl = $"http://{this._IConsulDispatcher.ChooseAddress("LessonService")}";
                //"http://localhost:8000"
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                using (var channel = GrpcChannel.ForAddress(targetUrl))
                {
                    var client = new ZhaoxiLesson.ZhaoxiLessonClient(channel);

                    Console.WriteLine("***************单次调用************");
                    {
                        var reply = await _lessonClient.FindLessonAsync(new ZhaoxiLessonRequest() { Id = 123 });
                        string result = Newtonsoft.Json.JsonConvert.SerializeObject(reply.Lesson);
                        Console.WriteLine($"_lessonClient {Thread.CurrentThread.ManagedThreadId} 服务返回数据1:{result} ");
                        base.ViewBag.Result = result;
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> InfoRecord()
        {
            string url = $"http://{ this._IConsulDispatcher.ChooseAddress("RecordService")}";
            Console.WriteLine($"This is from {url}");
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                using (var channel = GrpcChannel.ForAddress(url))
                {
                    var client = new StudyRecord.StudyRecordClient(channel);

                    Console.WriteLine("***************单次调用************");
                    {
                        var reply = await client.GetRecordListAsync(new GetRecordRequest() { Id = 123 });
                        string result = Newtonsoft.Json.JsonConvert.SerializeObject(reply.StudyRecordModelList);
                        Console.WriteLine($"StudyRecordClient {Thread.CurrentThread.ManagedThreadId} 服务返回数据1:{result} ");
                        base.ViewBag.Result = result;
                    }
                }
            }
            return View();
        }

        public IActionResult Apollo()
        {
            base.ViewBag.ASPNET = this._iConfiguration["ASPNET"];
            base.ViewBag.jimmy = this._iConfiguration["jimmy"];
            base.ViewBag.apple = this._iConfiguration["apple"];
            base.ViewBag.Single = this._iConfiguration["Single"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
