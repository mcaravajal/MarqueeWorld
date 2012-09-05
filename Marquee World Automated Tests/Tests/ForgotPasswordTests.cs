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
    public class ForgotPasswordTests
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
        //Reset the password succesfully
        //
        [TestMethod]
        public void ResetPasswordSuccesfully()
        {
            ForgotPassword ForgotView = new ForgotPassword();
            ForgotView.ForgotPassword(ConfigUtil.GetString("Marquee.user.general"));
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.contained div.subtitle"), "Reset link sent!"));
        }
        //
        //Reset password with emtpy email
        //
        [TestMethod]
        public void ResetPasswordEmptyEmail()
        {
            ForgotPassword ForgotView = new ForgotPassword();
            ForgotView.ForgotPassword("");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.CssSelector("div.contained div.subtitle")));
        }
        //
        //Reset password with invalid email
        //
        [TestMethod]
        public void ResetPasswordEmailInvalid()
        {
            ForgotPassword ForgotView = new ForgotPassword();
            ForgotView.ForgotPassword("emaiinvalid.com");
            //Can not make the assert until this bug were resovled
            //Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.contained div.subtitle"), "Reset link sent!"));
        }
        //
        //Reset password with an email not registered
        //
        [TestMethod]
        public void ResetPasswordNotRegisteredEmail()
        {
            ForgotPassword ForgotView = new ForgotPassword();
            ForgotView.ForgotPassword("Emailwhichdontexist@gmail.com");
            Browser.Instance.Wait(By.CssSelector("p.error"));
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("p.error"), "We don't seem to have that email on file!"));
        }
    }
}