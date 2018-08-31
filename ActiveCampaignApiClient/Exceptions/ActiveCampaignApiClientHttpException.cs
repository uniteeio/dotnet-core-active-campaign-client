using System;

namespace ActiveCampaignApiClient.Exceptions
{
    public class ActiveCampaignApiClientHttpException  : ActiveCampaignApiClientException
    {
        public ActiveCampaignApiClientHttpException()
        {
        }

        public ActiveCampaignApiClientHttpException(string message)
            : base(message)
        {
        }

        public ActiveCampaignApiClientHttpException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}