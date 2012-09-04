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

        [TestMethod]
        public void RegisterGeneralSuccesfully()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email,ConfigUtil.GetString("Marquee.register.pass"),true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.subtitle"),"Thank You for Registering"));
        }
        [TestMethod]
        public void RegisterArtistSuccesfully()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"),true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.subtitle"), "Thank You for Registering"));
        }
        
    }
}
