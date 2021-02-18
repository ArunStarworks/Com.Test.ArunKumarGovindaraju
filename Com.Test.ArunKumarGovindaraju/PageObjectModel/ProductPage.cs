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
    public class ProductPage : ReusableMethods.Hooks
    {
        public static IWebElement linkTShirts => driver.FindElement(By.XPath("//a[@title='T-shirts']"));
        public static IWebElement linkfirstTShirt => driver.FindElement(By.XPath("//a[@class='product_img_link']/img[1]"));
        public static IWebElement proceedToCheckout => driver.FindElement(By.XPath("//a[@title='Proceed to checkout']"));
        public static IWebElement addtoCart => driver.FindElement(By.Name("Submit"));

        public static void clickTshirtsTab()
        {
            try
            {

                if (CommonClass.isDisplayed(linkTShirts))
                {

                    CommonClass.clickMethod(linkTShirts);

                    step.Log(Status.Pass, "linkTShirts is clicked");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "linkTShirts is not clicked");
                }
            }
            catch (Exception e)
            {

                Assert.Fail(e.StackTrace);
                step.Log(Status.Fail, e.StackTrace);
            }
        }


        public static void clickfirstProduct()
        {
            try
            {

                if (CommonClass.isDisplayed(linkfirstTShirt))
                {

                    CommonClass.clickMethod(linkfirstTShirt);

                    step.Log(Status.Pass, "linkfirstTShirt is clicked");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "linkfirstTShirt is not clicked");
                }
            }
            catch (Exception e)
            {

                Assert.Fail(e.StackTrace);
                step.Log(Status.Fail, e.StackTrace);
            }
        }


        public static void clickOnAddToCart()
        {
            try
            {

                if (CommonClass.isDisplayed(addtoCart))
                {

                    CommonClass.clickMethod(addtoCart);

                    step.Log(Status.Pass, "addtoCart is clicked");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "addtoCart is not clicked");
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
