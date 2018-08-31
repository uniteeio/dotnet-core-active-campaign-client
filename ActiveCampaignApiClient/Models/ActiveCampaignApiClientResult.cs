using Newtonsoft.Json;

namespace ActiveCampaignApiClient.Models
{
    public class ActiveCampaignApiClientResult
    {
        [JsonProperty("result_code")]
        public int Code { get; set; }

        [JsonProperty("result_message")]
        public string Message { get; set; }

        [JsonProperty("result_output")]
        public string Output { get; set; }

        public string Data { get; set; }
    }
}