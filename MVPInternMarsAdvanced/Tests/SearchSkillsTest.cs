using MVPInternMarsAdvanced.Data;
using MVPInternMarsAdvanced.Pages;
using MVPInternMarsAdvanced.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPInternMarsAdvanced.Tests
{
    [TestFixture]

    public class SearchSkillsTest : BaseClass
    {
        ProfilePage profilePageObj = new ProfilePage();
        ShareSkillPage shareSkillPageObj = new ShareSkillPage();
        SearchSkillPage searchSkillPageObj = new SearchSkillPage(); 
        CommonPanel commonPanelObj = new CommonPanel();

        public static string textSkills = File.ReadAllText(@"Data\ShareSkills.json");
        public static JArray shareSkillsArray = JArray.Parse(textSkills);


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

        [Test]
        public void SearchSkillByAllCategories()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[6].Title, shareSkills[6].Description, shareSkills[6].Category, shareSkills[6].SubCategory, shareSkills[6].Tags, shareSkills[6].ServiceType, shareSkills[6].LocationType, shareSkills[6].SkillTrade, shareSkills[6].SkillExchange, shareSkills[6].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[7].Title, shareSkills[7].Description, shareSkills[7].Category, shareSkills[7].SubCategory, shareSkills[7].Tags, shareSkills[7].ServiceType, shareSkills[7].LocationType, shareSkills[7].SkillTrade, shareSkills[7].SkillExchange, shareSkills[7].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[8].Title, shareSkills[8].Description, shareSkills[8].Category, shareSkills[8].SubCategory, shareSkills[8].Tags, shareSkills[8].ServiceType, shareSkills[8].LocationType, shareSkills[8].SkillTrade, shareSkills[8].SkillExchange, shareSkills[8].Active);
            commonPanelObj.SearchForSkill(timeStamp);
            Assert.That(searchSkillPageObj.AllCountLbl.Text, Is.EqualTo("3"), "All category count is wrong");
            Assert.That(searchSkillPageObj.Category1CountLbl.Text, Is.EqualTo("2"), "Category 1 count is wrong");
            Assert.That(searchSkillPageObj.Category2CountLbl.Text, Is.EqualTo("1"), "Category 2 count is wrong");
        }

        [Test]
        public void SearchSkillBySubCategories()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[6].Title, shareSkills[6].Description, shareSkills[6].Category, shareSkills[6].SubCategory, shareSkills[6].Tags, shareSkills[6].ServiceType, shareSkills[6].LocationType, shareSkills[6].SkillTrade, shareSkills[6].SkillExchange, shareSkills[6].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[7].Title, shareSkills[7].Description, shareSkills[7].Category, shareSkills[7].SubCategory, shareSkills[7].Tags, shareSkills[7].ServiceType, shareSkills[7].LocationType, shareSkills[7].SkillTrade, shareSkills[7].SkillExchange, shareSkills[7].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[8].Title, shareSkills[8].Description, shareSkills[8].Category, shareSkills[8].SubCategory, shareSkills[8].Tags, shareSkills[8].ServiceType, shareSkills[8].LocationType, shareSkills[8].SkillTrade, shareSkills[8].SkillExchange, shareSkills[8].Active);
            commonPanelObj.SearchForSkill(timeStamp);
            Assert.That(searchSkillPageObj.Category1CountLbl.Text, Is.EqualTo("2"), "Category 1 count is wrong");
            searchSkillPageObj.SelectASubCategory();
            Assert.That(searchSkillPageObj.SubCategory1CountLbl.Text, Is.EqualTo("1"), "Sub category count is wrong");
        }

        [Test]
        public void SearchNonExistingSkill()
        {
            commonPanelObj.SearchForSkill("!2#");
            Assert.That(searchSkillPageObj.AllCountLbl.Text, Is.EqualTo("0"), "All category count is wrong");
            Assert.That(searchSkillPageObj.NoResultsLbl.Text, Is.EqualTo("No results found, please select a new category!"), "Failed no results found");
        }

        [Test]
        public void SearchSkillsByOnlineFilter()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[6].Title, shareSkills[6].Description, shareSkills[6].Category, shareSkills[6].SubCategory, shareSkills[6].Tags, shareSkills[6].ServiceType, shareSkills[6].LocationType, shareSkills[6].SkillTrade, shareSkills[6].SkillExchange, shareSkills[6].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[7].Title, shareSkills[7].Description, shareSkills[7].Category, shareSkills[7].SubCategory, shareSkills[7].Tags, shareSkills[7].ServiceType, shareSkills[7].LocationType, shareSkills[7].SkillTrade, shareSkills[7].SkillExchange, shareSkills[7].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[8].Title, shareSkills[8].Description, shareSkills[8].Category, shareSkills[8].SubCategory, shareSkills[8].Tags, shareSkills[8].ServiceType, shareSkills[8].LocationType, shareSkills[8].SkillTrade, shareSkills[8].SkillExchange, shareSkills[8].Active);
            commonPanelObj.SearchForSkill(timeStamp);
            searchSkillPageObj.SearchByFilters("Online");
            Assert.That(searchSkillPageObj.AllCountLbl.Text, Is.EqualTo("2"), "All category count is wrong");
            Assert.That(searchSkillPageObj.Category1CountLbl.Text, Is.EqualTo("1"), "Category 1 count is wrong");
            Assert.That(searchSkillPageObj.Category2CountLbl.Text, Is.EqualTo("1"), "Category 2 count is wrong");
        }

        [Test]
        public void SearchSkillsByOnsiteFilter()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[6].Title, shareSkills[6].Description, shareSkills[6].Category, shareSkills[6].SubCategory, shareSkills[6].Tags, shareSkills[6].ServiceType, shareSkills[6].LocationType, shareSkills[6].SkillTrade, shareSkills[6].SkillExchange, shareSkills[6].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[7].Title, shareSkills[7].Description, shareSkills[7].Category, shareSkills[7].SubCategory, shareSkills[7].Tags, shareSkills[7].ServiceType, shareSkills[7].LocationType, shareSkills[7].SkillTrade, shareSkills[7].SkillExchange, shareSkills[7].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[8].Title, shareSkills[8].Description, shareSkills[8].Category, shareSkills[8].SubCategory, shareSkills[8].Tags, shareSkills[8].ServiceType, shareSkills[8].LocationType, shareSkills[8].SkillTrade, shareSkills[8].SkillExchange, shareSkills[8].Active);
            commonPanelObj.SearchForSkill(timeStamp);
            searchSkillPageObj.SearchByFilters("Onsite");
            Assert.That(searchSkillPageObj.AllCountLbl.Text, Is.EqualTo("1"), "All category count is wrong");
            Assert.That(searchSkillPageObj.Category1CountLbl.Text, Is.EqualTo("1"), "Category 1 count is wrong");
            Assert.That(searchSkillPageObj.Category2CountLbl.Text, Is.EqualTo("0"), "Category 2 count is wrong");
        }

        [Test]
        public void SearchSkillsByAshowAllFilter()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[6].Title, shareSkills[6].Description, shareSkills[6].Category, shareSkills[6].SubCategory, shareSkills[6].Tags, shareSkills[6].ServiceType, shareSkills[6].LocationType, shareSkills[6].SkillTrade, shareSkills[6].SkillExchange, shareSkills[6].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[7].Title, shareSkills[7].Description, shareSkills[7].Category, shareSkills[7].SubCategory, shareSkills[7].Tags, shareSkills[7].ServiceType, shareSkills[7].LocationType, shareSkills[7].SkillTrade, shareSkills[7].SkillExchange, shareSkills[7].Active);
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[8].Title, shareSkills[8].Description, shareSkills[8].Category, shareSkills[8].SubCategory, shareSkills[8].Tags, shareSkills[8].ServiceType, shareSkills[8].LocationType, shareSkills[8].SkillTrade, shareSkills[8].SkillExchange, shareSkills[8].Active);
            commonPanelObj.SearchForSkill(timeStamp);
            searchSkillPageObj.SearchByFilters("ShowAll");
            Assert.That(searchSkillPageObj.AllCountLbl.Text, Is.EqualTo("3"), "All category count is wrong");
            Assert.That(searchSkillPageObj.Category1CountLbl.Text, Is.EqualTo("2"), "Category 1 count is wrong");
            Assert.That(searchSkillPageObj.Category2CountLbl.Text, Is.EqualTo("1"), "Category 2 count is wrong");
        }
    }
}
