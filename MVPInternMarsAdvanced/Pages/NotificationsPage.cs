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
    public class NotificationsPage : BaseClass
    {
        public IWebElement FirstRecordChk => driver.FindElement(By.XPath("//input[@value='0']"));
        public IWebElement DeleteBtn => driver.FindElement(By.XPath("//i[@class='trash icon']"));
        public IWebElement LoadMoreLnk => driver.FindElement(By.XPath("//a[normalize-space()='Load More...']"));
        public IWebElement ShowLessLnk => driver.FindElement(By.XPath("//a[normalize-space()='...Show Less']"));
        public ReadOnlyCollection <IWebElement> ServiceRequestsRecords => driver.FindElements(By.XPath("(//h4[contains(text(),'Service Request')])"));

        public void DeleteNotification()
        {
            FirstRecordChk.Click();
            DeleteBtn.Click();
            Thread.Sleep(2000);
        }

        public void LoadMoreNotifications()
        {
            LoadMoreLnk.Click();
            Thread.Sleep(3000);
        }

        public void ShowLessNotifications()
        {
            ShowLessLnk.Click();
            Thread.Sleep(3000);
        }
    }
}
