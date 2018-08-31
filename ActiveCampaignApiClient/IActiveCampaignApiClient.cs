using System.Collections.Generic;
using System.Threading.Tasks;
using ActiveCampaignApiClient.Models;

namespace ActiveCampaignApiClient
{
    public interface IActiveCampaignApiClient
    {
        Task<ActiveCampaignApiClientResult> Call(string apiAction, Dictionary<string, string> parameters);
    }
}