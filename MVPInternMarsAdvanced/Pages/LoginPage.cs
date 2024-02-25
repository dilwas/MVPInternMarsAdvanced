using MVPInternMarsAdvanced.Utilities;
using MVPInternMarsAdvanced.Data;
using MVPInternMarsAdvanced.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MVPInternMarsAdvanced.Pages
{
    public class LoginPage : BaseClass
    {
        public IWebElement SignInBtn => driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']"));
        public IWebElement Email => driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
        public IWebElement Password => driver.FindElement(By.XPath("//INPUT[@type='password']"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));

        public void SigninStep(string username, string password)
        {
            SignInBtn.Click();

            Email.SendKeys(username);
            Password.SendKeys(password);
            LoginBtn.Click();
        }
    }
}
