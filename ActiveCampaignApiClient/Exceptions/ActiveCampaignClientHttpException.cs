using System;

namespace ActiveCampaignApiClient.Exceptions
{
    public class ActiveCampaignClientHttpException  : ActiveCampaignClientException
    {
        public ActiveCampaignClientHttpException()
        {
        }

        public ActiveCampaignClientHttpException(string message)
            : base(message)
        {
        }

        public ActiveCampaignClientHttpException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}