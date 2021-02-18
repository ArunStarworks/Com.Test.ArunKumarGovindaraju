using AventStack.ExtentReports;
using Com.Test.ArunKumarGovindaraju.ReusableMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Test.ArunKumarGovindaraju.PageObjectModel
{
    public class SummaryProcessPage : ReusableMethods.Hooks
    {

        public static IWebElement summaryTab => driver.FindElement(By.XPath("//span[contains(text(),'Summary')]"));

        public static void SummaryTabValidation()
        {
            try
            {

                if (CommonClass.isDisplayed(summaryTab))
                {

                    step.Log(Status.Pass, "summaryTab is displayed");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "summaryTab is not displayed");
                }
            }
            catch (Exception e)
            {

                Assert.Fail(e.StackTrace);
                step.Log(Status.Fail, e.StackTrace);
            }
        }


    }
}
