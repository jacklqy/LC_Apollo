using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Core;
using Com.Ctrip.Framework.Apollo.Internals;
using Com.Ctrip.Framework.Apollo.Logging;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Zhaoxi.Microservice.WebApiDemo.Utility
{
    public static class ApolloHelper
    {
        public static void InitApollo(this IConfigurationBuilder configurationBuilder)
        {
            //注入配置 把阿波罗的日志级别调整为最低
            LogManager.UseConsoleLogging(Com.Ctrip.Framework.Apollo.Logging.LogLevel.Trace);
            configurationBuilder
                .AddApollo(configurationBuilder.Build().GetSection("apollo"))
                .AddDefault()
             .AddNamespace(ConfigConsts.NamespaceApplication);
            ;//Apollo中NameSpace的名称

            //ApolloConfigurationProvider
            var configurationRoot = configurationBuilder.Build();
            InitApolloData(configurationRoot);
            
            ChangeToken.OnChange(() => configurationRoot.GetReloadToken(), () =>
            {
                foreach (var apolloProvider in configurationRoot.Providers.Where(p => p is ApolloConfigurationProvider))
                {
                    var property = apolloProvider.GetType().BaseType.GetProperty("Data", BindingFlags.Instance | BindingFlags.NonPublic);
                    var data = property.GetValue(apolloProvider) as IDictionary<string, string>;
                    foreach (var item in data)
                    {
                        if (!_DataDictionary.ContainsKey(item.Key))
                        {
                            Console.WriteLine($"New key {item.Key}  New value {item.Value}");
                            _DataDictionary.Add(item.Key, item.Value);
                            //触发事件
                            //ApolloEvent?.Invoke(_DataDictionary);
                        }
                        else if (!_DataDictionary[item.Key].Equals(item.Value))
                        {
                            Console.WriteLine($"key {item.Key}  Update value {item.Value}");
                            _DataDictionary[item.Key] = item.Value;
                            //触发事件
                            //ApolloEvent?.Invoke(_DataDictionary);
                        }
                        else
                        {
                            Console.WriteLine($"key {item.Key}  same value {item.Value}");
                        }
                    }
                }
            });
        }

        private static Dictionary<string, string> _DataDictionary = new Dictionary<string, string>();

        public static event Action<Dictionary<string, string>> ApolloEvent;

        private static void InitApolloData(IConfigurationRoot configurationRoot)
        {
            foreach (var apolloProvider in configurationRoot.Providers.Where(p => p is ApolloConfigurationProvider))
            {
                apolloProvider.Load();
                var property = apolloProvider.GetType().BaseType.GetProperty("Data", BindingFlags.Instance | BindingFlags.NonPublic);
                var data = property.GetValue(apolloProvider) as IDictionary<string, string>;
                foreach (var item in data)
                {
                    Console.WriteLine(item.Key + item.Value);
                    _DataDictionary.Add(item.Key, item.Value);
                }
            }
        }
    }
}
