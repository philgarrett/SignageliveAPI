# SignageliveAPI

A Signagelive API Proxy

You will need to add a class capable of returning the following values:
- ClientId
- ClientSecret
- NetworkId
- AuthorizationCode
- NetworkUrl

The code below will do the job, you will need to populate the various parameters

~~~
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
                ClientId = "<Client Id>",
                ClientSecret = "<Client Secret>",
                NetworkId = "<Network Id>",
                AuthorizationCode = "<Authorization Code>",
                NetWorkUrl = "<Network URL>"
            };

            return parameters;
        }
    }
}
~~~
