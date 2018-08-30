using System;

namespace ActiveCampaignApiClient.Exceptions
{
    public class ActiveCampaignApiClientException  : Exception
    {
        public ActiveCampaignApiClientException()
        {
        }

        public ActiveCampaignApiClientException(string message)
            : base(message)
        {
        }

        public ActiveCampaignApiClientException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}