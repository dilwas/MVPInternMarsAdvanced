using MVPInternMarsAdvanced.Data;
using MVPInternMarsAdvanced.Pages;
using MVPInternMarsAdvanced.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVPInternMarsAdvanced.Tests
{
    [TestFixture]
    public class NotificationsTest : BaseClass
    {
        ProfilePage profilePageObj = new ProfilePage();
        ShareSkillPage shareSkillPageObj = new ShareSkillPage();
        ManageListingPage manageListingPageObj = new ManageListingPage();
        CommonPanel commonPanelObj = new CommonPanel();
        LoginPage loginPageObj = new LoginPage();
        SearchSkillPage searchSkillPageObj = new SearchSkillPage();
        SkillDetailsPage skillDetailsPageObj = new SkillDetailsPage();
        LanguagePage languagePageObj = new LanguagePage();
        NotificationsPage notificationsPageObj = new NotificationsPage();

        public static string textSkills = File.ReadAllText(@"Data\ShareSkills.json");
        public static JArray shareSkillsArray = JArray.Parse(textSkills);
        public static string text = File.ReadAllText(@"Data\Credentials.json");
        public static JArray credentialsArray = JArray.Parse(text);

        IList<ShareSkills> shareSkills = shareSkillsArray.Select(p => new ShareSkills
        {
            Title = (string)p["Title"],
            Description = (string)p["Description"],
            Category = (string)p["Category"],
            SubCategory = (string)p["SubCategory"],
            Tags = (string)p["Tags"],
            ServiceType = (string)p["ServiceType"],
            LocationType = (string)p["LocationType"],
            SkillTrade = (string)p["SkillTrade"],
            SkillExchange = (string)p["SkillExchange"],
            Active = (string)p["Active"]
        }).ToList();

        IList<Credentials> credentials = credentialsArray.Select(p => new Credentials
        {
            Username = (string)p["Username"],
            Password = (string)p["Password"]
        }).ToList();

        [Test]
        public void VerifyLoadMoreNotifications()
        {
            commonPanelObj.NavigateToNotifications();
            Assert.That(notificationsPageObj.ServiceRequestsRecords.Count, Is.EqualTo(5));
            notificationsPageObj.LoadMoreNotifications();
            Assert.That(notificationsPageObj.ServiceRequestsRecords.Count, Is.EqualTo(10));
        }

        [Test]
        public void VerifyShowLessNotifications()
        {
            commonPanelObj.NavigateToNotifications();
            Assert.That(notificationsPageObj.ServiceRequestsRecords.Count, Is.EqualTo(5));
            notificationsPageObj.LoadMoreNotifications();
            Assert.That(notificationsPageObj.ServiceRequestsRecords.Count, Is.EqualTo(10));
            notificationsPageObj.ShowLessNotifications();
            Assert.That(notificationsPageObj.ServiceRequestsRecords.Count, Is.EqualTo(5));
        }

        [Test]
        public void VerifyUserCanMarkAllNotificationAsRead()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[0].Title, shareSkills[0].Description, shareSkills[0].Category, shareSkills[0].SubCategory, shareSkills[0].Tags, shareSkills[0].ServiceType, shareSkills[0].LocationType, shareSkills[0].SkillTrade, shareSkills[0].SkillExchange, shareSkills[0].Active);
            Assert.That(manageListingPageObj.CategoryLbl.Text, Is.EqualTo(shareSkills[0].Category), "Skill category has not been added");
            Assert.That(manageListingPageObj.TitleLbl.Text, Is.EqualTo(shareSkills[0].Title + timeStamp), "Skill title has not been added");
            Assert.That(manageListingPageObj.DescriptionLbl.Text, Is.EqualTo(shareSkills[0].Description + timeStamp), "Skill description has not been added");
            Assert.That(manageListingPageObj.ServiceTypeLbl.Text, Is.EqualTo(shareSkills[0].ServiceType), "Skill service type has not been added");
            commonPanelObj.SignOut();
            loginPageObj.SigninStep(credentials[1].Username, credentials[1].Password);
            commonPanelObj.SearchForSkill(timeStamp);
            searchSkillPageObj.SelectFirstSkill();
            skillDetailsPageObj.RequestSkillTrade();
            commonPanelObj.SignOut();
            loginPageObj.SigninStep(credentials[0].Username, credentials[0].Password);
            Assert.That(commonPanelObj.NotificationRecords.Count, Is.EqualTo(1));
            commonPanelObj.MarkAllNotificationsAsRead();
            Assert.That(commonPanelObj.NotificationRecords.Count, Is.EqualTo(0));
        }

        [Test]
        public void VerifyUserCanDeleteANotificatio()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[0].Title, shareSkills[0].Description, shareSkills[0].Category, shareSkills[0].SubCategory, shareSkills[0].Tags, shareSkills[0].ServiceType, shareSkills[0].LocationType, shareSkills[0].SkillTrade, shareSkills[0].SkillExchange, shareSkills[0].Active);
            Assert.That(manageListingPageObj.CategoryLbl.Text, Is.EqualTo(shareSkills[0].Category), "Skill category has not been added");
            Assert.That(manageListingPageObj.TitleLbl.Text, Is.EqualTo(shareSkills[0].Title + timeStamp), "Skill title has not been added");
            Assert.That(manageListingPageObj.DescriptionLbl.Text, Is.EqualTo(shareSkills[0].Description + timeStamp), "Skill description has not been added");
            Assert.That(manageListingPageObj.ServiceTypeLbl.Text, Is.EqualTo(shareSkills[0].ServiceType), "Skill service type has not been added");
            commonPanelObj.SignOut();
            loginPageObj.SigninStep(credentials[1].Username, credentials[1].Password);
            commonPanelObj.SearchForSkill(timeStamp);
            searchSkillPageObj.SelectFirstSkill();
            skillDetailsPageObj.RequestSkillTrade();
            commonPanelObj.SignOut();
            loginPageObj.SigninStep(credentials[0].Username, credentials[0].Password);
            Assert.That(commonPanelObj.NotificationRecords.Count, Is.EqualTo(1));
            commonPanelObj.NavigateToNotifications();
            notificationsPageObj.DeleteNotification();
            Assert.That(languagePageObj.PopUpMsg.Text, Is.EqualTo("Notification updated"), "Notification not deleted");
        }
    }
}
