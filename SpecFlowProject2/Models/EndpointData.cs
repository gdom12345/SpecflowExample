using Newtonsoft.Json;
using RestSharp;
using SpecFlowProject2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Models
{
    internal class EndpointData
    {
        public Endpoint[] endpoints { get; set; }

        public Endpoint getEndPoint(string endpointName)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Endpoint endpoint = Array.Find(endpoints,
                                           match: endPoint => endPoint.name == endpointName);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (endpoint == null)
            {
                throw new ArgumentNullException("Did NOT find an endpoint for " + endpointName);
            }
            return endpoint;
        }

    }

    internal class Endpoint
    {
        public string name { get; set; }
        public string api { get; set; }
        public string callType { get; set; }
        public string path { get; set; }

        public Method GetCallMethod()
        {
            Method method;
            Enum.TryParse(callType, out method);
            return method;
        }
      

        public string getBaseUrl()
        {
            return EnvironmentInfo.apiData.GetCurrentEnvironment().getBaseUrl(api);
        }

    }
}
