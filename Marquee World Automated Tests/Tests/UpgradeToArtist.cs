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
    public class UpgradeToArtist
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
        public void UpgradeToArtistSuccesfully()
        {
            UpgradeAccount upgradeView = new UpgradeAccount();
            upgradeView.UpgradeToArtist(ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"));
            Browser.Instance.TakeScreenshot("UpgradeToArtistSuccesfully");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.contained h1"), "UPLOAD YOUR MUSIC"));
        }
    }
}
