using Microsoft.AspNetCore.Mvc;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaAssetsController : ControllerBase
    {
        string networkId;
        string networkUrl;

        public MediaAssetsController()
        {
            IParameters p = new Parameters();
            Parameters pp = p.GetParameters();
            networkId = pp.NetworkId;
            networkUrl = pp.NetWorkUrl;
        }

        // GET: api/<MediaAssetsController>
        [HttpGet]
        public string Get([FromHeader] string authorization)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}", networkId, "mediaassets");

            RestRequest restRequest = new RestRequest(request_resource, Method.Get);
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("Content-Type", "application/json");

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessful && response.Content != null)
            {
                return response.Content;
            }
            return "[]";
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public string Get(int id, [FromHeader] string authorization)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}/{2}", networkId, "mediaassets", id);

            RestRequest restRequest = new RestRequest(request_resource, Method.Get);
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("Content-Type", "application/json");

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessful && response.Content != null)
            {
                return response.Content;
            }
            return "{}";
        }
    }
}
