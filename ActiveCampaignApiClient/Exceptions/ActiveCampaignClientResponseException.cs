using System;

namespace ActiveCampaignApiClient.Exceptions
{
    public class ActiveCampaignClientResponseException  : ActiveCampaignClientException
    {
        public ActiveCampaignClientResponseException()
        {
        }

        public ActiveCampaignClientResponseException(string message)
            : base(message)
        {
        }

        public ActiveCampaignClientResponseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}