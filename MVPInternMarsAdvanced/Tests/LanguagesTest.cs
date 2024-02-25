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
    public class LanguagesTest : BaseClass
    {
        LanguagePage languagePageObj = new LanguagePage();

        public static string text = File.ReadAllText(@"Data\Languages.json");
        public static JArray languagesArray = JArray.Parse(text);

        IList<Languages> languages = languagesArray.Select(p => new Languages
        {
            Language = (string)p["Language"],
            Level = (string)p["Level"]
        }).ToList();
        
        [Test]
        public void AddANewLanguageRecord()
        {
            Clear();
            languagePageObj.AddLanguage(languages[0].Language, languages[0].Level);

            Thread.Sleep(2000);
            Assert.That(languagePageObj.PopUpMsg.Text == languages[0].Language + " has been added to your languages", "language has not been added");
            Assert.That(languagePageObj.LanguageLbl.Text, Is.EqualTo(languages[0].Language), "Language has not been added");
            Assert.That(languagePageObj.LevelLbl.Text, Is.EqualTo(languages[0].Level), "Level has not been added");    
        }

        [Test]
        public void EditExistingLanguageRecord()
        {
            Clear();
            languagePageObj.AddLanguage(languages[0].Language, languages[0].Level);

            Thread.Sleep(2000);
            Assert.That(languagePageObj.PopUpMsg.Text == languages[0].Language + " has been added to your languages", "language has not been added");
            Assert.That(languagePageObj.LanguageLbl.Text, Is.EqualTo(languages[0].Language), "Language has not been added");
            Assert.That(languagePageObj.LevelLbl.Text, Is.EqualTo(languages[0].Level), "Level has not been added");

            languagePageObj.EditLanguageRecord(languages[1].Language, languages[1].Level);

            Thread.Sleep(2000);
            Assert.That(languagePageObj.PopUpMsg.Text == languages[1].Language + " has been updated to your languages", "language has not been added");
            Assert.That(languagePageObj.LanguageLbl.Text, Is.EqualTo(languages[1].Language), "Languages has not been added");
            Assert.That(languagePageObj.LevelLbl.Text, Is.EqualTo(languages[1].Level), "Level has not been added");
        }

        [Test]
        public void DeleteLanguageRecord()
        {
            Clear();
            languagePageObj.AddLanguage(languages[0].Language, languages[0].Level);

            Thread.Sleep(2000);
            Assert.That(languagePageObj.PopUpMsg.Text == languages[0].Language + " has been added to your languages", "language has not been added");
            Assert.That(languagePageObj.LanguageLbl.Text, Is.EqualTo(languages[0].Language), "Language has not been added");
            Assert.That(languagePageObj.LevelLbl.Text, Is.EqualTo(languages[0].Level), "Level has not been added");

            languagePageObj.DeleteLanguageRecord();
            Thread.Sleep(2000);
            Assert.That(languagePageObj.PopUpMsg.Text == languages[0].Language + " has been deleted from your languages", "language has not been added");
            Console.WriteLine(languagePageObj.LanguageRecords.Count.ToString());
            Assert.That(languagePageObj.LanguageRecords.Count == 0, "Language record is still appeared");
        }
    }
}
