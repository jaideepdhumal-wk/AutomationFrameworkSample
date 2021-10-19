using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities_UI
{
    public class Utilities
    {
        public static IWebDriver WebDriver { get; set; }

        public static string LogFolder = ConfigurationManager.AppSettings["LogFolder"] + "\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        public static string LogFileName = LogFolder + "\\TestLog.txt";
        public static IWebDriver InitializeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["ApplicationURL"]);
            System.IO.Directory.CreateDirectory(LogFolder);
            return WebDriver;
        }

        public static void Log(string message)
        {
            File.AppendAllLines(LogFileName, new[] { message });
            Console.WriteLine(message);
        }

        public static IWebElement FetchUserName()
        {
            IWebElement AppUser = WebDriver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            return AppUser;
        }
        public static IWebElement SignInText()
        {
            IWebElement signIn = WebDriver.FindElement(By.XPath("//h1[@class='a-spacing-small']"));
            return signIn;
        }

        public static void TakeScreenshot()
        {
            var takesScreenshot = Utilities.WebDriver as ITakesScreenshot;
            if (takesScreenshot != null)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);

                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }
    }
}
