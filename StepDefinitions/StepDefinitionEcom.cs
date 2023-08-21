using EcomerceTesting.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EcomerceTesting.StepDefinitions
{
    [Binding]
    public  class StepDefinitionEcom
    {

        IWebDriver d;
        ProductCatalog p;
        CheckoutPage c;
        PlaceOrder pl;
        Orders o;
        ICommon com;

        public StepDefinitionEcom(IWebDriver d,ICommon com)
        {
            this.d = d;
            this.com = com;
        }

        [Given(@"The user is on the eCommerce website")]
        public void GivenTheUserIsOnTheECommerceWebsite()
        {
            
        }
        [When(@"The User is login to eCommerce Application")]
        public void WhenTheUserIsLoginToECommerceApplication(Table table)
        {
            String email = table.Rows[0]["UserName"];
            String password = table.Rows[0]["Password"];

            p = com.login.LoginToEcom(email, password);
        }

        [When(@"The user select The product ""([^""]*)"" and adds it to the cart")]
        public void WhenTheUserSelectTheProductAndAddsItToTheCart(String product)
        {
            c = p.AddToCart(product);
        }

                        
        [When(@"proceeds to checkout")]
        public void WhenProceedsToCheckout()
        {
           pl= c.ClickToChecout();
        }

        [When(@"Select country wirh ShortName ""([^""]*)"" and places the order")]
        public void WhenSelectCountryWirhShortNameAndPlacesTheOrder(String country)
        {
            pl.SearchCountry(country);
            o = pl.placeTheOrder();
        }
        

        [Then(@"the user should see an order confirmation with the Msg is ""([^""]*)""")]
        public void ThenTheUserShouldSeeAnOrderConfirmation(String _msg)
        {
           String msg= o.SuccessfulyOrdered();

            Assert.AreEqual(msg, _msg);

        }
    }
}








//[When(@"The user is login to eCommerce Application")]
//public void WhenTheUserIsLoginToECommerceApplication(Table t)
//{
//    LoginPage l = com.login;
//    p = l.LoginToEcom("specflow1234@gmail.com", "Specflow@1234");
//}