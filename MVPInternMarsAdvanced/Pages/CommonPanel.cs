using MVPInternMarsAdvanced.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPInternMarsAdvanced.Pages
{
    public  class CommonPanel : BaseClass
    {
        public IWebElement SearchTxt => driver.FindElement(By.XPath("//input[@placeholder='Search skills']"));
        public IWebElement SignoutBtn => driver.FindElement(By.XPath("//button[normalize-space()='Sign Out']"));
        public IWebElement NotificationsLnk => driver.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']"));
        public IWebElement MarkAllAsReadLnk => driver.FindElement(By.XPath("//a[normalize-space()='Mark all as read']"));
        public IWebElement SeeAllLnk => driver.FindElement(By.XPath("//a[normalize-space()='See All...']"));
        public IWebElement NotificationLbl => driver.FindElement(By.XPath("//div[@class='floating ui blue label']"));
        public ReadOnlyCollection <IWebElement> NotificationRecords => driver.FindElements(By.XPath("//div[@class='floating ui blue label']"));

        public void SearchForSkill(string skill)
        {
            SearchTxt.SendKeys(skill);
            SearchTxt.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }

        public void SignOut()
        {
            SignoutBtn.Click();
        }

        public void MarkAllNotificationsAsRead()
        {
            NotificationsLnk.Click();
            Thread.Sleep(1000);
            MarkAllAsReadLnk.Click();
            Thread.Sleep(2000);
        }

        public void NavigateToNotifications()
        {
            NotificationsLnk.Click();
            SeeAllLnk.Click();
        }
    }
}
