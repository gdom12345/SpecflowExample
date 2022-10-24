using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class Feature1StepDefinitions
    {
        [Given(@"I open web browser")]
        public void GivenIOpenWebBrowser()
        {
            //throw new PendingStepException();
        }

        [When(@"I something")]
        public void WhenISomething()
        {
       //     throw new PendingStepException();
        }

        [Then(@"I validate something")]
        public void ThenIValidateSomething()
        {
     //       throw new PendingStepException();
        }
    }
}
