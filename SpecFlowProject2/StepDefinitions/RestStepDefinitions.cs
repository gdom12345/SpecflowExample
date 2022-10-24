using JsonDiffPatchDotNet;
using Microsoft.XmlDiffPatch;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SpecFlow.Internal.Json;
using SpecFlowProject2.Models;
using SpecFlowProject2.Utils;
using System;
using System.Text;
using System.Xml;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class RestStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;

        public RestStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [When(@"I call API ""([^""]*)"" and save response to ""([^""]*)""")]
        public void WhenICallAPIAndSaveResponseTo(string apiEndpoint, string responseKey,
            Table parameters)
        {
            var parameterDictionary = ToDictionary(parameters);
            Endpoint endpoint = EnvironmentInfo.endpointData.getEndPoint(apiEndpoint);
            var client = new RestClient(endpoint.getBaseUrl() + endpoint.path);
         
            RestRequest restRequest = new RestRequest();
            restRequest.Method = endpoint.GetCallMethod();
  
            foreach (string key in parameterDictionary.Keys)
            {
                //Expand on this to account for body also
                if (endpoint.path.Contains("{" + key + "}"))
                {
                    restRequest.AddUrlSegment(key, parameterDictionary[key]);
                }
                else
                {
                    restRequest.AddParameter(key, parameterDictionary[key]);
                }
            }
  
            var response = client.Execute(restRequest);
    
            scenarioContext.Add(responseKey, response);
        }

        [Given(@"I open resource file ""([^""]*)"" and save to ""([^""]*)""")]
        public void GivenIOpenResourceFileAndSaveTo(string resourcePath, string outputKey)
        {
            string resourceText = FileUtils.getResourceFile(resourcePath);
            scenarioContext.Add(outputKey, resourceText);
        }


        //I need to do some work to clean this up or find a different comparison library
        private void validateJsonMatch(string expected, string actual)
        {
            var result = new JsonDiffPatch().Diff(expected, actual);
            Assert.True(result == null, "Found Mismatch in data:\n" + result);
        }


        [Then(@"I validate response code for ""([^""]*)"" is (.*)")]
        public void ThenIValidateResponseCodeForIs(string responseKey, int expectedResponseCode)
        {
            var response = scenarioContext.Get<RestResponse>(responseKey);
            Assert.AreEqual(expectedResponseCode, (int)response.StatusCode);
        
        }

        [Then(@"I validate API data ""([^""]*)"" against expected result of ""([^""]*)""")]
        public void ThenIValidateAPIDataAgainstExpectedResultOf(string apiDataKey, string expectedKey)
        {
            var expected = scenarioContext.Get<string>(expectedKey);
            var actual = scenarioContext.Get<RestResponse>(apiDataKey);
            validateJsonMatch(expected, actual.Content);
        }

        private static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}
