using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Marquee_World_Automated_Tests.View
{
    public class Register
    {
        IWebDriver driver;
        public Register(IWebDriver newdriver)
        {
            this.driver = newdriver;
        }
        //
        //Register as General User
        //
        public void RegisterUser(string name, string lastname, string Zip, string email, string password, bool newsletter)
        {
            driver.FindElement(By.LinkText("Sign Up")).Click();
            Wait(By.Id("fname"));
            this.driver.FindElement(By.Id("fname")).SendKeys(name);
            this.driver.FindElement(By.Id("lname")).SendKeys(password);
            this.driver.FindElement(By.Id("male")).Click();
            this.driver.FindElement(By.Id("zip")).SendKeys(Zip);
            this.driver.FindElement(By.Id("email1")).SendKeys(email);
            this.driver.FindElement(By.Id("email2")).SendKeys(email);
            this.driver.FindElement(By.Name("password1")).SendKeys(password);
            this.driver.FindElement(By.Name("password2")).SendKeys(password);            
            if (newsletter)
                this.driver.FindElement(By.Id("newsletter")).Click();
            this.driver.FindElement(By.Id("submitform")).Click();
            Wait(By.CssSelector("div.subtitle"));
        }
        //
        //Register as Artist User
        //
        public void RegisterUser(string name, string lastname, string Zip, string email, string password, bool artist, string band, string website, string facebook, string myspace, string twitter, bool newsletter)
        {
            this.driver.FindElement(By.Id("fname")).SendKeys(name);
            this.driver.FindElement(By.Id("lname")).SendKeys(password);
            this.driver.FindElement(By.Id("male")).Click();
            this.driver.FindElement(By.Id("zip")).SendKeys(Zip);
            this.driver.FindElement(By.Id("email1")).SendKeys(email);
            this.driver.FindElement(By.Id("email2")).SendKeys(email);
            this.driver.FindElement(By.Name("password1")).SendKeys(password);
            this.driver.FindElement(By.Name("password2")).SendKeys(password);
            this.driver.FindElement(By.Id("artist")).Click();
            this.driver.FindElement(By.Name("band")).SendKeys(band);
            this.driver.FindElement(By.Name("website")).SendKeys(website);
            this.driver.FindElement(By.Name("facebook")).SendKeys(facebook);
            this.driver.FindElement(By.Name("myspace")).SendKeys(myspace);
            this.driver.FindElement(By.Name("twitter")).SendKeys(twitter);
            this.driver.FindElement(By.Id("eula_checkbox")).Click();
            if (newsletter)
            {
                this.driver.FindElement(By.Id("newsletter")).Click();
            }
            this.driver.FindElement(By.Id("submitform")).Click();
            Wait();
        }
    }
}
