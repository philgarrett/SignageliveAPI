namespace SignageliveAPI.Controllers
{
    public interface IParameters
    {
        Parameters GetParameters();
    }

    public class Parameters : IParameters
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string NetworkId { get; set; }
        public string AuthorizationCode { get; set; }
        public string NetWorkUrl { get; set; }

        public Parameters GetParameters()
        {
            Parameters parameters = new Parameters
            {
                ClientId = "0e69f82c66e8",
                ClientSecret = "d6b3e9f48518",
                NetworkId = "14178",
                AuthorizationCode = "fFR1vW/L10iSAEjoOfHMSYqcmiZcuspj",
                NetWorkUrl = "https://networkapi.signagelive.com"
            };

            return parameters;
        }
    }
}
