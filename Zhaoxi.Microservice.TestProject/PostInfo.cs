using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhaoxi.Microservice.TestProject
{
    [ProtoContract]
    public class PostInfo
    {
        [ProtoMember(1)]
        public long ID { get; set; }

        [ProtoMember(2)]
        public string Title { get; set; }

        [ProtoMember(3)]
        public string Content { get; set; }

        [ProtoMember(4)]
        public string CreateTime { get; set; }
    }
}
