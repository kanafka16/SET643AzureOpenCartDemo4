/*using NUnit.Framework;
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
    [Category("RegisterAccount")]
    public class RegistrationTest : TestRunner
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

        [Test]
        [AllureTag("RegisterAccount")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void RegisterExistingUser()
        {
            RegisterPage regPage = new HomePage(driver).GoToRegisterPage();

            regPage.FillRegisterForm(user);
            regPage.ClickAgreeCheckBox();
            regPage.ClickContinueButtonSuccess();
            
            string expected = "Warning: E-Mail Address is already registered!";
            string actual = regPage.GetExistingEmailWarningMessage();

            Assert.AreEqual(expected, actual);
        }
    }
}*/