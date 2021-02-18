using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Com.Test.ArunKumarGovindaraju.ReusableMethods
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest feature, scenario, test, step;
        public static string webURL = Config.EnvConfig.url;
        public static string envbrowser = Config.EnvConfig.browser;
        public static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "Result" + Path.DirectorySeparatorChar
            + "Result_";


        [BeforeTestRun]

        public static void BeforeTest()
        {
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }


        [BeforeFeature]
        public static void BeforeMethod(FeatureContext context)
        {
            try
            {

                feature = extent.CreateTest(context.FeatureInfo.Title);


                if (envbrowser.Equals("Chrome"))
                {
                    driver = new ChromeDriver();
                }
                else if (envbrowser.Equals("Firefox"))
                {
                    driver = new ChromeDriver();
                }
                driver.Manage().Window.Maximize();


            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }


        [BeforeScenario]

        public void BeforeScenario(ScenarioContext context)
        {

            scenario = feature.CreateNode(context.ScenarioInfo.Title);
        }


        [BeforeStep]

        public void BeforeEachStep()
        {
            step = scenario;
        }


        [AfterStep]

        public void AfterEachStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }

        }

        [AfterFeature]
        public static void AfterMethod()
        {
            extent.Flush();
            driver.Close();
            driver.Quit();
        }
    }
}
