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

    public class AddressPage : ReusableMethods.Hooks
    {


        public static IWebElement addressTab => driver.FindElement(By.XPath("//span[contains(text(),'Address')]"));

        public static void AddressTabValidation()
        {
            try
            {

                if (CommonClass.isDisplayed(addressTab))
                {

                    step.Log(Status.Pass, "addressTab is displayed");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "addressTab is not displayed");
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
