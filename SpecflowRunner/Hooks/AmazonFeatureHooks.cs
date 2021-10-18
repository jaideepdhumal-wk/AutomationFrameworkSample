using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Utilities_UI;

namespace SpecflowRunner.Hooks
{
    [Binding]
    public sealed class AmazonFeatureHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Utilities.InitializeDriver();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Scenarios.Login();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Scenarios.Logout();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Utilities.WebDriver.Quit();
        }


    }
}
