using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Zhaoxi.gRPCDemo.RecordServer
{
    public class StudyRecordService : StudyRecord.StudyRecordBase
    {
        private readonly ILogger<StudyRecordService> _logger;
        private readonly IConfiguration _IConfiguration;
        public StudyRecordService(ILogger<StudyRecordService> logger,IConfiguration configuration)
        {
            _logger = logger;
            this._IConfiguration = configuration;
        }

        public override Task<StudyRecordReply> GetRecordList(GetRecordRequest request, ServerCallContext context)
        {
            this._logger.LogInformation("This is StudyRecordService GetRecordList");
            StudyRecordReply studyRecordReply = new StudyRecordReply();

            for (int i = 0; i < 10; i++)
            {
                studyRecordReply.StudyRecordModelList.Add(new StudyRecordReply.Types.StudyRecordModel()
                {
                    Id = 100 + i,
                    StudentId = request.Id,
                    Description = $"这是第{i}次上课 {this._IConfiguration["Port"]}"
                });
            }

            return Task.FromResult(studyRecordReply);
        }
    }
}
