using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ActiveCampaignApiClient.Tests
{
    public class FakeMessageHandler : HttpClientHandler
    {
        public FakeMessageHandler()
        {
            Responses = new Queue<HttpResponseMessage>();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            VerifyRequest?.Invoke(request);
            VerificationBeforeSend?.Invoke();

            await Task.Delay(Delay);

            if (Responses.Count > 0)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return await Task.FromResult(Responses.Dequeue());
            }

            cancellationToken.ThrowIfCancellationRequested();
            return await Task.FromResult(Response);
        }
        public Action<HttpRequestMessage> VerifyRequest { get; set; }
        public Action VerificationBeforeSend { get; set; }
        public Queue<HttpResponseMessage> Responses { get; set; }
        public HttpResponseMessage Response { get; set; }
        public int Delay { get; set; }
    }
}