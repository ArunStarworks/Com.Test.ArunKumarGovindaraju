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
    public class ShippingPage : ReusableMethods.Hooks
    {

        public static IWebElement shippingTab => driver.FindElement(By.XPath("//span[contains(text(),'Shipping')]"));

        public static IWebElement termsCheckbox => driver.FindElement(By.Name("cvg"));
        public static void ShippingTabValidation()
        {
            try
            {

                if (CommonClass.isDisplayed(shippingTab))
                {

                    step.Log(Status.Pass, "shippingTab is displayed");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "shippingTab is not displayed");
                }
            }
            catch (Exception e)
            {

                Assert.Fail(e.StackTrace);
                step.Log(Status.Fail, e.StackTrace);
            }
        }

        public static void termsCheckBox()
        {
            try
            {

                if (CommonClass.isDisplayed(termsCheckbox))
                {
                    CommonClass.clickMethod(termsCheckbox);
                    step.Log(Status.Pass, "termsCheckbox is clicked");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "termsCheckbox is not clicked");
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
