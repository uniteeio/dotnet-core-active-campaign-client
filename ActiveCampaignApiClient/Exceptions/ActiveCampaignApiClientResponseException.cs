using System;

namespace ActiveCampaignApiClient.Exceptions
{
    public class ActiveCampaignApiClientResponseException  : ActiveCampaignApiClientException
    {
        public ActiveCampaignApiClientResponseException()
        {
        }

        public ActiveCampaignApiClientResponseException(string message)
            : base(message)
        {
        }

        public ActiveCampaignApiClientResponseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}