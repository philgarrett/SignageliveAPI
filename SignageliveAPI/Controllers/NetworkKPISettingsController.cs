﻿using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignageliveAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NetworkKPISettingsController : ControllerBase
    {
        string networkId;
        string networkUrl;

        public NetworkKPISettingsController()
        {
            IParameters p = new Parameters();
            Parameters pp = p.GetParameters();
            networkId = pp.NetworkId;
            networkUrl = pp.NetWorkUrl;
        }
        
        // GET: <NetworkKPISettingsController>
        [HttpGet]
        public string Get([FromHeader] string authorization)
        {
            RestClient restClient = new RestClient(networkUrl);

            string request_resource = string.Format("networks/{0}/NetworkKPISettings", networkId);

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

        // GET <NetworkKPISettingsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST <NetworkKPISettingsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <NetworkKPISettingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <NetworkKPISettingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
