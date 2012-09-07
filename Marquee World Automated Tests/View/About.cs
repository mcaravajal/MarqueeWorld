using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;
using Marquee_World_Automated_Tests.Tests;

namespace Marquee_World_Automated_Tests.View
{
    public class About
    {
        public void NavigateToAbout()
        {
            Login loginview = new Login();
            loginview.LoginSuccesfullyGenearlUser();
            Browser.Driver.FindElement(By.CssSelector("a[href='about.php']")).Click();
            Browser.Instance.Wait(By.ClassName("body_of_text"));
        }
    }
}
