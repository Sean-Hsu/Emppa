using Emppa.Core.EventLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emppa.Web.Handlers
{
    public class EventLogHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string currentKey = Guid.NewGuid().ToString("N");
            request.Headers.Add("Current-Key", currentKey);
            //
            string requestEventSource = string.Format("[{0}][{1}][{2}]", "I", currentKey, request.RequestUri.OriginalString);
            DefaultLogger.CurrentLogger.LogEvent(requestEventSource, LogType.Default, request.Content.ReadAsStringAsync().Result);
            //
            var task = base.SendAsync(request, cancellationToken);
            var response = task.Result;
            //
            string responseEventSource = string.Format("[{0}][{1}][{2}]", "O", currentKey, request.RequestUri.OriginalString);
            DefaultLogger.CurrentLogger.LogEvent(responseEventSource, LogType.Default, response.Content.ReadAsStringAsync().Result);
            //
            return task;
        }
    }
}
