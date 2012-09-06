using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.View
{
    public class ForgotPassword
    {
        public void ForgotPasswordAction(string email)
        {
            Browser.Driver.FindElement(By.LinkText("Forgot password?")).Click();
            Browser.Instance.Wait(By.Id("icons"));
            Browser.Driver.FindElement(By.CssSelector("fieldset input[name='email']")).SendKeys(email);
            Browser.Driver.FindElement(By.CssSelector("fieldset input[name='submit']")).Click();
        }
    }
}
