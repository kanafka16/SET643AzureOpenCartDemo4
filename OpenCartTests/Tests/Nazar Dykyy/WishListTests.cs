using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace OpenCartTests.Tests.Nazar_Dykyy
{
    [TestFixture]
    [AllureNUnit]
    [Category("WishList")]
    public class WishListTests : TestRunner
    {
        protected override string OpenCartURL { get => "http://13.90.27.109"; }
        public readonly string Wishlist_URL = "index.php?route=account/wishlist";
        public readonly string LOGIN_URL = "index.php?route=account/login";
        
        User user;
        User user1;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
          user = User.CreateBuilder()
              .SetFirstName("Nazar")
              .SetLastName("Dykyy")
              .SetEMail("ndykyyyyyyyyyy@gmail.com")
              .SetTelephone("0980201809")
              .SetPassword("qwerty")
              .Build();
            user1 = User.CreateBuilder()
             .SetFirstName("Ihor")
             .SetLastName("Dykyy")
             .SetEMail("addproduct@towishlict.com")
             .SetTelephone("0980201807")
             .SetPassword("qwerty")
             .Build();

        }
        [Test, Order(1)]
        [AllureTag("WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("NdK")]
        public void EmptyWishListAfterFirstLogin()
        {
            
            RegisterPage registerPage = new HomePage(driver).GoToRegisterPage();

            registerPage.FillRegisterForm(user);
            registerPage.ClickAgreeCheckBox();


            AccountSuccessPage successPage = registerPage.ClickContinueButtonSuccess();
            successPage.GoToWishPage();
            WishListPage wl = new WishListPage(driver);

            string actual = wl.GetEmptyWishListMessageText();

            Assert.IsTrue(actual.Contains("Your wish list is empty."));

        }
        [Test, Order(2)]
        [AllureTag("WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("NdK")]
        public void InaccessibleWishListWithoutLogging()
        {
            string expected = LOGIN_URL;
            string actual = new HomePage(driver)
                                    .GoToLoginPage()
                                    .unloggedClickWishListButton()
                                    .GetURL();

            Assert.IsTrue(actual.Contains(expected));

        }
        [Test, Order(3)]
        [AllureTag("WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("NdK")]
        public void AddProductToWishList()
        {
            
            string homepage = new HomePage(driver)
                                    .GoToLoginPage()
                                    .SuccessfullLogin(user1)
                                    .GoToHomePage()
                                    .GetFirstProductInfo()                                    
                                    .GetURL();
            ProductDetailsPage pd = new ProductDetailsPage(driver).AddToWishList();
            string actual = pd.GetAlertMessageText();
            
            
            Assert.IsTrue(actual.Contains("You have added MacBook to your wish list!"));

        }
        [Test, Order(4)]
        [AllureTag("WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("NdK")]
        public void DeleteFromWishList()
        {
           
            string homepage = new HomePage(driver)
                                    .GoToLoginPage()
                                    .SuccessfullLogin(user1)
                                    .GoToWishPage()
                                    .GetURL();           
            WishListPage wl = new WishListPage(driver);
            wl.DeleteProduct();            
            string actual = wl.GetAlertMessageText();

            Assert.IsTrue(actual.Contains("You have modified your wish list"));


        }     
        [Test, Order(5)]
        [AllureTag("WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("NdK")]
        public void SavedProductInWishListAfterLogout()
        {

            string homepage = new HomePage(driver)
                              .GoToLoginPage()
                              .SuccessfullLogin(user1)
                              .GoToHomePage()
                              .GetFirstProductInfo()
                              .GetURL();
            ProductDetailsPage pd = new ProductDetailsPage(driver).AddToWishList();
            WishListPage wp = new WishListPage(driver).GoToWishPage();
            wp.Logout();
            string hp = new HomePage(driver)
                              .GoToLoginPage()
                              .SuccessfullLogin(user1)
                              .GoToWishPage()
                              .GetURL();
            WishListPage w = new WishListPage(driver);
            string actual=w.GetTable();
            Assert.IsTrue(actual.Contains("Image"));
        }     
    }
}
