using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.View
{
    public class Account
    {
        public void EditFirstName(string name)
        {
            Browser.Driver.FindElement(By.Id("first")).Click();
            Browser.Driver.FindElement(By.Id("input_first")).SendKeys(name);
            Browser.Driver.FindElement(By.Id("input_first")).SendKeys(Keys.Enter);
            string aux= Browser.Driver.FindElement(By.Id("input_first")).GetAttribute("Style=");
        }
    }
}
