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
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email,email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"),true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email,"email@dontmatch.com", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, "email@dontmatch.com", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), "", ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), "", email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
        //
        //Invalid Artist sign up - Empty DOB field
        //
        //[TestMethod]
        //public void RegisterEmptyDOBFieldAsArtis()
        //{
        //    Register RegisterView = new Register();
        //    string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
        //    RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
        //    Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        //}
        //
        //Invalid Artist sign up - Empty Email Address field
        //
        [TestMethod]
        public void RegisterEmptyEmailAddressFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, "", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterArtistUser("", ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), "", ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, "", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), "", email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), "", ConfigUtil.GetString("Marquee.register.artist.name"), ConfigUtil.GetString("Marquee.register.artist.website"), ConfigUtil.GetString("Marquee.register.artist.facebook"), ConfigUtil.GetString("Marquee.register.artist.myspace"), ConfigUtil.GetString("Marquee.register.artist.twitter"), true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), "!#$%&/", "", "", "", "", true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, "!$%$&", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password"));
        }
        //
        //Invalid Artist sign up - Invalid char DOB field
        //
        //[TestMethod]
        //public void RegisterInvalidCharDOBFieldAsArtis()
        //{
        //    Register RegisterView = new Register();
        //    string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
        //    RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, "!$%$&", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
        //    Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your email did not match the confirmed password"));
        //}
        //
        //Invalid Artist sign up - Invalid char Email Address field
        //
        [TestMethod]
        public void RegisterInvalidCharEmailAdressFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), "!#$%", email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
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
            RegisterView.RegisterArtistUser("!%&/()/", ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), "!$%&%&", ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, "$%&$%", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), "%&/%$&", email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), "$%$%&$%", ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "%&/%&", "%&/", "&/$%$", "$$%%&&", true);
            //Unable to validate this Assert because there is a bug when validating invalid chars for Social Networks Name field
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
            //Unable to validate this Assert because there is a bug when validating invalid chars for Band/Artist Name field
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
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), "testnametestnametestnametestnametestnametestnametestname", "", "", "", "", true);
            //Unable to validate this Assert because there is a bug when validating long chars for emails field
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your password did not match the confirmed password!"));
        }
        //
        ////Invalid Artist sign up - Long char DOB field
        //
        //[TestMethod]
        //public void RegisterInvalidLongCharDOBFieldAsArtis()
        //{
        //    Register RegisterView = new Register();
        //    string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
        //    RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "", "", "", "", true);
        //    
        //    Assert.IsTrue(Browser.Instance.IsTextPresent(By.ClassName("error"), "Your password did not match the confirmed password!"));
        //}
        //
        //Invalid Artist sign up - Long char Social Networks field
        //
        [TestMethod]
        public void RegisterInvalidLongCharSocialNetworksFieldAsArtis()
        {
            Register RegisterView = new Register();
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            RegisterView.RegisterArtistUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, email, ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.artist.name"), "testnametestnametestnametestnametestnametestname", "testnametestnametestnametestnametestnametestname", "testnametestnametestnametestnametestnametestname", "testnametestnametestnametestnametestnametestname", true);
            //Unable to validate this Assert because there is a bug when validating long chars for Social Networks field
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
            RegisterView.RegisterGeneralUser(ConfigUtil.GetString("Marquee.register.name"), ConfigUtil.GetString("Marquee.register.lastname"), ConfigUtil.GetString("Marquee.register.zip"), email, "", ConfigUtil.GetString("Marquee.register.pass"), ConfigUtil.GetString("Marquee.register.pass"), true);
            Assert.IsFalse(Browser.Instance.IsElementPresent(By.ClassName("error")));
        }
    }
}

