using System;

namespace ActiveCampaignApiClient.Exceptions
{
    public class ActiveCampaignClientException  : Exception
    {
        public ActiveCampaignClientException()
        {
        }

        public ActiveCampaignClientException(string message)
            : base(message)
        {
        }

        public ActiveCampaignClientException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}