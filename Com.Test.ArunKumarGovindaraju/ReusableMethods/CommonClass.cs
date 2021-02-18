using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Test.ArunKumarGovindaraju.ReusableMethods
{
    public class CommonClass : ReusableMethods.Hooks
    {

        public static void navigatetoURL(string URL)
        {
            driver.Url = "https://www.eat24.com/";
        }

        public static void clickMethod(IWebElement element)
        {
            try
            {
                if (element.Displayed)
                {
                    element.Click();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }

        public static void sendKeysMethod(IWebElement element, string value)
        {
            try
            {
                if ((element.Displayed) & (element.Enabled))
                {
                    element.SendKeys(value);
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }


        public static void submitMethod(IWebElement element)
        {
            try
            {
                if ((element.Displayed) & (element.Enabled))
                {
                    element.Submit();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }


        public static string getAttributeMethod(IWebElement element, string attrib)
        {
            try
            {
                if (element.Displayed)
                {
                    return element.GetAttribute(attrib).ToString();
                }
                else
                {
                    return null;
                }
            }

            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
                return null;
            }

        }





        public static string getTitleMethod()
        {
            try
            {

                return driver.Title;

            }

            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
                return null;

            }

        }


        public static string getTextMethod(IWebElement element)
        {
            try
            {

                return element.Text;

            }

            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
                return null;

            }

        }

        public static void clearMethod(IWebElement element)
        {
            try
            {

                element.Clear();
            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }

        public static void isEnabled(IWebElement element)
        {
            try
            {
                if (element.Enabled)
                {
                    Assert.Pass();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }

        public static bool isDisplayed(IWebElement element)
        {
            try
            {

                return element.Displayed;

            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
                return false;
            }
        }

        public static string func_ReturnProjectPath()
        {

            string bPath = System.IO.Directory.GetCurrentDirectory();
            string actualPath = bPath.Substring(0, bPath.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }




        public static void selenctDropDownMethod(IWebElement element, string option, string value)
        {
            try
            {
                SelectElement selItem = new SelectElement(element);

                if (option.Equals("ByValue"))
                {

                    selItem.SelectByValue(value);

                }

                else if (option.Equals("ByText"))
                {

                    selItem.SelectByText(value);

                }

                else if (option.Equals("ByIndex"))
                {

                    selItem.SelectByIndex(int.Parse(value));

                }

            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }




        public static void pageLoad()
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.EnvConfig.timeOut));
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);

            }

        }

        public static void impWait()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.EnvConfig.timeOut);
            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);

            }

        }


        /// <summary>
        /// Function Name  -  func_GetJsonData
        /// Author - Arun Kumar Govindaraju
        /// Parameters -    valToSearch, valFound
        /// Modified By and Date -
        /// Description - This function is used to read data from json file
        /// </summary>

        public static string func_GetJsonData(string valToSearch, string valExecution, string valJsonPath)
        {
            string jsonValToSearch = null;
            var jsonPath = func_ReturnProjectPath() + valJsonPath;
            var json = System.IO.File.ReadAllText(jsonPath);
            var objects = JArray.Parse(json);
            var valFromConfigEnv = valExecution;
            foreach (JObject root in objects)
            {
                foreach (KeyValuePair<String, JToken> app in root)
                {
                    var appName = app.Key;
                    if (appName.ToString().Trim().Equals(valFromConfigEnv.Trim()))
                    {
                        jsonValToSearch = (String)app.Value[valToSearch];
                        break;
                    }
                }
            }

            return jsonValToSearch;


        }

        /// <summary>
        /// Function Name  -  func_GetJsonData
        /// Author - Arun Kumar Govindaraju
        /// Parameters -    valToSearch, valFound
        /// Modified By and Date -
        /// Description - This function is used to read data from json file
        /// </summary>

        public static string func_ReadJsonData(string valToSearch, string valJsonPath)
        {
            string jsonValSearch = null;
            var jsonPath = func_ReturnProjectPath() + valJsonPath;
            using (StreamReader r = new StreamReader(jsonPath))
            {
                var json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    var itemName = item.Name;
                    if (itemName.ToString().Equals(valToSearch))
                    {
                        string itemValue = item.Value;
                        jsonValSearch = itemValue;
                        break;
                    }
                }
            }
            return jsonValSearch;



        }


        public static string func_TimeStamp()
        {
            string hval = DateTime.Now.Hour.ToString();
            string mva11 = DateTime.Now.Minute.ToString();
            string sval2 = DateTime.Now.Second.ToString();
            string dval3 = DateTime.Now.Day.ToString();
            string moval4 = DateTime.Now.Month.ToString();
            string yeval5 = DateTime.Now.Year.ToString();

            string timeStamp = dval3 + moval4 + yeval5 + hval + mva11 + sval2;
            return timeStamp;
        }


        public static string Capture(IWebDriver driver)
        {
            ITakesScreenshot tscen = (ITakesScreenshot)driver;
            Screenshot screen = tscen.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "ErrorScreenshots\\" + "screenShotName" + func_TimeStamp() + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screen.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }

    }
}

