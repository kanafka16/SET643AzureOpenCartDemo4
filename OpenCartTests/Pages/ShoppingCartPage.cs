using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class ShoppingCartPage : AHeadComponent
    {
        public IWebElement EmptyShoppingCartContent { get; private set; }
        public IWebElement CartTotalPrice { get { return driver.FindElement(By.CssSelector(".col-sm-offset-8 .table-bordered tr:nth-child(2) td:nth-child(2)")); } }
        //public IWebElement VerifyWishList { get; private set; }
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
            EmptyShoppingCartContent = driver.FindElement(By.XPath("//*[@id='content']/p"));
        }
        public string GetEmptyShoppingCartText() => EmptyShoppingCartContent.Text;
        public string GetCartTotalPrice() => CartTotalPrice.Text;
    }
}
