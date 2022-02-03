using OpenQA.Selenium;
using OpenCartTests.Data;

namespace OpenCartTests.Pages
{
    class EditAccountPage : ARightMenuComponent
    {   
        public IWebElement FirstNameInput { get { return driver.FindElement(By.Name("firstname")); } }
        public IWebElement LastNameInput { get { return driver.FindElement(By.Name("lastname")); } }
        public IWebElement EmailInput { get { return driver.FindElement(By.Name("email")); } }
        public IWebElement TelephoneInput { get { return driver.FindElement(By.Name("telephone")); } }
        public IWebElement ContinueButton { get { return driver.FindElement(By.CssSelector(".pull-right > .btn.btn-primary")); } }
        public IWebElement AccountUpdatedText { get { return driver.FindElement(By.CssSelector("div.alert.alert-success.alert-dismissible")); } }
        
        public EditAccountPage(IWebDriver driver) : base(driver) { }

        public void FillEditForm(User user)
        {
            SetFirstNameInput(user.FirstName);
            SetLastNameInput(user.LastName);
            SetEmailInput(user.EMail);
            SetTelephoneInput(user.Telephone);
        }

        public void SetFirstNameInput(string text)
        {
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(text);
        }

        public void SetLastNameInput(string text)
        {
            LastNameInput.Clear();
            LastNameInput.SendKeys(text);
        }

        public void SetEmailInput(string text)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(text);
        }

        public void SetTelephoneInput(string text)
        {
            TelephoneInput.Clear();
            TelephoneInput.SendKeys(text);
        }

        public void ConfirmChanges()
        {
            ContinueButton.Click();
        }

        public string GetAccountUpdatedMessageText()
        {
            return AccountUpdatedText.Text;
        }
    }
}
