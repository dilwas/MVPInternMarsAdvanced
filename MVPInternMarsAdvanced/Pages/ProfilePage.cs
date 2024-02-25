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
using OpenQA.Selenium.Support.UI;

namespace MVPInternMarsAdvanced.Pages
{
    public class ProfilePage : BaseClass
    {
        public IWebElement LocationLbl => driver.FindElement(By.XPath("(//div[@class='item'])[1]"));
        public IWebElement AvailabilityLbl => driver.FindElement(By.XPath("//div[@class='item'][2]/div/span"));
        public IWebElement HoursLbl => driver.FindElement(By.XPath("//div[@class='item'][3]/div/span"));
        public IWebElement EarnTargetLbl => driver.FindElement(By.XPath("//div[@class='item'][4]/div/span"));
        public IWebElement AvailabilityEditIcn => driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[1]"));
        public IWebElement HoursEditIcn => driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[2]"));
        public IWebElement EarnTargetEditIcn => driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[3]"));
        public IWebElement AvailabilityDdn => driver.FindElement(By.XPath("//select[@name='availabiltyType']"));
        public IWebElement HoursDdn => driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
        public IWebElement EarnTargetDdn => driver.FindElement(By.XPath("//select[@name='availabiltyTarget']"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        public IWebElement ShareSkillBtn => driver.FindElement(By.XPath("//a[normalize-space()='Share Skill']"));

        public void ChangeAvailability(string availability)
        {
            AvailabilityEditIcn.Click();
            Thread.Sleep(1000);
            var selectElement = new SelectElement(AvailabilityDdn);
            selectElement.SelectByText(availability);
        }

        public void ChangeHours(string hours)
        {
            HoursEditIcn.Click();

            var selectElement = new SelectElement(HoursDdn);
            selectElement.SelectByText(hours);
        }

        public void ChangeEarnTarget(string earnTarget)
        {
            EarnTargetEditIcn.Click();

            var selectElement = new SelectElement(EarnTargetDdn);
            selectElement.SelectByText(earnTarget);
        }

        public void NavigateToShareSkill()
        {
            ShareSkillBtn.Click();
        }
    }
}
