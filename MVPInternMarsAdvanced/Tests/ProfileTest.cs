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
    public class ProfileTest : BaseClass
    {
        ProfilePage profilePageObj = new ProfilePage();

        public static string text = File.ReadAllText(@"Data\Profile.json");
        public static JArray profileArray = JArray.Parse(text);

        IList<Profile> profile = profileArray.Select(p => new Profile
        {
            Availability = (string)p["Availability"],
            Hours = (string)p["Hours"],
            EarnTarget = (string)p["EarnTarget"]
        }).ToList();
        
        [Test]
        public void VerifyLocation()
        {
            Thread.Sleep(2000);
            Assert.That(profilePageObj.LocationLbl.Text, Is.EqualTo(""), "Location has not been added");
        }

        [Test]
        public void ChangeAvailability()
        {
            Thread.Sleep(2000);
            if (profilePageObj.AvailabilityLbl.Text == profile[0].Availability)
            {
                profilePageObj.ChangeAvailability(profile[1].Availability);

                Thread.Sleep(5000);
                Assert.That(profilePageObj.AvailabilityLbl.Text, Is.EqualTo(profile[1].Availability), "Availability has not been updated");
            }
            else
            {
                profilePageObj.ChangeAvailability(profile[0].Availability);

                Thread.Sleep(5000);
                Assert.That(profilePageObj.AvailabilityLbl.Text, Is.EqualTo(profile[0].Availability), "Availability has not been updated");
            }
        }

        [Test]
        public void ChangeHours()
        {
            Thread.Sleep(2000);
            if (profilePageObj.HoursLbl.Text == profile[0].Hours)
            {
                profilePageObj.ChangeHours(profile[1].Hours);

                Thread.Sleep(2000);
                Assert.That(profilePageObj.HoursLbl.Text, Is.EqualTo(profile[1].Hours), "Hours has not been updated");
            }
            else
            {
                profilePageObj.ChangeHours(profile[0].Hours);

                Thread.Sleep(2000);
                Assert.That(profilePageObj.HoursLbl.Text, Is.EqualTo(profile[0].Hours), "Hours has not been updated");
            }
        }

        [Test]
        public void ChangeEarnTarget()
        {
            Thread.Sleep(2000);
            if(profilePageObj.EarnTargetLbl.Text == profile[0].EarnTarget)
            {
                profilePageObj.ChangeEarnTarget(profile[1].EarnTarget);

                Thread.Sleep(2000);
                Assert.That(profilePageObj.EarnTargetLbl.Text, Is.EqualTo(profile[1].EarnTarget), "Earn target has not been updated");
            }
            else
            {
                profilePageObj.ChangeEarnTarget(profile[0].EarnTarget);

                Thread.Sleep(2000);
                Assert.That(profilePageObj.EarnTargetLbl.Text, Is.EqualTo(profile[0].EarnTarget), "Eran target has not been updated");
            }
        }
    }
}
