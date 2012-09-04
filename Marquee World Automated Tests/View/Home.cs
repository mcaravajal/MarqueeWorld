using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.View
{
    public class Home
    {
        public void Login(string username, string password)
        {
            Browser.Driver.FindElement(By.Id("email")).SendKeys(username);
            Browser.Driver.FindElement(By.Id("password")).SendKeys(password);
            Browser.Driver.FindElement(By.Name("submit")).Submit();
            Browser.Instance.Wait(By.Id("login_hp"));
        }
    }
}
