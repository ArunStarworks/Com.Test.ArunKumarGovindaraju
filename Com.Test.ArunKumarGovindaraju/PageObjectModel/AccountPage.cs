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
    public class AccountPage : ReusableMethods.Hooks
    {


        public static IWebElement AccountLink => driver.FindElement(By.XPath("//a[@title = 'View my customer account')]"));

        public static IWebElement saveLink => driver.FindElement(By.XPath("/span[contains[text(),'Save']"));
        public static IWebElement firstName => driver.FindElement(By.Id("firstname"));



        public static void ClickAccount()
        {
            try
            {

                if (CommonClass.isDisplayed(AccountLink))
                {

                    CommonClass.clickMethod(AccountLink);
                    step.Log(Status.Pass, "AccountLink is clicked");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "AccountLink is not clicked");
                }
            }
            catch (Exception e)
            {

                Assert.Fail(e.StackTrace);
                step.Log(Status.Fail, e.StackTrace);
            }
        }



        public static void updatefirstnameandverify(string newfirstname)
        {
            try
            {

                if (CommonClass.isDisplayed(firstName))
                {
                    CommonClass.clearMethod(firstName);
                    CommonClass.sendKeysMethod(firstName, newfirstname);
                    step.Log(Status.Pass, "newfirstname is entered");
                    CommonClass.clickMethod(saveLink);

                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "AccountLink is not clicked");
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
