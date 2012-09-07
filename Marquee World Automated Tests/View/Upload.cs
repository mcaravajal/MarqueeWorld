using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;
using Marquee_World_Automated_Tests.Tests;
using System.Collections.ObjectModel;

namespace Marquee_World_Automated_Tests.View
{
    class Upload
    {
        public void UploadVideo(string path,string tittle,string description,int check)
        {
            Login login = new Login();
            login.LoginSuccesfullyArtistUser();
            Browser.Driver.FindElement(By.CssSelector("a[href='upload.php']")).Click();
            IWebElement uploadfile = Browser.Driver.FindElement(By.Id("file"));
            uploadfile.SendKeys(path);
            Browser.Driver.FindElement(By.Id("title")).SendKeys(tittle);
            Browser.Driver.FindElement(By.Id("description")).SendKeys(description);
            for (int x = 0; x < check; x++)
            {
                while (true)
                {
                    IWebElement ElementToCheck = Browser.Instance.GetRandomElement(By.CssSelector("div.scroll_checkboxes label input"));
                    if (!ElementToCheck.Selected)
                    {
                        ElementToCheck.Click();
                        break;
                        
                    }
                }
            }
        }
    }
}
