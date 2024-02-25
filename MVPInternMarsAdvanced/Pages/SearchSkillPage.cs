using MVPInternMarsAdvanced.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPInternMarsAdvanced.Pages
{
    public class SearchSkillPage : BaseClass
    {
        public IWebElement AllCountLbl => driver.FindElement(By.XPath("//a[@class='active item']/span"));
        public IWebElement Category1CountLbl => driver.FindElement(By.XPath("//div/a[5]/span"));
        public IWebElement Category2CountLbl => driver.FindElement(By.XPath("//div/a[6]/span"));
        public IWebElement SubCategory1CountLbl => driver.FindElement(By.XPath("//a[6]//span[1]"));
        public IWebElement NoResultsLbl => driver.FindElement(By.XPath("//div[@class='twelve wide column']/div/h3"));
        public IWebElement ShowAllFilterBtn => driver.FindElement(By.XPath("//button[normalize-space()='ShowAll']"));
        public IWebElement OnlineFilterBtn => driver.FindElement(By.XPath("//button[normalize-space()='Online']"));
        public IWebElement OnsiteFilterBtn => driver.FindElement(By.XPath("//button[normalize-space()='Onsite']"));
        public IWebElement FirstSkillLnk => driver.FindElement(By.XPath("//p[@class='row-padded']"));

        public void SelectASubCategory()
        {
            Category1CountLbl.Click();
        }

        public void SearchByFilters(string filter)
        {
            if(filter == "ShowAll")
            {
                ShowAllFilterBtn.Click();
            }
            else if(filter == "Online")
            {
                OnlineFilterBtn.Click();
            }
            else if(filter == "Onsite")
            {
                OnsiteFilterBtn.Click();
            }
            Thread.Sleep(3000);
        }

        public void SelectFirstSkill()
        {
            FirstSkillLnk.Click();
        }
    }
}
