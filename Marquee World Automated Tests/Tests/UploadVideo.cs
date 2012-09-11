using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marquee_World_Automated_Tests.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;
using OpenQA.Selenium;
using System.Reflection;
using System.Configuration;

namespace Marquee_World_Automated_Tests.Tests
{
    [TestClass]
    public class UploadVideo
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        [TestInitialize]
        public void InitTest()
        {
            Browser.Instance.Init();
            config.AppSettings.Settings["wait.timeout"].Value = "600000000";
            config.Save(ConfigurationSaveMode.Modified);
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Browser.Instance.Close();
            config.AppSettings.Settings["wait.timeout"].Value = "60000";
            config.Save(ConfigurationSaveMode.Modified);
        }
        //
        //Upload a video succesfully
        //
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
                UploadView.UploadVideo(cwd, ConfigUtil.GetString("Marquee.upload.title"), ConfigUtil.GetString("Marquee.upload.description"), 2);
                Browser.Instance.TakeScreenshot("UploadVideoSuccesfully_0");
                start = DateTime.Now;
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch(Exception ex)
            {
            }
            Browser.Instance.Wait(By.XPath("/html/body/div/div/section/div[2]/div"));
            TimeSpan ts = DateTime.Now - start;
            System.Diagnostics.Debug.WriteLine("--"+ts.Minutes + " minutes " + ts.Seconds + " seconds " + ts.Milliseconds + " Miliseconds --");
            Browser.Instance.TakeScreenshot("UploadVideoSuccesfully_1");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.XPath("/html/body/div/div/section/div[2]/div"), "Video Uploaded"));
        }
        //
        //Upload a video with a title invalid
        //
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
                Browser.Instance.TakeScreenshot("UploadVideoTittleInvalid_0");
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
                Browser.Instance.TakeScreenshot("UploadVideoTittleInvalid_1");
            }
            catch (Exception ex)
            {
            }
            /*
             We can not check the assert until the fix the bug
             */
            Assert.IsTrue(false);
        }
        //
        //Upload a video with the title empty
        //
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
                Browser.Instance.TakeScreenshot("UploadVideoTittleempty_0");
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            Browser.Instance.TakeScreenshot("UploadVideoTittleempty_0");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("title_error"), "Please enter a song title"));
        }
        //
        //Upload a video with the title too long
        //
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
                Browser.Instance.TakeScreenshot("UploadVideoTittleLong_0");
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            /*
            We can not check the assert until they fix the bug
            */
            Browser.Instance.TakeScreenshot("UploadVideoTittleLong_1");
            Assert.IsTrue(false);
        }
        //
        //Upload a video with out select any genre
        //
        [TestMethod]
        public void UploadVideoGenreEmpty()
        {
            try
            {
                string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
                cwd = cwd.Replace("\\", @"\");
                cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.videopath"));
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, ConfigUtil.GetString("Marquee.upload.title"), ConfigUtil.GetString("Marquee.upload.description"), 0);
                Browser.Instance.TakeScreenshot("UploadVideoGenreEmpty_0");
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            Browser.Instance.TakeScreenshot("UploadVideoGenreEmpty_1");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("genre_missing_error"), "You must choose at least one."));
        }
        //
        //Upload a video selecting more than 3 genres
        //
        [TestMethod]
        public void UploadVideoGenreMoreThanAllowed()
        {
            try
            {
                string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
                cwd = cwd.Replace("\\", @"\");
                cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.videopath"));
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, ConfigUtil.GetString("Marquee.upload.title"), ConfigUtil.GetString("Marquee.upload.description"), 4);
                Browser.Instance.TakeScreenshot("UploadVideoGenreMoreThanAllowed_0");
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            Browser.Instance.TakeScreenshot("UploadVideoGenreMoreThanAllowed_1");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("genre_full_error"), "You may choose up to three genres as apply to the song."));
        }
        //
        //Upload a Image
        //
        [TestMethod]
        public void UploadImage()
        {
            try
            {
                string timeout = config.AppSettings.Settings["wait.timeout"].Value;
                string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
                cwd = cwd.Replace("\\", @"\");
                cwd = cwd.Replace(@"bin\Debug\Marquee World Automated Tests.dll", ConfigUtil.GetString("Marquee.Upload.imagepath"));
                Upload UploadView = new Upload();
                UploadView.UploadVideo(cwd, ConfigUtil.GetString("Marquee.upload.title"), ConfigUtil.GetString("Marquee.upload.description"), 3);
                Browser.Instance.TakeScreenshot("UploadImage_0");
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
            }
            catch (Exception ex)
            {
            }
            //
            //We can not check the assert until they fix the bug
            //
            Browser.Instance.TakeScreenshot("UploadImage_1");
            Assert.IsTrue(false);
        }
    }
}
