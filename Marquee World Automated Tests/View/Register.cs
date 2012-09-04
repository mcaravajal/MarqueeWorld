using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
            Browser.Driver.FindElement(By.Id("submitform")).Click();
            Browser.Instance.Wait(By.CssSelector("div.subtitle"));
        }

        //
        //Register as Artist User
        //
        public void RegisterArtistUser(string name, string lastname, string Zip, string email, string password, string band, string website, string facebook, string myspace, string twitter, bool newsletter)
        {
            RegisterUser(name, lastname, Zip, email, password, newsletter);
            Browser.Driver.FindElement(By.Id("artist")).Click();
            Browser.Driver.FindElement(By.Name("band")).SendKeys(band);
            Browser.Driver.FindElement(By.Name("website")).SendKeys(website);
            Browser.Driver.FindElement(By.Name("facebook")).SendKeys(facebook);
            Browser.Driver.FindElement(By.Name("myspace")).SendKeys(myspace);
            Browser.Driver.FindElement(By.Name("twitter")).SendKeys(twitter);
            Browser.Driver.FindElement(By.Id("eula_checkbox")).Click();
            Browser.Driver.FindElement(By.Id("submitform")).Click();
            Browser.Instance.Wait();
        }

        private void RegisterUser(string name, string lastname, string Zip, string email, string password, bool newsletter){
            Browser.Driver.FindElement(By.LinkText("Sign Up")).Click();
            Browser.Instance.Wait(By.Id("fname"));
            Browser.Driver.FindElement(By.Id("fname")).SendKeys(name);
            Browser.Driver.FindElement(By.Id("lname")).SendKeys(lastname);
            SelectElement selector = new SelectElement(Browser.Driver.FindElement(By.Name("month")));
            selector.SelectByValue((new Random().Next(01,12)).ToString());
            selector = new SelectElement(Browser.Driver.FindElement(By.Name("day")));
            selector.SelectByValue((new Random().Next(1, 31)).ToString());
            selector = new SelectElement(Browser.Driver.FindElement(By.Name("year")));
            selector.SelectByValue((new Random().Next(1937, 2012)).ToString());
            Browser.Driver.FindElement(By.Id("male")).Click();
            Browser.Driver.FindElement(By.Id("zip")).SendKeys(Zip);
            Browser.Driver.FindElement(By.Id("email1")).SendKeys(email);
            Browser.Driver.FindElement(By.Id("email2")).SendKeys(email);
            Browser.Driver.FindElement(By.Name("password1")).SendKeys(password);
            Browser.Driver.FindElement(By.Name("password2")).SendKeys(password);            
            if (newsletter)
                Browser.Driver.FindElement(By.Id("newsletter")).Click();
        }
    }
}
