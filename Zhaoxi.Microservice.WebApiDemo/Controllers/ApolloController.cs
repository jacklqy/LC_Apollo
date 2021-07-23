using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Zhaoxi.Microservice.WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApolloController : ControllerBase
    {
        private IConfiguration _iConfiguration;
        private IOptions<EmailOption> _optionsDefault;//直接单例，不支持数据变化，性能高
        private IOptionsMonitor<EmailOption> _optionsMonitor;//支持数据修改，靠的是监听文件更新(onchange)数据
        private IOptionsSnapshot<EmailOption> _optionsSnapshot;//一次请求数据不变的，但是不同请求可以不同的，每次生成

        public ApolloController(IConfiguration configuration
            , IOptions<EmailOption> options,
            IOptionsMonitor<EmailOption> optionsMonitor,
            IOptionsSnapshot<EmailOption> optionsSnapshot)
        {
            this._optionsDefault = options;
            this._optionsMonitor = optionsMonitor;
            this._optionsSnapshot = optionsSnapshot;
            this._iConfiguration = configuration;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            Console.WriteLine($"This is ApolloController  {this._iConfiguration["port"]} Invoke");


            #region Option
            {
                Console.WriteLine("_optionsDefault");//自动更新
                var fromConfigurationEmailOption = _optionsDefault.Value;
                Console.WriteLine(fromConfigurationEmailOption.Title);
            }
            {
                Console.WriteLine("_optionsMonitor");//自动更新
                var fromConfigurationEmailOption = _optionsMonitor.Get("FromConfiguration");
                var fromConfigurationEmailOptionNew = _optionsMonitor.Get("FromConfigurationNew");
                Console.WriteLine(fromConfigurationEmailOption.Title);
                Console.WriteLine(fromConfigurationEmailOptionNew.Title);
            }
            {
                Console.WriteLine("_optionsMonitor");//自动更新
                var fromConfigurationEmailOption = _optionsSnapshot.Get("FromConfiguration");
                var fromConfigurationEmailOptionNew = _optionsSnapshot.Get("FromConfigurationNew");
                Console.WriteLine(fromConfigurationEmailOption.Title);
                Console.WriteLine(fromConfigurationEmailOptionNew.Title);
            }
            #endregion

            #region MyRegion
            EmailOption e = new EmailOption();
            this._iConfiguration.GetSection("Email").Bind(e);
            Console.WriteLine(e.Title);
            #endregion

            string timeout = this._iConfiguration["timeout"];
            string abc = this._iConfiguration["abc"];
            string ddd = this._iConfiguration["ddd"];
            string ip = this._iConfiguration["ip"];

            return Ok($"timeout={timeout} abc={abc} ddd={ddd} ip={ip} ");//只是个200 
        }
    }
}