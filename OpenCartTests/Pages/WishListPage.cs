using OpenQA.Selenium;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class WishListPage : AStatusBarComponent 
    {        
        public IWebElement DeleteButton { get {return driver.FindElement(By.CssSelector("#content tr:first-child .btn-danger")); } }
        public IWebElement Alertmessage { get { return driver.FindElement(By.CssSelector(".alert-success:not( .fa-check-circle)")); } }
        public IWebElement EmptyWishListMessage { get { return driver.FindElement(By.CssSelector("#content > p")); } }
        public IWebElement Table { get { return driver.FindElement(By.CssSelector("#content > div.table-responsive")); } }
        public IWebElement WishListFirstProductPrice { get { return driver.FindElement(By.CssSelector("tr:first-child .price")); } }

        public WishListPage(IWebDriver driver) : base(driver)
        {           
            
            
        }

        public string GetTable()
        {
            return Table.Text;
        }


        public void DeleteProduct()
        {
            DeleteButton.Click();
        }
        public string GetAlertMessageText()
        {
            return Alertmessage.Text;
        }
        public string GetEmptyWishListMessageText()
        {
            return EmptyWishListMessage.Text;
        }
        public string GetWishListFirstProductPrice()
        {
            return WishListFirstProductPrice.Text;
        }
    }
}
