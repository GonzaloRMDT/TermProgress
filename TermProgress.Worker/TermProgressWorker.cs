using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TermProgress.Worker
{
    public static class TermProgressWorker
    {
        [FunctionName("TermProgressWorker")]
        public static async void Run([TimerTrigger("0 0 0 * * *")]TimerInfo myTimer, ILogger log)
        {
            HttpClient httpClient = new HttpClient();
            string url = "***REMOVED***";
            await httpClient.PostAsync(url, null);
            log.LogInformation($"Sent POST request to {url}.");
            httpClient.Dispose();
        }
    }
}