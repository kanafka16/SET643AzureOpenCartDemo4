using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace OpenCartTests.Tests.Yurii_Kanafotskyi
{
    [TestFixture]
    [AllureNUnit]
    [Category("Currency")]
    public class CurrencyTests : TestRunner
    {
        protected override string OpenCartURL { get => "http://13.90.27.109"; }

        User user;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            user = User.CreateBuilder()
                .SetFirstName("Yurii")
                .SetLastName("Hoidyk")
                .SetEMail("yurii.hoidyk@gmail.com")
                .SetTelephone("0637866103")
                .SetPassword("seva_noob")
                .Build();
        }

        [Test, Order(1)]
        [AllureTag("Currency")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void HomePageFirstProductPriceDependingOnCurrency()
        {
            string expected = new HomePage(driver).GetFeaturedFirstProductPrice();

            _ = new HomePage(driver).ChangeCurrencyOnHomePage();

            string actual = new HomePage(driver).GetFeaturedFirstProductPrice();

            Assert.AreNotEqual(expected, actual);
        }

        [Test, Order(2)]
        [AllureTag("Currency")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void ProductPagePriceChangingDependingOnCurrency()
        {
            ProductDetailsPage pdp = new HomePage(driver).GetFirstProductDetails();

            string expected = new ProductDetailsPage(driver).GetPriceText();

            pdp.ChangeCurrencyOnDetailsPage()
               .GetURL();

            string actual = new ProductDetailsPage(driver).GetPriceText();

            Assert.AreNotEqual(expected, actual);
        }

        [Test, Order(4)]
        [AllureTag("Currency")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void WishListPriceChangingDependingOnCurrency()
        {
            ProductDetailsPage pdp = new HomePage(driver).GoToLoginPage()
                                    .SuccessfullLogin(user)
                                    .GoToHomePage()
                                    .GetFirstProductDetails();

            pdp.AddToWishList();
            pdp.GoToWishPage();

            string expected = new WishListPage(driver).GetWishListFirstProductPrice();

            _ = new WishListPage(driver).ChangeCurrencyOnWishListPage();

            string actual = new WishListPage(driver).GetWishListFirstProductPrice();

            Assert.AreNotEqual(expected, actual);
        }

        [Test, Order(5)]
        [AllureTag("Currency")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void CartPriceChangingDependingOnCurrency()
        {
            _ = new HomePage(driver).GoToLoginPage()
                                    .SuccessfullLogin(user)
                                    .GoToHomePage()
                                    .AddToCartHome()
                                    .GoToShoppingCartPage()
                                    .GetURL();

            string expected = new ShoppingCartPage(driver).GetCartTotalPrice();

            _ = new ShoppingCartPage(driver).ChangeCurrencyOnCartPage()
                                            .GetURL();

            string actual = new ShoppingCartPage(driver).GetCartTotalPrice();

            Assert.AreNotEqual(expected, actual);
        }

        [Test, Order(3)]
        [AllureTag("Currency")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void ChangeableCurrencySymbol()
        {
            string expected = "€";

            _ = new HomePage(driver).ChangeCurrencyOnHomePage();

            string actual = new HomePage(driver).GetCurrencySymbol();

            Assert.AreEqual(expected, actual);
        }
    }
}