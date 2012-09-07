using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marquee_World_Automated_Tests.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;
using OpenQA.Selenium;
using System.Reflection;

namespace Marquee_World_Automated_Tests.Tests
{
    [TestClass]
    public class UploadVideo
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
        [TestMethod]
        public void UploadVideoSuccesfully()
        {
            string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
            cwd = cwd.Replace("\\",@"\");
            cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.videopath"));
            DateTime start= DateTime.Now;
            try
            {
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, ConfigUtil.GetString("Marquee.upload.tittle"), ConfigUtil.GetString("Marquee.upload.description"), 2);
                start = DateTime.Now;
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch(Exception ex)
            {
            }
            Browser.Instance.Wait(By.XPath("/html/body/div/div/section/div[2]/div"));
            TimeSpan ts = DateTime.Now - start;
            System.Diagnostics.Debug.WriteLine("--"+ts.Minutes + " minutes " + ts.Seconds + " seconds " + ts.Milliseconds + " Miliseconds --");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.XPath("/html/body/div/div/section/div[2]/div"), "Video Uploaded"));
        }
        [TestMethod]
        public void UploadVideoTittleInvalid()
        {
            try
            {
                string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
                cwd = cwd.Replace("\\", @"\");
                cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.videopath"));
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, "☺☻♥♦♣♠•◘○☺☻♥♦♣♠•◘○♂▬♂♀♪♫☼►◄↕‼¶", ConfigUtil.GetString("Marquee.upload.description"), 2);
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            /*
             We can not check the assert until the fix the bug
             */
            Assert.IsTrue(false);
        }
        [TestMethod]
        public void UploadVideoTittleempty()
        {
            try
            {
                string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
                cwd = cwd.Replace("\\", @"\");
                cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.videopath"));
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, "", ConfigUtil.GetString("Marquee.upload.description"), 2);
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("title_error"), "Please enter a song title"));
        }
        [TestMethod]
        public void UploadVideoTittleLong()
        {
            try
            {
                string tittle = "loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooongtittle";
                string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
                cwd = cwd.Replace("\\", @"\");
                cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.videopath"));
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, tittle, ConfigUtil.GetString("Marquee.upload.description"), 2);
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            /*
            We can not check the assert until they fix the bug
            */
            Assert.IsTrue(false);
        }
        [TestMethod]
        public void UploadVideoGenreEmpty()
        {
            try
            {
                string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
                cwd = cwd.Replace("\\", @"\");
                cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.videopath"));
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, ConfigUtil.GetString("Marquee.upload.tittle"), ConfigUtil.GetString("Marquee.upload.description"), 0);
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("genre_missing_error"), "You must choose at least one."));
        }
        [TestMethod]
        public void UploadVideoGenreMoreThanAllowed()
        {
            try
            {
                string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
                cwd = cwd.Replace("\\", @"\");
                cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.videopath"));
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, ConfigUtil.GetString("Marquee.upload.tittle"), ConfigUtil.GetString("Marquee.upload.description"), 4);
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("genre_full_error"), "You may choose up to three genres as apply to the song."));
        }
        [TestMethod]
        public void UploadImage()
        {
            try
            {
                string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
                cwd = cwd.Replace("\\", @"\");
                cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.imagepath"));
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, ConfigUtil.GetString("Marquee.upload.tittle"), ConfigUtil.GetString("Marquee.upload.description"), 3);
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            //
            //We can not check the assert until they fix the bug
            //
            Assert.IsTrue(false);
        }
    }
}
