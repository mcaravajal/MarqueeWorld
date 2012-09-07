using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;
using Marquee_World_Automated_Tests.Tests;

namespace Marquee_World_Automated_Tests.View
{
    public class FAQ
    {
        public void NavigateToFAQ()
        {
            Login loginview = new Login();
            loginview.LoginSuccesfullyGenearlUser();
            Browser.Driver.FindElement(By.CssSelector("a[href='faq.php']")).Click();
            Browser.Instance.Wait(By.Id("site_content"));
        }
    }
}
