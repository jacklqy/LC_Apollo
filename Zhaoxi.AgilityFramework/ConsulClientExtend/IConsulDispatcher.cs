using System;
using System.Collections.Generic;
using System.Text;

namespace Zhaoxi.AgilityFramework.ConsulClientExtend
{
    public interface IConsulDispatcher
    {
        /// <summary>
        /// 负载均衡获取地址
        /// </summary>
        /// <param name="serviceName">朝夕的老师</param>
        /// <returns></returns>
        string ChooseAddress(string serviceName);
    }
}
