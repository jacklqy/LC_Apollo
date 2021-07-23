using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Zhaoxi.Microservice.TestProject
{
    public class JsonVSProtobuf
    {
        public static void Show()
        {
            #region InitData
            List<PostInfo> list = new List<PostInfo>();
            for (int i = 0; i < 15000; i++)
            {
                PostInfo postInfo = new PostInfo()
                {
                    Content = "这是内容",
                    ID = i,
                    Title = "title"
                };
                list.Add(postInfo);
            }
            #endregion

            #region protpuf格式

            #endregion

            {
                byte[] datas;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Restart();
                using (var stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, list);
                    datas = stream.ToArray();
                }
                stopwatch.Stop();
                Console.WriteLine($"protobuf 长度为：{datas.Length}");
                Console.WriteLine($"protobuf 序列化用时：{stopwatch.Elapsed.TotalMilliseconds}");

                stopwatch.Restart();
                using (var stream = new MemoryStream())
                {
                    stream.Write(datas, 0, datas.Length);
                    stream.Position = 0;
                    var listtemp = ProtoBuf.Serializer.Deserialize<List<PostInfo>>(stream);
                }
                stopwatch.Stop();
                Console.WriteLine($"protobuf 反序列化用时：{stopwatch.Elapsed.TotalMilliseconds}");

            }
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string tempjson = JsonConvert.SerializeObject(list); //把当前集合转换成json
                stopwatch.Stop();
                Console.WriteLine($"json 长度为：{UTF8Encoding.UTF8.GetBytes(tempjson).Length}");
                Console.WriteLine($"json 序列化用时：{stopwatch.Elapsed.TotalMilliseconds}");
                stopwatch.Start();
                var jsonp = JsonConvert.DeserializeObject<List<PostInfo>>(tempjson);//把当前集合转换成json
                stopwatch.Stop();
                Console.WriteLine($"json 反序列化用时：{stopwatch.Elapsed.TotalMilliseconds}");

            }
        }
    }
}
