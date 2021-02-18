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
    public class OrderPage : ReusableMethods.Hooks
    {

        public static IWebElement iconfirmOrder => driver.FindElement(By.XPath("//button/span[contains(text(),'I confirm my order')]"));
        public static IWebElement orderConfirmatio => driver.FindElement(By.XPath("//p[contains(text(),'Your order on My Store is complete.')]"));

        public static IWebElement backToOrders => driver.FindElement(By.XPath("//a[@title='Back to orders']"));

        public static IWebElement orderHistoryPage => driver.FindElement(By.XPath("//div/h1[contains(text(),'Order history']"));


        public static IWebElement orderNumber => driver.FindElement(By.XPath("//span[@class='price]/br[3][contains(text(),'Do not forget to include your order reference']"));

        public static IWebElement orderNumberinHistoryPage => driver.FindElement(By.XPath("//a[@class='color-myaccount']"));

        public static void CaptureOrderNumberandcheckinOrderHistory()
        {
            try
            {

                if (CommonClass.isDisplayed(orderNumber))
                {
                    string order = CommonClass.getTextMethod(orderNumber).Split(' ')[8];
                    CommonClass.clickMethod(backToOrders);
                    CommonClass.impWait();
                    if (order.Equals(CommonClass.getTextMethod(orderNumberinHistoryPage)))
                    {
                        step.Log(Status.Pass, "iconfirmOrder is clicked");
                    }
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "iconfirmOrder is not clicked");
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
                step.Log(Status.Fail, e.StackTrace);
            }

        }

        public static void ConfirmOrder()
        {
            try
            {

                if (CommonClass.isDisplayed(iconfirmOrder))
                {
                    CommonClass.clickMethod(iconfirmOrder);
                    step.Log(Status.Pass, "iconfirmOrder is clicked");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "iconfirmOrder is not clicked");
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
