using TechTalk.SpecFlow;
using log4net;

namespace russellchadwick.Appenders.IntegrationTest
{
    [Binding]
    public class TwitterAppenderSteps
    {
        [Given(@"I have configured log(.*)net in configuration")]
        public void GivenIHaveConfiguredLognetInConfiguration(int p0)
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        
        [When(@"I log a statement")]
        public void WhenILogAStatement()
        {
            var log = LogManager.GetLogger("Test");
            log.Error("Just kidding!");
        }
        
        [Then(@"the result should be sent through twitter APIs")]
        public void ThenTheResultShouldBeSentThroughTwitterAPIs()
        {
            // ScenarioContext.Current.Pending();
        }
    }
}
