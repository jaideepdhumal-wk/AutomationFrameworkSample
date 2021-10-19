using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Utilities_UI;

namespace SpecflowRunner.Hooks
{
   
    [Binding]
    public class Screenshots
    {

        [AfterStep]
        public void MakeScreenshotAfterStep()
        {
            Utilities.TakeScreenshot();
         
        }
    }
}
