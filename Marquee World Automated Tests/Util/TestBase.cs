using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using DatabaseConnectionLibrary;

namespace Util
{    
    public class TestBase
    {
        private static IWebDriver driver;
        private static TestBase instance;

        private TestBase() {}

        public static TestBase Instance
        {
            get
            {
                if (instance == null)
                    instance = new TestBase();
                return instance;
            }
        }

        public static IWebDriver Driver{
            get
            {                
                return driver;
            }
        }
        
        public void Init()
        {                                          
            // Init Firefox Driver
            driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
            string baseUrl = ConfigUtil.GetString("app.url");
            driver.Navigate().GoToUrl(baseUrl);            
        }        
        
        public void Teardown()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }           
        }

        /// <summary>
        /// Keeps the test inactive the default milliseconds configured in App.config
        /// </summary>
        public void Wait()
        {
            decimal timeout = ConfigUtil.GetDecimal("wait.timeout");
            Thread.Sleep(TimeSpan.FromMilliseconds((double)timeout));
        }

        /// <summary>
        /// Keeps the test inactive
        /// </summary>
        /// <param name="mills">milliseconds</param>
        public void Wait(int mills)
        {
            Thread.Sleep(mills);
        }

        /// <summary>
        /// Keeps the test inactive until an element is present
        /// </summary>
        /// <param name="by">The filter for the element to wait</param>
        public void Wait(By by)
        {
            WebDriverWait wait;
            decimal timeout = ConfigUtil.GetDecimal("wait.timeout");
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds((double)timeout));
            wait.Until(d => IsElementPresent(by));
        }

        /// <summary>
        /// Keeps the test inactive until a text is present
        /// </summary>
        /// <param name="text">The text to wait</param>
        public void Wait(string text)
        {
            WebDriverWait wait;
            decimal timeout = ConfigUtil.GetDecimal("wait.timeout");
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds((double)timeout));
            wait.Until(d => IsTextPresent(text));
        }

        /// <summary>
        /// Takes an screenshot in the path configured in the App.config
        /// </summary>
        /// <param name="baseFileName">The file name of the picture</param>
        public void TakeScreenshot(string baseFileName)
        {

            string screenshotsPath = ConfigUtil.GetString("screenshots.path");
            if (!screenshotsPath.EndsWith("\\"))
                screenshotsPath += "\\";
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(
                screenshotsPath + baseFileName + ".png",
                System.Drawing.Imaging.ImageFormat.Png);
        }

        /// <summary>
        /// Asks if an element is present and displayed on the page
        /// </summary>
        /// <param name="by">Filter for the element</param>
        /// <returns>True if the element exists and is visble</returns>
        public bool IsElementPresent(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// polymorphic
        /// </summary>
        /// <param name="element"></param>
        /// <returns>True if the element is displayed on the page</returns>
        public bool IsElementPresent(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a random element given the filter
        /// </summary>
        /// <param name="by">The filter</param>
        /// <returns>A random element that satisfies the filter</returns>
        public IWebElement GetRandomElement(By by)
        {
            ReadOnlyCollection<IWebElement> upgradeLinksConllection = driver.FindElements(by);
            int count = upgradeLinksConllection.Count;
            if (count > 0)
            {
                IWebElement[] upgradeLinks = new IWebElement[count];
                upgradeLinksConllection.CopyTo(upgradeLinks, 0);
                return upgradeLinks[(new Random()).Next(count)];
            }
            return null;
        }

        /// <summary>
        /// Puts all the inputs of the current page with empty strings
        /// </summary>
        public void ClearAllInputs()
        {
            driver.FindElements(By.CssSelector("input"));
            for (IEnumerator<IWebElement> e = driver.FindElements(By.CssSelector("input")).GetEnumerator(); e.MoveNext(); )
                if (IsElementPresent(e.Current))
                    try
                    {
                        e.Current.Clear();
                    }
                    catch (Exception) { }
        }

        /// <summary>
        /// Returns the number of elements that sitisfies the filter
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public int CountElements(By by)
        {
            return driver.FindElements(by).Count;
        }

        /// <summary>
        /// Determines if the text is displayed in the current page
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool IsTextPresent(string txt)
        {
            for (IEnumerator<IWebElement> e = driver.FindElements(By.CssSelector("*")).GetEnumerator(); e.MoveNext(); )
                if (e.Current.Displayed && e.Current.Text.Equals(txt))
                    return true;
            return false;
        }

        public bool IsTextPresent(string xpath, string txt)
        {
            string aux = driver.FindElement(By.XPath(xpath)).Text;
            if (aux.Equals(txt))
                return true;
            return false;
        }
        public bool IsTextPresent(IWebElement element, string txt)
        {
            string aux = element.Text;
            if (aux.Equals(txt))
                return true;
            return false;
        }

        public bool IsTextPresent(By element, string txt)
        {
            string aux = driver.FindElement(element).Text;
            if (aux.Equals(txt))
                return true;
            return false;
        }

        public bool IsTextPresent(IWebElement element, string txt, int mod)
        {
            string aux = element.GetAttribute("value").ToString();
            if (aux.Equals(txt))
                return true;
            return false;
        }

        public SqlDataReader RunCommand(string command)
        {
            // Create a new Connection with a valid Connection String.
            DBConnection db = new DBConnection(ConfigUtil.GetString("app.screenshot"));
            // Run the Command against the DB (It can be a any type of command like SELECT, INSERT, UPDATE or DELETE).
            SqlDataReader reader = db.RunCommand(command);            
            // Close the opened Connection.
            db.CloseConnection();
            return reader;
        }        
    }
}

