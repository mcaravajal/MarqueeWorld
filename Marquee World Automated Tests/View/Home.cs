using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.View
{
    class Home
    {
        public void Login(string username, string password)
        {
            TestBase.Driver.FindElement(By.Id("email")).SendKeys(username);
            TestBase.Driver.FindElement(By.Id("password")).SendKeys(password);
            TestBase.Driver.FindElement(By.Name("submit")).Submit();
            TestBase.Instance.Wait();
        }
    }
}
