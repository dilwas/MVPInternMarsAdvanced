using MVPInternMarsAdvanced.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace MVPInternMarsAdvanced.Pages
{
    public class SkillPage : BaseClass
    {
        public IWebElement AddNewBtn => driver.FindElement(By.XPath("(//div[@class='ui teal button'])[1]"));
        public IWebElement AddBtn => driver.FindElement(By.XPath("//INPUT[@value='Add']"));
        public ReadOnlyCollection<IWebElement> SkillRecords => driver.FindElements(By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        public IWebElement DeleteIcn => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        public IWebElement SkillTab => driver.FindElement(By.XPath("//a[@data-tab='second']"));
        public IWebElement SkillTxt => driver.FindElement(By.Name("name"));
        public IWebElement LevelDdn => driver.FindElement(By.Name("level"));
        public IWebElement SkillLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]"));
        public IWebElement LevelLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        public IWebElement EditIcn => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]/span[1]/i"));
        public IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));
        
        public void ClearAllSkillRecords()
        {
            SkillTab.Click();

            //tbody count
            int records = SkillRecords.Count();
            //loop first delete icon
            for (int i = 0; i < records; i = i + 1)
            {
                DeleteIcn.Click();
                Thread.Sleep(2000);
            }
        }

        public void AddSkill(string language, string level)
        {
            SkillTab.Click();
            AddNewBtn.Click();
            SkillTxt.SendKeys(language);

            var selectElement = new SelectElement(LevelDdn);
            selectElement.SelectByValue(level);
            AddBtn.Click();
        }

        public void EditSkillRecord(string updatedLanguage, string updatedLevel)
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            SkillTxt.Clear();
            SkillTxt.SendKeys(updatedLanguage);

            var selectElement = new SelectElement(LevelDdn);
            selectElement.SelectByValue(updatedLevel);

            UpdateBtn.Click();
        }

        //Delete skill
        public void DeleteSkillRecord()
        {
            Thread.Sleep(3000);
            DeleteIcn.Click();
        }
    }
}
