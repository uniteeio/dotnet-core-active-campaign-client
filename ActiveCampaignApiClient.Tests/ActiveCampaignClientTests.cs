using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using ActiveCampaignApiClient.Exceptions;
using ActiveCampaignApiClient.Models;
using Xunit;

namespace ActiveCampaignApiClient.Tests
{
    public class ActiveCampaignClientTests
    {
        private ActiveCampaignClient _activeCampaignClient;
        private FakeMessageHandler _handler;

        public ActiveCampaignClientTests()
        {
            _handler = new FakeMessageHandler();
            var httpClient = new HttpClient(_handler);
            
            _activeCampaignClient = new ActiveCampaignClient(httpClient, new ActiveCampaignClientOptions
            {
                ApiKey = "abc",
                BaseUri = "http://localhost"
            });
        }
        
        [Fact]
        public async Task CallShouldReturnResult()
        {
            _handler.Response = GetResponseFromFile(@"Response.json");

            var res = await _activeCampaignClient.Call("contact_list", new Dictionary<string, string>());
            
            Assert.IsType<ActiveCampaignClientResult>(res);
        }
        
        [Fact]
        public async Task CallShouldThrowException_WhenApiReturnDomainError()
        {
            _handler.Response = GetResponseFromFile(@"EmptyResponse.json");
            await Assert.ThrowsAsync<ActiveCampaignClientResponseException>(() => _activeCampaignClient.Call("contact_list", new Dictionary<string, string>()));
        }
        
        [Fact]
        public async Task CallShouldThrowException_WhenApiReturnHttpError()
        {
            _handler.Response =  new HttpResponseMessage {StatusCode = HttpStatusCode.BadRequest};
            await Assert.ThrowsAsync<ActiveCampaignClientHttpException>(() => _activeCampaignClient.Call("contact_list", new Dictionary<string, string>()));
        }

        private HttpResponseMessage GetResponseFromFile(string file)
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var response = new HttpResponseMessage();
            var resources = assembly.GetManifestResourceNames();
            var resourceName = resources.FirstOrDefault(f => f.Equals($"ActiveCampaignApiClient.Tests.JsonFiles.{file}" , StringComparison.OrdinalIgnoreCase));
            string json = "";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            response.Content = new StringContent(json);
            return response;
        }
    }
    
    
}