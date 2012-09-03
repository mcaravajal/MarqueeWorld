using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.View
{
    static class Register : TestBase
    {
        //
        //Register as General User
        //
        public void Register(string name, string lastname, string Zip, string email, string password, bool newsletter)
        {
            driver.FindElement(By.Id("fname")).SendKeys(name);
            driver.FindElement(By.Id("lname")).SendKeys(password);
            driver.FindElement(By.Id("male")).Click();
            driver.FindElement(By.Id("zip")).SendKeys(Zip);
            driver.FindElement(By.Id("email1")).SendKeys(email);
            driver.FindElement(By.Id("email2")).SendKeys(email);
            driver.FindElement(By.Name("password1")).SendKeys(password);
            driver.FindElement(By.Name("password2")).SendKeys(password);            
            if (newsletter)
                driver.FindElement(By.Id("newsletter")).Click();
            driver.FindElement(By.Id("submitform")).Click();
            Wait();
        }
        //
        //Register as Artist User
        //
        public void Register(string name, string lastname, string Zip, string email, string password, bool artist, string band, string website, string facebook, string myspace, string twitter, bool newsletter)
        {
            driver.FindElement(By.Id("fname")).SendKeys(name);
            driver.FindElement(By.Id("lname")).SendKeys(password);
            driver.FindElement(By.Id("male")).Click();
            driver.FindElement(By.Id("zip")).SendKeys(Zip);
            driver.FindElement(By.Id("email1")).SendKeys(email);
            driver.FindElement(By.Id("email2")).SendKeys(email);
            driver.FindElement(By.Name("password1")).SendKeys(password);
            driver.FindElement(By.Name("password2")).SendKeys(password);
            driver.FindElement(By.Id("artist")).Click();
            driver.FindElement(By.Name("band")).SendKeys(band);
            driver.FindElement(By.Name("website")).SendKeys(website);
            driver.FindElement(By.Name("facebook")).SendKeys(facebook);
            driver.FindElement(By.Name("myspace")).SendKeys(myspace);
            driver.FindElement(By.Name("twitter")).SendKeys(twitter);
            driver.FindElement(By.Id("eula_checkbox")).Click();
            if (newsletter)
            {
                driver.FindElement(By.Id("newsletter")).Click();
            }
            driver.FindElement(By.Id("submitform")).Click();
            Wait();
        }
    }
}
