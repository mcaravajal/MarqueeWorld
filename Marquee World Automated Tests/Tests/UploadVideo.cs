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
            //string solutionPath = cwd.Replace(projectName + "\\bin\\Debug", "");
            //cwd += ConfigUtil.GetString("Marquee.Upload.videopath");
            DateTime start= DateTime.Now;
            try
            {
                Upload UploadView = new Upload();
                UploadView.UploadVideo(ConfigUtil.GetString("Marquee.Upload.videopath"), ConfigUtil.GetString("Marquee.upload.tittle"), ConfigUtil.GetString("Marquee.upload.description"), 2);
                Browser.Driver.FindElement(By.Id("sumbit")).Submit();
                start = DateTime.Now;
            }
            catch(Exception ex)
            {
            }
            Browser.Instance.Wait(By.XPath("/html/body/div/div/section/div[2]/div"));
            TimeSpan ts = DateTime.Now - start;
            System.Diagnostics.Debug.WriteLine("--"+ts.Minutes + " minutes " + ts.Seconds + " seconds " + ts.Milliseconds + " Miliseconds --");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.XPath("/html/body/div/div/section/div[2]/div"), "Video Uploaded"));
        }
    }
}
