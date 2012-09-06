using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;
using Marquee_World_Automated_Tests.Tests;

namespace Marquee_World_Automated_Tests.View
{
    public class UpgradeAccount
    {
        public void UpgradeToArtist(string name,string website,string facebook,string myspace, string twitter)
        {
            Login login = new Login();
            login.LoginSuccesfullyGenearlUser();
            Browser.Driver.FindElement(By.Id("account")).Click();
            Browser.Instance.Wait(By.Name("band"));
            Browser.Driver.FindElement(By.Name("band")).SendKeys(name);
            Browser.Driver.FindElement(By.Name("website")).SendKeys(website);
            Browser.Driver.FindElement(By.Name("facebook")).SendKeys(facebook);
            Browser.Driver.FindElement(By.Name("myspace")).SendKeys(myspace);
            Browser.Driver.FindElement(By.Name("twitter")).SendKeys(twitter);
            Browser.Driver.FindElement(By.Id("eula_checkbox")).Click();
            Browser.Driver.FindElement(By.Id("submitform")).Click();            
        }
    }
}
