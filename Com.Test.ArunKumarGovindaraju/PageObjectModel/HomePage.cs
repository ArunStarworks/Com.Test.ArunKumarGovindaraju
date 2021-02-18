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
    public class HomePage : ReusableMethods.Hooks
    {

        /*************************************************************************************
         Page WebElements 
         *************************************************************************************/
        public static IWebElement linkHomePage => driver.FindElement(By.XPath("//a[@title='My Store']"));
        public static IWebElement loginLink => driver.FindElement(By.XPath("//a[@class='login']"));
        public static IWebElement emailTextBox => driver.FindElement(By.Id("email"));
        public static IWebElement passwordTextBox => driver.FindElement(By.Id("passwd"));
        public static IWebElement signInButton => driver.FindElement(By.Id("SubmitLogin"));
        public static IWebElement logoutLink => driver.FindElement(By.XPath("//a[@class='logout']"));

        public static IWebElement proceedToCheckout => driver.FindElement(By.XPath("//a[@title='Proceed to checkout']"));


        /*************************************************************************************
        Page Methods
        *************************************************************************************/

        /// <summary>
        /// Function Name : func_ValidateHomePage
        /// Author : xyz
        /// Parameters : none
        /// Description : This methods validates the presence pop up link on the home page 
        /// Modified by & date : 
        /// </summary>
        public static void ValidateHomePage()
        {
            try
            {

                if (CommonClass.isDisplayed(linkHomePage))
                {
                    CommonClass.clickMethod(linkHomePage);
                    step.Log(Status.Pass, "linkHomePage displayed");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "linkHomePage not displayed");
                }
            }
            catch (Exception e)
            {

                Assert.Fail(e.StackTrace);
                step.Log(Status.Fail, e.StackTrace);
            }
        }



        public static void ProceedToCheckOut()
        {
            try
            {

                if (CommonClass.isDisplayed(proceedToCheckout))
                {

                    CommonClass.clickMethod(proceedToCheckout);

                    step.Log(Status.Pass, "proceedToCheckout is clicked");
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "proceedToCheckout is not clicked");
                }
            }
            catch (Exception e)
            {

                Assert.Fail(e.StackTrace);
                step.Log(Status.Fail, e.StackTrace);
            }
        }







        public static void Login()
        {
            try
            {


                if (CommonClass.isDisplayed(loginLink))
                {

                    CommonClass.clickMethod(loginLink);
                    CommonClass.impWait();
                    CommonClass.sendKeysMethod(emailTextBox, Config.EnvConfig.email);
                    CommonClass.sendKeysMethod(passwordTextBox, Config.EnvConfig.password);
                    CommonClass.clickMethod(signInButton);
                    CommonClass.impWait();
                    if (CommonClass.isDisplayed(logoutLink))
                    {
                        step.Log(Status.Pass, "Login successful");
                    }
                }
                else
                {
                    Assert.Fail();
                    step.Log(Status.Fail, "Login not successful");
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

