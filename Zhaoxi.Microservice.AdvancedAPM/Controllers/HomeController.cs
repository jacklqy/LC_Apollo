using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Exceptionless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zhaoxi.Microservice.AdvancedAPM.Models;

namespace Zhaoxi.Microservice.AdvancedAPM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            try
            {
                this._logger.LogWarning($"This is Zhaoxi.Microservice.AdvancedAPM.Controllers.HomeController  Test 3333333");
                throw new Exception($"This is Zhaoxi.Microservice.AdvancedAPM.Controllers.HomeController  Test Exception111");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this._logger.LogWarning(ex.Message);

                ex.ToExceptionless().Submit();

                throw new Exception($"This is Zhaoxi.Microservice.AdvancedAPM.Controllers.HomeController  Test Exception222skds");


            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
