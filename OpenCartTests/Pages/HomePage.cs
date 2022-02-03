using OpenQA.Selenium;
using System.Collections.Generic;

namespace OpenCartTests.Pages
{
    public class HomePage : AHeadComponent
    {
        public IList<IWebElement> Products { get; private set; }
        public IWebElement CurrencySymbol { get; private set; }
        public IWebElement ShoppingCartButtonHome { get; private set; }
        public IWebElement FeaturedFirstProductPrice { get { return driver.FindElement(By.CssSelector(".price")); } }
        public HomePage(IWebDriver driver) : base(driver) 
        {
            Products = driver.FindElements(By.CssSelector(".product-layout"));
            
            CurrencySymbol = driver.FindElement(By.TagName("strong"));
            ShoppingCartButtonHome = driver.FindElement(By.CssSelector("#content .product-layout:first-child .button-group button[onclick*='cart']"));
        }

        public void ClickOnFirstProduct() => Products[0].Click();

        public ProductDetailsPage GetFirstProductDetails()
        {
            ClickOnFirstProduct();
            return new ProductDetailsPage(driver);
        }

        public HomePage GetFirstProductInfo()
        {
            ClickOnFirstProduct();
            return new HomePage(driver);
        }

        public ASearchCriteriaComponent FindProduct(string searchText)
        {
            ClearSearchProductField();
            SetSearchProductField(searchText);
            SetSearchProductField(Keys.Enter);
            return new SearchResultPage(driver);
        }

        public string GetFeaturedFirstProductPrice()
        {
            return FeaturedFirstProductPrice.Text;
        }

        public string GetCurrencySymbol()
        {
            return CurrencySymbol.Text;
        }

        public HomePage AddToCartHome()
        {
            ShoppingCartButtonHome.Click();
            return new HomePage(driver);
        }
    }
}
