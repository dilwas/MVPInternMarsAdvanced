using MVPInternMarsAdvanced.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPInternMarsAdvanced.Pages
{
    public class SkillDetailsPage : BaseClass
    {
        public IWebElement RequestTxt => driver.FindElement(By.XPath("//textarea"));
        public IWebElement RequestBtn => driver.FindElement(By.XPath("//div[contains(@class,'button')]"));
        public IWebElement YesBtn => driver.FindElement(By.XPath("//button[normalize-space()='Yes']"));

        public void RequestSkillTrade()
        {
            RequestTxt.SendKeys("I am trading my skill");
            RequestBtn.Click();
            YesBtn.Click();
        }
    }
}
