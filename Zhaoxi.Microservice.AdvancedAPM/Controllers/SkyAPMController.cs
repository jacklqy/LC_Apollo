using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zhaoxi.AgilityFramework;
using Zhaoxi.Microservice.AdvancedAPM.Models;

namespace Zhaoxi.Microservice.AdvancedAPM.Controllers
{
    public class SkyAPMController : Controller
    {
        private readonly ILogger<SkyAPMController> _logger;
        public SkyAPMController(ILogger<SkyAPMController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            this._logger.LogWarning($"This is SkyAPMController Index,{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");

            {
                //string url = "http://localhost:5726/api/users/all";
                string url = "http://localhost:6299/T/users/all";
                string content = HttpHelper.InvokeApi(url);
                base.ViewBag.Users = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<User>>(content);
                Console.WriteLine($"This is {url} Invoke");
            }


            return View();
        }
    }
}