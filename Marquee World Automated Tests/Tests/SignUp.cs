using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marquee_World_Automated_Tests.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.Tests
{
    [TestClass]
    public class SignUp
    {
        [TestInitialize]
        public void InitTest()
        {
            Browser.Instance.Init();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Browser.Instance.Close();
        }
        //
        //Register a General User succesfully
        //
        [TestMethod]
        public void RegisterGeneralSuccesfully()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email,email, ConfigUtil.GetString("Marquee.register.pass"),true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.subtitle"),"Thank You for Registering"));
          
        }
        //
        //Register a Artist User succesfully
        //
        [TestMethod]
        public void RegisterArtistSuccesfully()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email,email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"),true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.subtitle"), "Thank You for Registering"));
        }
        //
        //As a General - Email not matching 
        //
        [TestMethod]
        public void RegisterEmailNotMatchAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email,"email@dontmatch.com", ConfigUtil.GetString("Marquee.register.pass"), true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password!"));
        }
        //
        //As an Artist - Email not matching 
        //
        [TestMethod]
        public void RegisterEmailNotMatchAsArtist()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password!"));
        }
        //
        //As an Artis - Duplicate User (same email) login
        //
        [TestMethod]
        public void RegisterEmailDuplicateAsArtist()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.User.General");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "This email already exist in our system.  Please enter a new email, or if you forgot your password you may "));
        }
        //
        //As a General - Duplicate User (same email) 
        //
        [TestMethod]
        public void RegisterEmailDuplicateAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.User.General");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, "email@dontmatch.com", ConfigUtil.GetString("Marquee.register.pass"), true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "This email already exist in our system.  Please enter a new email, or if you forgot your password you may "));
        }
        //
        //Invalid Artist sign up - Empty Band/Artist Name field
        //
        [TestMethod]
        public void RegisterEmptyBandArtisNameFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.User.General");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), "", ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
    }
}

