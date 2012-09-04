using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marquee_World_Automated_Tests.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.Tests
{
    public class EditAccount
    {
        public void EditNameSuccesfully()
        {
            Account accountView = new Account();
            string newname= (ConfigUtil.GetString("Marquee.account.name")+new Random());
            accountView.EditFirstName(newname);
            Browser.Instance.Wait(By.CssSelector("div#holder_first input[style='display: none; ']"));
            
        }
    }
}
