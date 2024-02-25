using AventStack.ExtentReports.Model;
using MVPInternMarsAdvanced.Data;
using MVPInternMarsAdvanced.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Reflection.Emit;

namespace MVPInternMarsAdvanced.Pages
{
    public class ShareSkillPage : BaseClass
    {
        public IWebElement TitleTxt => driver.FindElement(By.Name("title"));
        public IWebElement DescriptionTxt => driver.FindElement(By.Name("description"));
        public IWebElement CategoryDdn => driver.FindElement(By.Name("categoryId"));
        public IWebElement SubCategoryDdn => driver.FindElement(By.Name("subcategoryId"));
        public IWebElement TagsTxt => driver.FindElement(By.XPath("(//input[@class='ReactTags__tagInputField'])[1]"));
        public IWebElement ServiceTypeHourlyOpt => driver.FindElement(By.XPath("(//input[@name='serviceType'])[1]"));
        public IWebElement ServiceTypeOneOffOpt => driver.FindElement(By.XPath("(//input[@name='serviceType'])[2]"));
        public IWebElement LocationTypeOnsiteOpt => driver.FindElement(By.XPath("(//input[@name='locationType'])[1]"));
        public IWebElement LocationTypeOnlineOpt => driver.FindElement(By.XPath("(//input[@name='locationType'])[2]"));
        public IWebElement SkillTradeSkillExchangeOpt => driver.FindElement(By.XPath("(//input[@name='skillTrades'])[1]"));
        public IWebElement SkillTradeCreditOpt => driver.FindElement(By.XPath("(//input[@name='skillTrades'])[2]"));
        public IWebElement SkillExchangeTxt => driver.FindElement(By.XPath("(//input[@class='ReactTags__tagInputField'])[2]"));
        public IWebElement ActiveOpt => driver.FindElement(By.XPath("(//input[@name='isActive'])[1]"));
        public IWebElement HiddenOpt => driver.FindElement(By.XPath("(//input[@name='isActive'])[2]"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("//input[@value='Save']"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));

        public IList<IWebElement> options;
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        public IWebElement ValidateTitlemsg => driver.FindElement(By.XPath("//div[@class='twelve wide column']//div//div[@class='ui basic red prompt label transition visible']"));
        public IWebElement ValidateDescripmsg => driver.FindElement(By.XPath("//div[@class='tooltip-target ui grid']//div[@class='row']//div[@class='ui twelve wide column']//div//div[@class='ui basic red prompt label transition visible']"));
        
        public void ShareSkill(string timeStamp, string title, string description, string category, string subCategory, string tags, string serviceType, string locationType, string skillTrade, string skillExchange, string active)
        {
            TitleTxt.SendKeys(title + timeStamp);
            DescriptionTxt.SendKeys(description + timeStamp);
            var selectElement = new SelectElement(CategoryDdn);
            selectElement.SelectByText(category);
            selectElement = new SelectElement(SubCategoryDdn);
            selectElement.SelectByText(subCategory);
            TagsTxt.SendKeys(tags);
            TagsTxt.SendKeys(Keys.Enter);
            if(serviceType == "One-off service")
            {
                ServiceTypeOneOffOpt.Click();
            }
            if(locationType == "Onsite")
            {
                LocationTypeOnsiteOpt.Click();
            }
            if(skillTrade == "Credit")
            {
                SkillTradeCreditOpt.Click();
            }
            
            SkillExchangeTxt.SendKeys(skillExchange);
            SkillExchangeTxt.SendKeys(Keys.Enter);
            if (active == "Hidden")
            {
                HiddenOpt.Click();
            }
            SaveBtn.Click();
            Thread.Sleep(2000);
        }

        public void SelectACategory(string category)
        {
            var selectElement = new SelectElement(CategoryDdn);
            selectElement.SelectByText(category);
            selectElement = new SelectElement(SubCategoryDdn);
            options = SubCategoryDdn.FindElements(By.TagName("option"));
            List<string> actualDropdownValues = new List<string>();

            Console.WriteLine(options[0].Text);
            // Iterate through the options and get their text
            foreach (IWebElement option in options)
            {
                Console.WriteLine(option.Text);
            }
        }

        public void CancelShareSkills()
        {
            CancelBtn.Click();
        }

        public void AddSpecialCharactersForTitleAndDescription(string title, string description)
        {
            TitleTxt.SendKeys(title);
            DescriptionTxt.SendKeys(description);
        }
    }
}
