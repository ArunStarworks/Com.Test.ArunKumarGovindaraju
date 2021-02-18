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
    public class PaymentPage : ReusableMethods.Hooks
    {


        public static IWebElement paymentTab => driver.FindElement(By.XPath("//span[contains(text(),'Payment')]"));

        public static IWebElement paybyCheck => driver.FindElement(By.XPath("//button/span[contains(text(),'pay by cheque')]"));

        public static void PaymentTabValidation()
        {
            try
            {

                if (CommonClass.isDisplayed(paymentTab))
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

        public static void payByCheque()
        {
            try
            {

                if (CommonClass.isDisplayed(paybyCheck))
                {
                    CommonClass.clickMethod(paybyCheck);
                    step.Log(Status.Pass, "paybyCheck is clicked");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "paybyCheck is not clicked");
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
