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
    [TestClass]
    public class SignUp
    {
        [TestInitialize]
        public void InitTest()
        {
            Browser.Instance.Init();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Browser.Instance.Close();
        }
        //
        //Register a General User succesfully
        //
        [TestMethod]
        public void RegisterGeneralSuccesfully()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterGeneralSuccesfully");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.subtitle"),"Thank You for Registering"));
          
        }
        //
        //Register a Artist User succesfully
        //
        [TestMethod]
        public void RegisterArtistSuccesfully()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterArtistSuccesfully");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.subtitle"), "Thank You for Registering"));
        }
        //
        //As a General - Email not matching 
        //
        [TestMethod]
        public void RegisterEmailNotMatchAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, "email@dontmatch.com", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmailNotMatchAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password!"));
        }
        //
        //As an Artist - Email not matching 
        //
        [TestMethod]
        public void RegisterEmailNotMatchAsArtist()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmailNotMatchAsArtist");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password!"));
        }
        //
        //As an Artis - Duplicate User (same email) login
        //
        [TestMethod]
        public void RegisterEmailDuplicateAsArtist()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.User.General");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmailDuplicateAsArtist");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "This email already exist in our system.  Please enter a new email, or if you forgot your password you may "));
        }
        //
        //As a General - Duplicate User (same email) 
        //
        [TestMethod]
        public void RegisterEmailDuplicateAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.User.General");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, "email@dontmatch.com", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmailDuplicateAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "This email already exist in our system.  Please enter a new email, or if you forgot your password you may "));
        }
        //
        //Invalid Artist sign up - Empty Band/Artist Name field
        //
        [TestMethod]
        public void RegisterEmptyBandArtisNameFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), "", ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptyBandArtisNameFieldAsArtis");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty Confirm Email Address field
        //
        [TestMethod]
        public void RegisterEmptyConfirmEmailAddressFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), "", email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptyConfirmEmailAddressFieldAsArtis");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty DOB field
        //
        [TestMethod]
        public void RegisterEmptyDOBFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),99,99,99,false, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptyDOBFieldAsArtis");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty Email Address field
        //
        [TestMethod]
        public void RegisterEmptyEmailAddressFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, "", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptyEmailAddressFieldAsArtis");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty First Name field
        //
        [TestMethod]
        public void RegisterEmptyFirstNameFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser("", ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptyFirstNameFieldAsArtis");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty Last Name field
        //
        [TestMethod]
        public void RegisterEmptyLastNameFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), "",0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptyLastNameFieldAsArtis");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty Password field
        //
        [TestMethod]
        public void RegisterEmptyPasswordFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, "", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptyPasswordFieldAsArtis");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty Postal Code field
        //
        [TestMethod]
        public void RegisterEmptyPostalCodeFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, "", email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptyPostalCodeFieldAsArtis");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty Re-Enter Password field
        //
        [TestMethod]
        public void RegisterEmptyReEnterPasswordFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), "", ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptyReEnterPasswordFieldAsArtis");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty Social Networks field
        //
        [TestMethod]
        public void RegisterEmptySocialNetworksFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterEmptySocialNetworksFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.subtitle"), "Thank You for Registering"));
        }
        //
        //Invalid Artist sign up - Invalid char Band/Artist Name field
        //
        [TestMethod]
        public void RegisterInvalidCharBandArtistNameFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), "!#$%&/", "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharBandArtistNameFieldAsArtis");
            //Unable to validate this Assert because there is a bug when validating invalid chars for Band/Artis Name field
            //Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div.subtitle"), "Thank You for Registering"));
        }
        //
        //Invalid Artist sign up - Invalid char Confirm Email Address field
        //
        [TestMethod]
        public void RegisterInvalidCharConfirmEmailAdressFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, "!$%$&", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharConfirmEmailAdressFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password"));
        }
        //
        //Invalid Artist sign up - Invalid char DOB field
        //
        [TestMethod]
        public void RegisterInvalidCharDOBFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,2011,true, ConfigUtil.GetString("Marquee.register.zip"), email, "!$%$&", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharDOBFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password"));
        }
        //
        //Invalid Artist sign up - Invalid char Email Address field
        //
        [TestMethod]
        public void RegisterInvalidCharEmailAdressFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), "!#$%", email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharEmailAdressFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Please enter a valid email address"));
        }
        //
        //Invalid Artist sign up - Invalid char First Name field
        //
        [TestMethod]
        public void RegisterInvalidCharFirstNameFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser("!%&/()/", ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharFirstNameFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your first name can only contain letters"));
        }
        //
        //Invalid Artist sign up - Invalid char Last Name field
        //
        [TestMethod]
        public void RegisterInvalidCharLastNameFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), "!$%&%&",0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharLastNameFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your last name can only contain letters"));
        }
        //
        //Invalid Artist sign up - Invalid char Password field
        //
        [TestMethod]
        public void RegisterInvalidCharPasswordFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, "$%&$%", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharPasswordFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Please enter a valid password!"));
        }
        //
        //Invalid Artist sign up - Invalid char Postal Code field
        //
        [TestMethod]
        public void RegisterInvalidCharPostalCodeFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, "%&/%$&", email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharPostalCodeFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your Zip/Postal code is not the correct format. U.S. and Canadian accounts only."));
        }
        //
        //Invalid Artist sign up - Invalid char Re-Enter Password field
        //
        [TestMethod]
        public void RegisterInvalidCharReEnterPasswordFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), "$%$%&$%", ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharReEnterPasswordFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your password did not match the confirmed password!"));
        }
        //
        //Invalid Artist sign up - Invalid char Social Networks field
        //
        [TestMethod]
        public void RegisterInvalidCharSocialNetworksFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "%&/%&", "%&/", "&/$%$", "$$%%&&", true,true);
            //Unable to validate this Assert because there is a bug when validating invalid chars for Social Networks Name field
            Browser.Instance.TakeScreenshot("RegisterInvalidCharSocialNetworksFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your password did not match the confirmed password!"));

        }
        //
        //Invalid Artist sign up - Long char Band/Artist Name field
        //
        [TestMethod]
        public void RegisterInvalidLongCharBandArtistFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true,true);
            //Unable to validate this Assert because there is a bug when validating invalid chars for Band/Artist Name field
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharBandArtistFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your password did not match the confirmed password!"));
        }
        //
        //Invalid Artist sign up - Long char Emails Address field
        //
        [TestMethod]
        public void RegisterInvalidLongCharEmailsAddressFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = "testasdasdojasndoasdnaosdnasodnasodnasodnaosdnasodna@test.com";
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), "testnametestnametestnametestnametestnametestnametestname", "", "", "", "", true,true);
            //Unable to validate this Assert because there is a bug when validating long chars for emails field
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharEmailsAddressFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your password did not match the confirmed password!"));
        }
        //
        //Invalid Artist sign up - Long char Social Networks field
        //
        [TestMethod]
        public void RegisterInvalidLongCharSocialNetworksFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "testnametestnametestnametestnametestnametestname", "testnametestnametestnametestnametestnametestname", "testnametestnametestnametestnametestnametestname", "testnametestnametestnametestnametestnametestname", true,true);
            //Unable to validate this Assert because there is a bug when validating long chars for Social Networks field
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharSocialNetworksFieldAsArtis");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your password did not match the confirmed password!"));
        }
        //
        //Invalid General sign up - Empty Confirm Email Address field
        //
        [TestMethod]
        public void RegisterInvalidEmptyConfirmEmailAddressFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, "", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidEmptyConfirmEmailAddressFieldAsGeneral");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid General sign up - Empty Email Address field
        //
        [TestMethod]
        public void RegisterInvalidEmptyEmailAddressFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), "", email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidEmptyEmailAddressFieldAsGeneral");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid General sign up - Empty First Name Field
        //
        [TestMethod]
        public void RegisterInvalidEmptyFirstNameFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser("", ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidEmptyFirstNameFieldAsGeneral");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid General sign up - Empty Gender
        //
        [TestMethod]
        public void RegisterInvalidEmptyGenderFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser("", ConfigUtil.GetString("Marquee.register.lastname"),0,0,0,false, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidEmptyGenderFieldAsGeneral");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid General sign up - Empty Last Name field
        //
        [TestMethod]
        public void RegisterInvalidEmptyLastNameFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), "", 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidEmptyLastNameFieldAsGeneral");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid General sign up - Empty Password field
        //
        [TestMethod]
        public void RegisterInvalidEmptyPasswordFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), "", email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidEmptyPasswordFieldAsGeneral");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid General sign up - Empty Postal Code field
        //
        [TestMethod]
        public void RegisterInvalidEmptyPostalCodeFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, "", email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidEmptyPostalCodeFieldAsGeneral");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid General sign up - Empty Re-Enter Password field
        //
        [TestMethod]
        public void RegisterInvalidEmptyReEnterPasswordFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), "", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidEmptyReEnterPasswordFieldAsGeneral");
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid General sign up - Invalid char Confirm Email Address field
        //
        [TestMethod]
        public void RegisterInvalidCharConfirmEmailAddressFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, "(/&%/%&/@mail.com", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharConfirmEmailAddressFieldAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password!"));
        }
        //
        //Invalid General sign up - Invalid char Email Address field
        //
        [TestMethod]
        public void RegisterInvalidCharEmailAddressFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), "%&/%&/%&/@email.com", email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharEmailAddressFieldAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password!"));
        }
        //
        //Invalid General sign up - Invalid char First Name field
        //
        [TestMethod]
        public void RegisterInvalidCharFirstNameFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser("%&/%&/%&/%&%/", ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharFirstNameFieldAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your first name can only contain letters"));
        }
        //
        //Invalid General sign up - Invalid char Last Name field
        //
        [TestMethod]
        public void RegisterInvalidCharLastNameFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), "%&/%&/%&", 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharLastNameFieldAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your last name can only contain letters"));
        }
        //
        //Invalid General sign up - Invalid char Password field
        //
        [TestMethod]
        public void RegisterInvalidCharPasswordFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, "%&//(&/(&/", ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharPasswordFieldAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Please enter a valid password!"));
        }
        //
        //Invalid General sign up - Invalid char Postal Code field
        //
        [TestMethod]
        public void RegisterInvalidCharPostalCodeFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, "&/(&/(&/(&¡/(", email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharPostalCodeFieldAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your Zip/Postal code is not the correct format. U.S. and Canadian accounts only."));
        }
        //
        //Invalid General sign up - Invalid char Re-Enter Password field
        //
        [TestMethod]
        public void RegisterInvalidCharReEnterPasswordCodeFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), "&/(&/(&/(&", true,true);
            Browser.Instance.TakeScreenshot("RegisterInvalidCharReEnterPasswordCodeFieldAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your password did not match the confirmed password!"));
        }
        //
        //Invalid General sign up - Long char Confirm Email Address field
        //
        [TestMethod]
        public void RegisterInvalidLongCharConfirmEmailAddressCodeFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, "testnametestnametestnametestnametestname", "testnametestnametestnametestnametestname", true,true);
            //Unable to verify this test case because there is a bug when validating the long char. Also need to change the Assert error message
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharConfirmEmailAddressCodeFieldAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your Zip/Postal code is not the correct format. U.S. and Canadian accounts only."));
        }
        //
        //Invalid General sign up - Long char Email Address field
        //
        [TestMethod]
        public void RegisterInvalidLongCharEmailAddressFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, "testnametestnametestnametestnametestname", "testnametestnametestnametestnametestname", true,true);
            //Unable to verify this test case because there is a bug when validating the long char. Also need to change the Assert error message
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharEmailAddressFieldAsGeneral");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your Zip/Postal code is not the correct format. U.S. and Canadian accounts only."));
        }
        //
        //Invalid General sign up - Long char First Name field
        // 
        [TestMethod]
        public void RegisterInvalidLongCharFirstNameFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            string name = "FirstNameFirstNameFirstName";
            RegisterView.RegisterGeneralUser(name, ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true,false);
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharFirstNameFieldAsGeneral");
            Assert.AreEqual(Browser.Driver.FindElement(By.Id("fname")).GetAttribute("value").Length, 20);
        }
        //
        //Invalid General sign up - Long char Last Name field
        // 
        [TestMethod]
        public void RegisterInvalidLongCharLastNameFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            string name = "ddsfdsfdsfdssdfsdfsdffdsdfsdsfdsfsfdsfdsfdsfdsfsf";
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), name, 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true, false);
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharLastNameFieldAsGeneral");
            Assert.AreEqual(Browser.Driver.FindElement(By.Id("lname")).GetAttribute("value").Length, 40);
        }
        //
        //Invalid General sign up - Long char Password field
        // 
        [TestMethod]
        public void RegisterInvalidLongCharPasswordFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            string name = "ddsfdsfdsfdssdfsdfsdffdsdfsdsfdsfsfdsfdsfdsfdsfsf";
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, name, ConfigUtil.GetString("Marquee.register.pass"), true, false);
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharPasswordFieldAsGeneral");
            Assert.AreEqual(Browser.Driver.FindElement(By.Name("password1")).GetAttribute("value").Length, 20);
        }
        //
        //Invalid General sign up - Long char Postal Code field
        // 
        [TestMethod]
        public void RegisterInvalidLongCharPostalCodeFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            string name = "ddsfdsfdsfdssdfsdfsdffdsdfsdsfdsfsfdsfdsfdsfdsfsf";
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, name, email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true, false);
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharPostalCodeFieldAsGeneral");
            Assert.AreEqual(Browser.Driver.FindElement(By.Id("zip")).GetAttribute("value").Length, 7);
        }
        //
        //Invalid General sign up - Long char Re-Enter Password field
        // 
        [TestMethod]
        public void RegisterInvalidLongCharReEnterPasswordFieldAsGeneral()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            string name = "ddsfdsfdsfdssdfsdfsdffdsdfsdsfdsfsfdsfdsfdsfdsfsf";
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), 0, 0, 0, true, ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), name, true, false);
            Browser.Instance.TakeScreenshot("RegisterInvalidLongCharReEnterPasswordFieldAsGeneral");
            Assert.AreEqual(Browser.Driver.FindElement(By.Name("password2")).GetAttribute("value").Length, 20);
        }
       

    }
}

