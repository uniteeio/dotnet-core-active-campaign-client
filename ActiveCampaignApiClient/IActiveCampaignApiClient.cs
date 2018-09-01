using System.Collections.Generic;
using System.Threading.Tasks;
using ActiveCampaignApiClient.Models;

namespace ActiveCampaignApiClient
{
    public interface IActiveCampaignApiClient
    {
        Task<ActiveCampaignClientResult> Call(string apiAction, Dictionary<string, string> parameters);
    }
}