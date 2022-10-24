

namespace SpecFlowProject2.Models
{
    internal class ApiData
    {
        public string currentEnvironment { get; set; }
        public Environment[] environments { get; set; }

        public Environment GetCurrentEnvironment()
        {
            Environment environment = Array.Find(environments,
                environ => environ.environment == currentEnvironment);
            return environment;
        }
    }

    internal class Environment
    {
        public string environment { get; set; }
        public Api[] apis { get; set; }

        public string getBaseUrl(String apiName)
        {
            return Array.Find(apis, api => api.name == apiName).baseUrl;
        }
    }

    internal class Api
    {
        public string name { get; set; }
        public string baseUrl { get; set; }
    }
}
