using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ActiveCampaignApiClient.Exceptions;
using ActiveCampaignApiClient.Models;
using Newtonsoft.Json;

namespace ActiveCampaignApiClient
{
    public class ActiveCampaignApiClient
    {
        private readonly ActiveCampaignClientOptions _options;

        public ActiveCampaignApiClient(ActiveCampaignClientOptions options)
        {
            _options = options;
        }


        private string BuildUri(string apiAction)
        {
            return $"{_options.BaseUri}/admin/api.php?api_action={apiAction}&api_key={_options.ApiKey}&api_output=json";
        }

        public async Task<Result> Call(string apiAction, Dictionary<string, string> parameters)
        {
            var uri = BuildUri(apiAction);

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var postContent = new FormUrlEncodedContent(parameters);

                    var response = await httpClient.PostAsync(uri, postContent);

                    response.EnsureSuccessStatusCode();

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Result>(responseContent);
                    result.Data = responseContent;

                    return result;
                }
            }
            catch (HttpRequestException e)
            {
                throw new ActiveCampaignApiClientException(e.Message);
            }
        }
}

}