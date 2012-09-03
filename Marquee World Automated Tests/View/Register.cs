using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.View
{
    public class Register
    {        
        //
        //Register as General User
        //
        public void RegisterGeneralUser(string name, string lastname, string Zip, string email, string password, bool newsletter)
        {
            RegisterUser(name, lastname, Zip, email, password, newsletter);
            TestBase.Driver.FindElement(By.Id("submitform")).Click();
            TestBase.Instance.Wait(By.CssSelector("div.subtitle"));
        }

        //
        //Register as Artist User
        //
        public void RegisterArtistUser(string name, string lastname, string Zip, string email, string password, bool artist, string band, string website, string facebook, string myspace, string twitter, bool newsletter)
        {
            RegisterUser(name, lastname, Zip, email, password, newsletter);
            TestBase.Driver.FindElement(By.Id("artist")).Click();
            TestBase.Driver.FindElement(By.Name("band")).SendKeys(band);
            TestBase.Driver.FindElement(By.Name("website")).SendKeys(website);
            TestBase.Driver.FindElement(By.Name("facebook")).SendKeys(facebook);
            TestBase.Driver.FindElement(By.Name("myspace")).SendKeys(myspace);
            TestBase.Driver.FindElement(By.Name("twitter")).SendKeys(twitter);
            TestBase.Driver.FindElement(By.Id("eula_checkbox")).Click();
            TestBase.Driver.FindElement(By.Id("submitform")).Click();
            TestBase.Instance.Wait();
        }
    

        private void RegisterUser(string name, string lastname, string Zip, string email, string password, bool newsletter){
            TestBase.Driver.FindElement(By.LinkText("Sign Up")).Click();
            TestBase.Instance.Wait(By.Id("fname"));
            TestBase.Driver.FindElement(By.Id("fname")).SendKeys(name);
            TestBase.Driver.FindElement(By.Id("lname")).SendKeys(password);
            TestBase.Driver.FindElement(By.Id("male")).Click();
            TestBase.Driver.FindElement(By.Id("zip")).SendKeys(Zip);
            TestBase.Driver.FindElement(By.Id("email1")).SendKeys(email);
            TestBase.Driver.FindElement(By.Id("email2")).SendKeys(email);
            TestBase.Driver.FindElement(By.Name("password1")).SendKeys(password);
            TestBase.Driver.FindElement(By.Name("password2")).SendKeys(password);            
            if (newsletter)
                TestBase.Driver.FindElement(By.Id("newsletter")).Click();
        }
    }
}
