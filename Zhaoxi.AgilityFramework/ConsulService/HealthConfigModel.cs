using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.AgilityFramework.ConsulService
{
    public class HealthConfigModel
    {
        /// <summary>
        /// 组名称
        /// </summary>
        public string GroupName { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public int CheckPort { get; set; }
        public string[] Tag { get; set; }
    }
}
