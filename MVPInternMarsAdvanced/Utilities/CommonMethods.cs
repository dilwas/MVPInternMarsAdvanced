//using OpenQA.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPInternMarsAdvanced.Utilities
{
    public class CommonMethod
    {
        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
        {
            var folderLocation = @"Screenshots\";

            if (!System.IO.Directory.Exists(folderLocation))
            {
                System.IO.Directory.CreateDirectory(folderLocation);
            }

            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();

            screenShot.SaveAsFile(folderLocation + "/" + ScreenShotFileName.ToString());
            return ScreenShotFileName.ToString();
        }
    }
}
