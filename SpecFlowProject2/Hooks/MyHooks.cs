using Newtonsoft.Json;
using SpecFlowProject2.Models;
using SpecFlowProject2.Utils;

namespace SpecFlowProject2.Hooks
{
    [Binding]
    internal class MyHooks
    {
        [BeforeTestRun]
        public static void LoadApiData()
        {
            string apiConfigs = FileUtils.getResourceFile("ApiConfigs.json");
            string endpointConfigs = FileUtils.getResourceFile("Endpoints.json");
            ApiData apiData = JsonConvert.DeserializeObject<ApiData>(apiConfigs);
            EndpointData endpointData = JsonConvert.DeserializeObject<EndpointData>(endpointConfigs);


            EnvironmentInfo.endpointData = endpointData;
            EnvironmentInfo.apiData = apiData;
        }
    }
}
