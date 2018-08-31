using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ActiveCampaignApiClient.Exceptions;
using ActiveCampaignApiClient.Models;
using Newtonsoft.Json;

namespace ActiveCampaignApiClient
{
    public class ActiveCampaignApiClient : IActiveCampaignApiClient
    {
        private readonly ActiveCampaignApiClientOptions _options;
        private readonly HttpClient _httpClient;

        public ActiveCampaignApiClient(HttpClient httpClient, ActiveCampaignApiClientOptions options)
        {
            _options = options;
            _httpClient = httpClient;
        }


        private string BuildUri(string apiAction)
        {
            return $"{_options.BaseUri}/admin/api.php?api_action={apiAction}&api_key={_options.ApiKey}&api_output=json";
        }

        public async Task<ActiveCampaignApiClientResult> Call(string apiAction, Dictionary<string, string> parameters)
        {
            var uri = BuildUri(apiAction);

            try
            {
                var postContent = new FormUrlEncodedContent(parameters);

                var response = await _httpClient.PostAsync(uri, postContent);

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ActiveCampaignApiClientResult>(responseContent);

                if (result.Code == 0)
                {
                    throw new ActiveCampaignApiClientResponseException(result.Message);
                }
                
                result.Data = responseContent;

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new ActiveCampaignApiClientHttpException(e.Message);
            }
        }
    }
}