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
    public class EditAccount
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
        //Edit name Succesfully
        //
        [TestMethod]
        public void EditNameSuccesfully()
        {
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname= ConfigUtil.GetString("Marquee.account.name")+" " + new Random().Next(1000);
            accountView.EditFirstName(newname);
            string aux= string.Empty;
            while (aux != "display: none;")
            {
                aux = Browser.Driver.FindElement(By.Id("input_first")).GetAttribute("Style");
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_first"), newname));
        }
        //
        //Edit name leaving the input emtpy
        //
        [TestMethod]
        public void EditNameEmtpy()
        {
            Account accountView = new Account();
            accountView.EditFirstName("");
            //Check if it leave in blank
            Assert.AreEqual(Browser.Driver.FindElement(By.Id("input_first")).GetAttribute("Style"), "display: inline;");
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            //Check if it was saved corectly
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_first"),""));
        }
        //
        //Edit long name
        //
        [TestMethod]
        public void EditlongName()
        {
            Account accountView = new Account();
            accountView.EditFirstName("loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooongname");
            //Can not check because is not checking the name size
            //Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_first"), ""));
        }
        //
        //Edit name with invalid chars
        //
        [TestMethod]
        public void EditNameInvalid()
        {
            Account accountView = new Account();
            accountView.EditFirstName("!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○");
            //Can not check because is not checking the name inupts
            //Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_first"), ""));
        }
        //
        //Edit Lastname Succesfully
        //
        [TestMethod]
        public void EditLastNameSuccesfully()
        {
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.account.lastname") + " " + new Random().Next(1000);
            accountView.EditLasttName(newname);
            string aux = string.Empty;
            while (aux != "display: none;")
            {
                aux = Browser.Driver.FindElement(By.Id("input_last")).GetAttribute("Style");
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_last"), newname));
        }
        //
        //Edit Lastname leaving the input emtpy
        //
        [TestMethod]
        public void EditLastNameEmtpy()
        {
            Account accountView = new Account();
            accountView.EditLasttName("");
            //Check if it leave in blank
            Assert.AreEqual(Browser.Driver.FindElement(By.Id("input_last")).GetAttribute("Style"), "display: inline;");
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            //Check if it was saved corectly
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_last"), ""));
        }
        //
        //Edit long Lastname
        //
        [TestMethod]
        public void EditlongLastName()
        {
            Account accountView = new Account();
            accountView.EditLasttName("loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooongname");
            //Can not check because is not checking the name size
            //Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_last"), ""));
        }
        //
        //Edit Lastname with invalid chars
        //
        [TestMethod]
        public void EditLastNameInvalid()
        {
            Account accountView = new Account();
            accountView.EditLasttName("!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○");
            //Can not check because is not checking the name inupts
            //Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_last"), ""));
        }
        //
        //Edit Zip Succesfully
        //
        [TestMethod]
        public void EditZipSuccesfully()
        {
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = new Random().Next(10000,99999).ToString();
            accountView.Editzip(newname);
            string aux = string.Empty;
            while (aux != "display: none;")
            {
                aux = Browser.Driver.FindElement(By.Id("input_zip")).GetAttribute("Style");
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_zip"), newname));
        }
        //
        //Edit Zip leaving the input emtpy
        //
        [TestMethod]
        public void EditZipEmtpy()
        {
            Account accountView = new Account();
            accountView.Editzip("");
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("error_zip"), "INVALID ZIP!"));
        }
        //
        //Edit long Zip
        //
        [TestMethod]
        public void EditLongZip()
        {
            Account accountView = new Account();
            accountView.Editzip("123132132132132132132132131313231321321321323213213213");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("error_zip"), "INVALID ZIP!"));
        }
        //
        //Edit Zip with invalid chars
        //
        [TestMethod]
        public void EditZipInvalid()
        {
            Account accountView = new Account();
            accountView.Editzip("!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○");
            //Can not check because is not checking the name inupts
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("error_zip"), "INVALID ZIP!"));
        }
        //
        //Edit Zip with Letters
        //
        [TestMethod]
        public void EditZipLetters()
        {
            Account accountView = new Account();
            accountView.Editzip("ZipCode");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("error_zip"), "INVALID ZIP!"));
        }
        //
        //Edit NewsLetter to true
        //
        [TestMethod]
        public void SuscribeToNewsLetter()
        {
            Account accountView = new Account();
            accountView.ChangeStateOfNewsLetter(true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div#newsletter div.table_column_right span.fake_link"), "unsubscribe"));
        }
        //
        //Edit NewsLetter to false
        //
        [TestMethod]
        public void UnSuscribeToNewsLetter()
        {
            Account accountView = new Account();
            accountView.ChangeStateOfNewsLetter(false);
            string state = Browser.Driver.FindElement(By.CssSelector("div#newsletter div.table_column_right span.fake_link")).Text;
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div#newsletter div.table_column_right span.fake_link"), "subscribe"));
        }
        //
        //Edit Artist name succesfully
        //
        [TestMethod]
        public void EditArtistNameSuccesfully()
        {
            string toedit = "band";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.name") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname,toedit);
            string aux = string.Empty;
            while (aux != "display: none;")
            {
                aux = Browser.Driver.FindElement(By.Id("input_"+toedit)).GetAttribute("Style");
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), newname));
        }
        //
        //Edit Artist leaving the field name empty
        //
        [TestMethod]
        public void EditArtistNameEmtpy()
        {
            string toedit = "band";
            Account accountView = new Account();
            accountView.EditArtistInfo("",toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), ""));
        }
        //
        //Edit Artist with a long name
        //
        [TestMethod]
        public void EditLongArtistName()
        {
            string toedit = "band";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name,toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), name));
        }
        //
        //Edit Artist name with invalid chars
        //
        [TestMethod]
        public void EditArtistNameInvalid()
        {
            string toedit="band";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name,toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), name));
        }
        //
        //Edit Artist website succesfully
        //
        [TestMethod]
        public void EditArtistWebsiteSuccesfully()
        {
            string toedit = "website";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.website") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname,toedit);
            Browser.Instance.Wait(5000);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), newname));
        }
        //
        //Edit Artist leaving the field website empty
        //
        [TestMethod]
        public void EditArtistWebsiteEmtpy()
        {
            string toedit = "website";
            Account accountView = new Account();
            accountView.EditArtistInfo("",toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), ""));
        }
        //
        //Edit Artist with a long website
        //
        [TestMethod]
        public void EditLongArtistWebsite()
        {
            string toedit = "website";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name,toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), name));
        }
        //
        //Edit Artist website with invalid chars
        //
        [TestMethod]
        public void EditArtistWebsiteInvalid()
        {
            string toedit = "website";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name,toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), name));
        }
        //
        //Edit Artist facebook succesfully
        //
        [TestMethod]
        public void EditArtistFacebookSuccesfully()
        {
            string toedit = "facebook";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.facebook") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname,toedit);
            Browser.Instance.Wait(5000);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), newname));
        }
        //
        //Edit Artist leaving the field facebook empty
        //
        [TestMethod]
        public void EditArtistFacebookEmtpy()
        {
            string toedit = "facebook";
            Account accountView = new Account();
            accountView.EditArtistInfo("", toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), ""));
        }
        //
        //Edit Artist with a long facebook
        //
        [TestMethod]
        public void EditLongArtistFacebook()
        {
            string toedit = "facebook";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name, toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist facebook with invalid chars
        //
        [TestMethod]
        public void EditArtistFacebookInvalid()
        {
            string toedit = "facebook";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name, toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist myspace succesfully
        //
        [TestMethod]
        public void EditArtistMySpaceSuccesfully()
        {
            string toedit = "myspace";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.myspace") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname, toedit);
            Browser.Instance.Wait(5000);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), newname));
        }
        //
        //Edit Artist leaving the field myspace empty
        //
        [TestMethod]
        public void EditArtistMySpaceEmtpy()
        {
            string toedit = "myspace";
            Account accountView = new Account();
            accountView.EditArtistInfo("", toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), ""));
        }
        //
        //Edit Artist with a long myspace
        //
        [TestMethod]
        public void EditLongArtistMySpace()
        {
            string toedit = "myspace";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name, toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist myspace with invalid chars
        //
        [TestMethod]
        public void EditArtistMySpaceInvalid()
        {
            string toedit = "myspace";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name, toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist twitter succesfully
        //
        [TestMethod]
        public void EditArtistTwitterSuccesfully()
        {
            string toedit = "twitter";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.myspace") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname, toedit);
            Browser.Instance.Wait(5000);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), newname));
        }
        //
        //Edit Artist leaving the field twitter empty
        //
        [TestMethod]
        public void EditArtistTwitterEmtpy()
        {
            string toedit = "twitter";
            Account accountView = new Account();
            accountView.EditArtistInfo("", toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), ""));
        }
        //
        //Edit Artist with a long myspace
        //
        [TestMethod]
        public void EditLongArtistTwitter()
        {
            string toedit = "twitter";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name, toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist twitter with invalid chars
        //
        [TestMethod]
        public void EditArtistTwitterInvalid()
        {
            string toedit = "twitter";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name, toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
    }
}
