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
            driver.FindElement(By.Id("email")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Name("submit")).Submit();
            Wait();
        }
    }
}
