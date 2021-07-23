using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Zhaoxi.gRPCDemo.ScoreServer
{
    public class ScoreService : Score.ScoreBase
    {
        private readonly ILogger<ScoreService> _logger;
        public ScoreService(ILogger<ScoreService> logger)
        {
            _logger = logger;
        }

        public override Task<ScoreReply> GetScore(ScoreRequest request, ServerCallContext context)
        {
            this._logger.LogInformation($"This is ScoreService GetScore {request.LessonId}");
            return Task.FromResult(new ScoreReply()
            {
                Score = 100
            });
        }
    }
}
