using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marquee_World_Automated_Tests.View;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.Tests
{
    [TestClass]
    class Login
    {
        //
        //Make a log in with a valid Artist
        //
        [TestMethod]
        public void LoginSuccesfullyArtistUser()
        {
            Login(ConfigUtil.GetString("Marquee.user.artist"), ConfigUtil.GetString("Marquee.pass.artist"));
            Assert.IsTrue(IsElementPresent(By.Id("")));
        }
        //
        //Make a log in with a valid General user
        //
        [TestMethod]
        public void LoginSuccesfullyGenearlUser()
        {
            Login(ConfigUtil.GetString("Marquee.user.general"), ConfigUtil.GetString("Marquee.pass.general"));
            Assert.IsTrue(IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginPasswordEmpty()
        {
            Login(ConfigUtil.GetString("Marquee.user.general"), "");
            Assert.IsTrue(IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginUserEmpty()
        {
            Login("", ConfigUtil.GetString("Marquee.pass.general"));
            Assert.IsTrue(IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginUserAndPasswordEmpty()
        {
            Login("", "");
            Assert.IsTrue(IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginGeneralPasswordWrong()
        {
            Login(ConfigUtil.GetString("Marquee.user.general"), "WrongPassword");
            Assert.IsTrue(IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginGeneralUserWrong()
        {
            Login("UserName@worng.com", ConfigUtil.GetString("Marquee.pass.general"));
            Assert.IsTrue(IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginArtistPasswordWrong()
        {
            Login(ConfigUtil.GetString("Marquee.user.artist"), "WrongPassword");
            Assert.IsTrue(IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginArtistUserWrong()
        {
            Login("UserName@worng.com", ConfigUtil.GetString("Marquee.pass.artist"));
            Assert.IsTrue(IsElementPresent(By.Id("")));
        }
        //
        //
        //
    }
}
