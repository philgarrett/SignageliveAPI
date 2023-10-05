using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveAPI.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("")]
        public string Get([FromHeader] string authorization, string? limit = null, string? search = null)
        {
            int notNullCount = 0;
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/{1}", networkId, "mediaassets");

            if (limit != null)
            {
                notNullCount++;
                if (notNullCount == 1)
                    request_resource += string.Format("?limit={0}", limit);
                else
                    request_resource += string.Format("&limit={0}", limit);
            }
            if (search != null)
            {
                notNullCount++;
                if (notNullCount == 1)
                    request_resource += string.Format("?search={0}", search);
                else
                    request_resource += string.Format("&search={0}", search);
            }

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

        // GET <MediaAssetsController>/5
        [HttpGet("{id}")]
        public string Get([FromHeader] string authorization, int id)
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

        [HttpGet("ready")]
        public string GetMediaAssetReady([FromHeader] string authorization, string physicalFileName)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/mediaassets/ready?physicalFileName={1}", networkId, physicalFileName);

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

        [HttpPost("add")]
        public string Post([FromHeader] string authorization, [FromBody] string fileUploadRequests)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/mediaassets/add", networkId);

            RestRequest restRequest = new RestRequest(request_resource, Method.Post);
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("Content-Type", "application/json");

            restRequest.AddJsonBody<string>(fileUploadRequests);

            RestResponse response = restClient.Execute(restRequest);
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                return response.Content;
            }
            return "{}";
        }

    }
}
