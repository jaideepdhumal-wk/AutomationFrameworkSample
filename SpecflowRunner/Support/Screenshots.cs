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
           /* if (!(Utilities.WebDriver is ITakesScreenshot takesScreenshot))
            {
                return;
            }

            var screenshot = takesScreenshot.GetScreenshot();

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
            string fileName = $"{fileNameWithoutExtension}.png";
            string tempFileName = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

            Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");*/
        }
    }
}
