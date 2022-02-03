using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class MyAccountPage : ARightMenuComponent
    {   // TODO
        public IWebElement ChangeYourPassword { get; private set; }
        public IWebElement EditAccountButton { get; private set; }
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
            ChangeYourPassword = driver.FindElement(By.PartialLinkText("password"));
            EditAccountButton = driver.FindElement(By.LinkText("Edit Account"));
        }
        public string GetChangeYourPasswordText() => ChangeYourPassword.Text;
        public void ClickhangeYourPassword() => ChangeYourPassword.Click();
        public void ClickEditAccountButton() => EditAccountButton.Click();
    }
}
