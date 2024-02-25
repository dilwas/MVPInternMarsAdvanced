using MVPInternMarsAdvanced.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace MVPInternMarsAdvanced.Pages
{
    public class ManageListingPage : BaseClass
    {
        public IWebElement CategoryLbl => driver.FindElement(By.XPath("//tbody/tr[1]/td[2]"));
        public IWebElement TitleLbl => driver.FindElement(By.XPath("//tbody/tr[1]/td[3]"));
        public IWebElement DescriptionLbl => driver.FindElement(By.XPath("//tbody/tr[1]/td[4]"));
        public IWebElement ServiceTypeLbl => driver.FindElement(By.XPath("//tbody/tr[1]/td[5]"));
        public IWebElement PageTitelLbl => driver.FindElement(By.XPath("//th[normalize-space()='Title']"));

        
    }
}
