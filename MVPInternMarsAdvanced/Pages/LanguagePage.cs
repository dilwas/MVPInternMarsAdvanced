using MVPInternMarsAdvanced.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace MVPInternMarsAdvanced.Pages
{
    public class LanguagePage : BaseClass
    {
        public IWebElement AddNewBtn => driver.FindElement(By.XPath("(//div[@class='ui teal button '])[1]"));
        public IWebElement AddBtn => driver.FindElement(By.XPath("//INPUT[@value='Add']"));
        public ReadOnlyCollection<IWebElement> LanguageRecords => driver.FindElements(By.XPath("//div[@data-tab='first']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        public IWebElement DeleteIcn => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        public IWebElement LanguageTab => driver.FindElement(By.XPath("//a[@data-tab='first']"));
        public IWebElement LanguageTxt => driver.FindElement(By.Name("name"));
        public IWebElement LevelDdn => driver.FindElement(By.Name("level"));
        public IWebElement LanguageLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]"));
        public IWebElement LevelLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        public IWebElement EditIcn => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]/span[1]/i"));
        public IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));
        
        public void ClearAllLanguageRecords()
        {
            LanguageTab.Click();

            //tbody count
            int records = LanguageRecords.Count();
            //loop first delete icon
            for (int i = 0; i < records; i = i + 1)
            {
                DeleteIcn.Click();
                Thread.Sleep(2000);
            }
        }

        public void AddLanguage(string language, string level)
        {
            LanguageTab.Click();
            AddNewBtn.Click();
            LanguageTxt.SendKeys(language);

            var selectElement = new SelectElement(LevelDdn);
            selectElement.SelectByValue(level);
            AddBtn.Click();
        }

        public void EditLanguageRecord(string updatedLanguage, string updatedLevel)
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            LanguageTxt.Clear();
            LanguageTxt.SendKeys(updatedLanguage);

            var selectElement = new SelectElement(LevelDdn);
            selectElement.SelectByValue(updatedLevel);

            UpdateBtn.Click();
        }

        //Delete certification
        public void DeleteLanguageRecord()
        {
            Thread.Sleep(3000);
            DeleteIcn.Click();
        }
    }
}
