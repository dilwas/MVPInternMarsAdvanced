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
    public class ShareSkillsTest : BaseClass
    {
        ProfilePage profilePageObj = new ProfilePage();
        ShareSkillPage shareSkillPageObj = new ShareSkillPage();
        ManageListingPage manageListingPageObj = new ManageListingPage();

        public static string textSkills = File.ReadAllText(@"Data\ShareSkills.json");
        public static JArray shareSkillsArray = JArray.Parse(textSkills);
        public static string textCategories = File.ReadAllText(@"Data\Categories.json");
        public static JArray categoriesArray = JArray.Parse(textCategories);
        public static string textSubCategories = File.ReadAllText(@"Data\SubCategories.json");
        public static JArray subCategoriesArray = JArray.Parse(textSubCategories);

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

        IList<Categories> categories = categoriesArray.Select(p => new Categories
        {
            Category1 = (string)p["Category1"],
            Category2 = (string)p["Category2"],
            Category3 = (string)p["Category3"],
            Category4 = (string)p["Category4"],
            Category5 = (string)p["Category5"],
            Category6 = (string)p["Category6"],
            Category7 = (string)p["Category7"],
            Category8 = (string)p["Category8"]
        }).ToList();

        IList<SubCategories> subCategories = subCategoriesArray.Select(p => new SubCategories
        {
            SubCategory1 = (string)p["SubCategory1"],
            SubCategory2 = (string)p["SubCategory2"],
            SubCategory3 = (string)p["SubCategory3"],
            SubCategory4 = (string)p["SubCategory4"],
            SubCategory5 = (string)p["SubCategory5"]
        }).ToList();

        [Test]
        public void ShareSkillWithValidDetails()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[0].Title, shareSkills[0].Description, shareSkills[0].Category, shareSkills[0].SubCategory, shareSkills[0].Tags, shareSkills[0].ServiceType, shareSkills[0].LocationType, shareSkills[0].SkillTrade, shareSkills[0].SkillExchange, shareSkills[0].Active);
            Assert.That(manageListingPageObj.CategoryLbl.Text, Is.EqualTo(shareSkills[0].Category), "Skill category has not been added");
            Assert.That(manageListingPageObj.TitleLbl.Text, Is.EqualTo(shareSkills[0].Title + timeStamp), "Skill title has not been added");
            Assert.That(manageListingPageObj.DescriptionLbl.Text, Is.EqualTo(shareSkills[0].Description + timeStamp), "Skill description has not been added");
            Assert.That(manageListingPageObj.ServiceTypeLbl.Text, Is.EqualTo(shareSkills[0].ServiceType), "Skill service type has not been added");
        }

        [Test]
        public void ShareSkillWithValidMaxCharacters()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[1].Title, shareSkills[1].Description, shareSkills[1].Category, shareSkills[1].SubCategory, shareSkills[1].Tags, shareSkills[1].ServiceType, shareSkills[1].LocationType, shareSkills[1].SkillTrade, shareSkills[1].SkillExchange, shareSkills[1].Active);
            Assert.That(manageListingPageObj.CategoryLbl.Text, Is.EqualTo(shareSkills[1].Category), "Skill category has not been added");
            Assert.That(manageListingPageObj.TitleLbl.Text, Is.EqualTo(shareSkills[1].Title), "Skill title has not been added");
            StringAssert.StartsWith(manageListingPageObj.TitleLbl.Text, shareSkills[1].Description);
            Assert.That(manageListingPageObj.ServiceTypeLbl.Text, Is.EqualTo(shareSkills[1].ServiceType), "Skill service type has not been added");
        }

        [Test]
        public void VerifySubCategoriesForGraphicsAndDesign()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.SelectACategory(categories[0].Category1);
            Assert.AreEqual(subCategories[0].SubCategory1, shareSkillPageObj.options[1].Text);
            Assert.AreEqual(subCategories[0].SubCategory2, shareSkillPageObj.options[2].Text);
            Assert.AreEqual(subCategories[0].SubCategory3, shareSkillPageObj.options[3].Text);
            Assert.AreEqual(subCategories[0].SubCategory4, shareSkillPageObj.options[4].Text);
            Assert.AreEqual(subCategories[0].SubCategory5, shareSkillPageObj.options[5].Text);
        }

        [Test]
        public void VerifySubCategoriesForDigitalMarketing()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.SelectACategory(categories[0].Category2);
            Assert.AreEqual(subCategories[1].SubCategory1, shareSkillPageObj.options[1].Text);
            Assert.AreEqual(subCategories[1].SubCategory2, shareSkillPageObj.options[2].Text);
            Assert.AreEqual(subCategories[1].SubCategory3, shareSkillPageObj.options[3].Text);
            Assert.AreEqual(subCategories[1].SubCategory4, shareSkillPageObj.options[4].Text);
            Assert.AreEqual(subCategories[1].SubCategory5, shareSkillPageObj.options[5].Text);
        }

        [Test]
        public void VerifySubCategoriesForWritingAndTranslation()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.SelectACategory(categories[0].Category3);
            Assert.AreEqual(subCategories[2].SubCategory1, shareSkillPageObj.options[1].Text);
            Assert.AreEqual(subCategories[2].SubCategory2, shareSkillPageObj.options[2].Text);
            Assert.AreEqual(subCategories[2].SubCategory3, shareSkillPageObj.options[3].Text);
            Assert.AreEqual(subCategories[2].SubCategory4, shareSkillPageObj.options[4].Text);
            Assert.AreEqual(subCategories[2].SubCategory5, shareSkillPageObj.options[5].Text);
        }

        [Test]
        public void VerifySubCategoriesForVideoAndAnimation()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.SelectACategory(categories[0].Category4);
            Assert.AreEqual(subCategories[3].SubCategory1, shareSkillPageObj.options[1].Text);
            Assert.AreEqual(subCategories[3].SubCategory2, shareSkillPageObj.options[2].Text);
            Assert.AreEqual(subCategories[3].SubCategory3, shareSkillPageObj.options[3].Text);
            Assert.AreEqual(subCategories[3].SubCategory4, shareSkillPageObj.options[4].Text);
        }

        [Test]
        public void VerifySubCategoriesForMusicAndAudio()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.SelectACategory(categories[0].Category5);
            Assert.AreEqual(subCategories[4].SubCategory1, shareSkillPageObj.options[1].Text);
            Assert.AreEqual(subCategories[4].SubCategory2, shareSkillPageObj.options[2].Text);
            Assert.AreEqual(subCategories[4].SubCategory3, shareSkillPageObj.options[3].Text);
            Assert.AreEqual(subCategories[4].SubCategory4, shareSkillPageObj.options[4].Text);
        }

        [Test]
        public void VerifySubCategoriesForProgrammingAndTech()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.SelectACategory(categories[0].Category6);
            Assert.AreEqual(subCategories[5].SubCategory1, shareSkillPageObj.options[1].Text);
            Assert.AreEqual(subCategories[5].SubCategory2, shareSkillPageObj.options[2].Text);
            Assert.AreEqual(subCategories[5].SubCategory3, shareSkillPageObj.options[3].Text);
            Assert.AreEqual(subCategories[5].SubCategory4, shareSkillPageObj.options[4].Text);
            Assert.AreEqual(subCategories[5].SubCategory5, shareSkillPageObj.options[5].Text);
        }

        [Test]
        public void VerifySubCategoriesForBusiness()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.SelectACategory(categories[0].Category7);
            Assert.AreEqual(subCategories[6].SubCategory1, shareSkillPageObj.options[1].Text);
            Assert.AreEqual(subCategories[6].SubCategory2, shareSkillPageObj.options[2].Text);
            Assert.AreEqual(subCategories[6].SubCategory3, shareSkillPageObj.options[3].Text);
            Assert.AreEqual(subCategories[6].SubCategory4, shareSkillPageObj.options[4].Text);
            Assert.AreEqual(subCategories[6].SubCategory5, shareSkillPageObj.options[5].Text);
        }

        [Test]
        public void VerifySubCategoriesForFunAndLifestyle()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.SelectACategory(categories[0].Category8);
            Assert.AreEqual(subCategories[7].SubCategory1, shareSkillPageObj.options[1].Text);
            Assert.AreEqual(subCategories[7].SubCategory2, shareSkillPageObj.options[2].Text);
            Assert.AreEqual(subCategories[7].SubCategory3, shareSkillPageObj.options[3].Text);
            Assert.AreEqual(subCategories[7].SubCategory4, shareSkillPageObj.options[4].Text);
            Assert.AreEqual(subCategories[7].SubCategory5, shareSkillPageObj.options[5].Text);
        }

        [Test]
        public void ShareSkillWithMultipleTags()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[2].Title, shareSkills[2].Description, shareSkills[2].Category, shareSkills[2].SubCategory, shareSkills[2].Tags, shareSkills[2].ServiceType, shareSkills[2].LocationType, shareSkills[2].SkillTrade, shareSkills[2].SkillExchange, shareSkills[2].Active);
            Assert.That(manageListingPageObj.CategoryLbl.Text, Is.EqualTo(shareSkills[2].Category), "Skill category has not been added");
            Assert.That(manageListingPageObj.TitleLbl.Text, Is.EqualTo(shareSkills[2].Title + timeStamp), "Skill title has not been added");
            Assert.That(manageListingPageObj.DescriptionLbl.Text, Is.EqualTo(shareSkills[2].Description + timeStamp), "Skill description has not been added");
            Assert.That(manageListingPageObj.ServiceTypeLbl.Text, Is.EqualTo(shareSkills[2].ServiceType), "Skill service type has not been added");
        }

        [Test]
        public void shareSkillWithMultipleTagsForSkillExchange()
        {
            profilePageObj.NavigateToShareSkill();
            string timeStamp = GetTimestamp(DateTime.Now);
            shareSkillPageObj.ShareSkill(timeStamp, shareSkills[3].Title, shareSkills[3].Description, shareSkills[3].Category, shareSkills[3].SubCategory, shareSkills[3].Tags, shareSkills[3].ServiceType, shareSkills[3].LocationType, shareSkills[3].SkillTrade, shareSkills[3].SkillExchange, shareSkills[3].Active);
            Assert.That(manageListingPageObj.CategoryLbl.Text, Is.EqualTo(shareSkills[3].Category), "Skill category has not been added");
            Assert.That(manageListingPageObj.TitleLbl.Text, Is.EqualTo(shareSkills[3].Title + timeStamp), "Skill title has not been added");
            Assert.That(manageListingPageObj.DescriptionLbl.Text, Is.EqualTo(shareSkills[3].Description + timeStamp), "Skill description has not been added");
            Assert.That(manageListingPageObj.ServiceTypeLbl.Text, Is.EqualTo(shareSkills[3].ServiceType), "Skill service type has not been added");

        }

        [Test]
        public void CancelShareSkills()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.CancelShareSkills();
        }

        [Test]
        public void AddSpecialCharactersForTitleAndDescription()
        {
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.AddSpecialCharactersForTitleAndDescription(shareSkills[4].Title, shareSkills[4].Description);
            Assert.That(shareSkillPageObj.ValidateTitlemsg.Text, Is.EqualTo("Special characters are not allowed."));
            Assert.That(shareSkillPageObj.ValidateDescripmsg.Text, Is.EqualTo("Special characters are not allowed."));
        }
    }
}
