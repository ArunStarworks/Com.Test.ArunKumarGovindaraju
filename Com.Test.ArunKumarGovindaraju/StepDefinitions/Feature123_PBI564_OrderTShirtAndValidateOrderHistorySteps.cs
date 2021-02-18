using Com.Test.ArunKumarGovindaraju.ReusableMethods;
using System;
using TechTalk.SpecFlow;

namespace Com.Test.ArunKumarGovindaraju.StepDefinitions
{
    [Binding]
    public class Feature123_PBI564_OrderTShirtAndValidateOrderHistorySteps : ReusableMethods.Hooks
    {
        [Given(@"the applicaiton is launched")]
        public void GivenTheApplicaitonIsLaunched()
        {
            CommonClass.navigatetoURL(Config.EnvConfig.url);
        }

        [Given(@"i login to the application")]
        public void GivenILoginToTheApplication()
        {
            PageObjectModel.HomePage.Login();
        }

        [Given(@"i validate home page")]
        public void GivenIValidateHomePage()
        {
            PageObjectModel.HomePage.ValidateHomePage();
        }

        [Given(@"i Click on TShirts tab")]
        public void GivenIClickOnTShirtsTab()
        {
            PageObjectModel.ProductPage.clickTshirtsTab();
        }

        [Given(@"i select the first product and add to cart")]
        public void GivenISelectTheFirstProductAndAddToCart()
        {
            PageObjectModel.ProductPage.clickfirstProduct();
            PageObjectModel.ProductPage.clickOnAddToCart();
        }

        [Given(@"i Validate Summary, Address, Shipping  and payment tabs")]
        public void GivenIValidateSummaryAddressShippingAndPaymentTabs()
        {
            PageObjectModel.ShippingPage.ShippingTabValidation();
            PageObjectModel.HomePage.ProceedToCheckOut();
            PageObjectModel.AddressPage.AddressTabValidation();
            PageObjectModel.HomePage.ProceedToCheckOut();
            PageObjectModel.ShippingPage.ShippingTabValidation();
            PageObjectModel.HomePage.ProceedToCheckOut();
            PageObjectModel.ShippingPage.termsCheckBox();
            PageObjectModel.HomePage.ProceedToCheckOut();
            PageObjectModel.PaymentPage.PaymentTabValidation();
            PageObjectModel.HomePage.ProceedToCheckOut();
            PageObjectModel.PaymentPage.payByCheque();
            PageObjectModel.HomePage.ProceedToCheckOut();




        }

        [Then(@"i confirm the order")]
        public void ThenIConfirmTheOrder()
        {
            PageObjectModel.OrderPage.ConfirmOrder();

        }

        [Then(@"i validate the order in order history tab")]
        public void ThenIValidateTheOrderInOrderHistoryTab()
        {
            PageObjectModel.OrderPage.CaptureOrderNumberandcheckinOrderHistory();
        }
    }
}
