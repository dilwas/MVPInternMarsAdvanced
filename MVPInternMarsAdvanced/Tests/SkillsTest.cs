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
    public class SkillsTest : BaseClass
    {
        SkillPage skillPageObj = new SkillPage();
        ProfilePage profilePageObj = new ProfilePage();

        public static string text = File.ReadAllText(@"Data\Skills.json");
        public static JArray skillsArray = JArray.Parse(text);

        IList<Skills> skills = skillsArray.Select(p => new Skills
        {
            Skill = (string)p["Skill"],
            Level = (string)p["Level"]
        }).ToList();
        
        [Test]
        public void AddANewSkillRecord()
        {
            Clear();
            skillPageObj.AddSkill(skills[0].Skill, skills[0].Level);

            Thread.Sleep(2000);
            Assert.That(skillPageObj.PopUpMsg.Text == skills[0].Skill + " has been added to your skills", "skill has not been added");
            Assert.That(skillPageObj.SkillLbl.Text, Is.EqualTo(skills[0].Skill), "Skill has not been added");
            Assert.That(skillPageObj.LevelLbl.Text, Is.EqualTo(skills[0].Level), "Level has not been added");    
        }

        [Test]
        public void EditExistingSkillRecord()
        {
            Clear();
            skillPageObj.AddSkill(skills[0].Skill, skills[0].Level);

            Thread.Sleep(2000);
            Assert.That(skillPageObj.PopUpMsg.Text == skills[0].Skill + " has been added to your skills", "skill has not been added");
            Assert.That(skillPageObj.SkillLbl.Text, Is.EqualTo(skills[0].Skill), "Skill has not been added");
            Assert.That(skillPageObj.LevelLbl.Text, Is.EqualTo(skills[0].Level), "Level has not been added");

            skillPageObj.EditSkillRecord(skills[1].Skill, skills[1].Level);

            Thread.Sleep(2000);
            Assert.That(skillPageObj.PopUpMsg.Text == skills[1].Skill + " has been updated to your skills", "skill has not been added");
            Assert.That(skillPageObj.SkillLbl.Text, Is.EqualTo(skills[1].Skill), "Skills has not been added");
            Assert.That(skillPageObj.LevelLbl.Text, Is.EqualTo(skills[1].Level), "Level has not been added");
        }

        [Test]
        public void DeleteSkillRecord()
        {
            Clear();
            skillPageObj.AddSkill(skills[0].Skill, skills[0].Level);

            Thread.Sleep(2000);
            Assert.That(skillPageObj.PopUpMsg.Text == skills[0].Skill + " has been added to your skills", "skill has not been added");
            Assert.That(skillPageObj.SkillLbl.Text, Is.EqualTo(skills[0].Skill), "Skill has not been added");
            Assert.That(skillPageObj.LevelLbl.Text, Is.EqualTo(skills[0].Level), "Level has not been added");

            skillPageObj.DeleteSkillRecord();
            Thread.Sleep(2000);
            Assert.That(skillPageObj.PopUpMsg.Text == skills[0].Skill + " has been deleted", "skill has not been added");
            Console.WriteLine(skillPageObj.SkillRecords.Count.ToString());
            Assert.That(skillPageObj.SkillRecords.Count == 0, "Skill record is still appeared");
        }
    }
}
