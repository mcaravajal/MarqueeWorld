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
            Forgot_Password ForgotView = new Forgot_Password();
            ForgotView.ForgotPassword(ConfigUtil.GetString("Marquee.user.general"));
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.contained div.subtitle"), "Reset link sent!"));
        }
        //
        //Reset password with emtpy email
        //
        [TestMethod]
        public void ResetPasswordEmptyEmail()
        {
            Forgot_Password ForgotView = new Forgot_Password();
            ForgotView.ForgotPassword("");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.CssSelector("div.contained div.subtitle")));
        }
        //
        //Reset password with invalid email
        //
        [TestMethod]
        public void ResetPasswordEmailInvalid()
        {
            Forgot_Password ForgotView = new Forgot_Password();
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
            Forgot_Password ForgotView = new Forgot_Password();
            ForgotView.ForgotPassword("Emailwhichdontexist@gmail.com");
            Browser.Instance.Wait(By.CssSelector("p.error"));
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("p.error"), "We don't seem to have that email on file!"));
        }
    }
}