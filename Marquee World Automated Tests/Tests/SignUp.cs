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
        [TestMethod]
        public void RegisterGeneralSuccesfully()
        {
            Register RegisterView = new Register(driver);
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email,ConfigUtil.GetString("Marquee.register.pass"),true);
            Assert.IsTrue(IsTextPresent(driver.FindElement(By.CssSelector("div.subtitle")),"Thank You for Registering"));
        }
        
    }
}
