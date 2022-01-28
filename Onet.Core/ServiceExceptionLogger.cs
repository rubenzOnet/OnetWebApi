using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using R = Onet.Core.Response;

namespace Onet.Core
{
    public class ServiceExceptionLogger : IServiceExceptionLogger
    {
        private static ILogger<R.Response> Logger = NullLogger<R.Response>.Instance;
        public void LogException(Exception ex, string specificMessage)
        {
            Logger.LogError($"{ex.Message} >>> {ex.StackTrace}");

            //TODO: ADDED THIS THOW INSTRUCTION FOR GETTING FULL EXCEPTION INFO IN RESPONSE.
            //REMOVE IT WHEN YOU HAVE ACCES TO LOG FILE
            throw ex;
        }

    }
}
