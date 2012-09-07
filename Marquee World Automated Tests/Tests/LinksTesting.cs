﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marquee_World_Automated_Tests.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;
using OpenQA.Selenium;
using System.Reflection;

namespace Marquee_World_Automated_Tests.Tests
{
    [TestClass]
    public class LinksTesting
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
        public void NavigateToFacebook()
        {
            Home homeView = new Home();
            homeView.NavigateToSocialLink("facebook");
            Browser.Instance.Wait(5000);
            //This Test Case is failing right now
            Assert.AreEqual(Browser.Driver.Url, "https://www.facebook.com/home.php");
            //Assert.IsTrue(false);
        }
        [TestMethod]
        public void NavigateToTwitter()
        {
            Home homeView = new Home();
            homeView.NavigateToSocialLink("twitter");
            Browser.Instance.Wait(5000);
            Assert.AreEqual(Browser.Driver.Url, "https://twitter.com/marqueeworld");
        }
        [TestMethod]
        public void NavigateToGooglePlus()
        {
            Home homeView = new Home();
            homeView.NavigateToSocialLink("gplus");
            Browser.Instance.Wait(5000);
            //This Test Case is failing right now
            Assert.AreEqual(Browser.Driver.Url, "https://plus.google.com/up/search");
            //Assert.IsTrue(false);
        }
        [TestMethod]
        public void NavigateToAbout()
        {
            About abourView = new About();
            abourView.NavigateToAbout();
            Assert.AreEqual(Browser.Driver.FindElement(By.CssSelector("div.body_of_text h1")).Text, "ABOUT MARQUEE WORLD");
        }
        [TestMethod]
        public void NavigateToFAQ()
        {
            FAQ FAQView = new FAQ();
            FAQView.NavigateToFAQ();
            Assert.AreEqual(Browser.Driver.FindElement(By.CssSelector("section#site_content h1")).Text, "FAQs");
        }
    }
}
