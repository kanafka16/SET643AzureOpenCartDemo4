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
    [Category("EditAccount")]
    public class EditAccountTest : TestRunner
    {
        protected override string OpenCartURL { get => "http://13.90.27.109"; }

        User user;
        User userEdited;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            user = User.CreateBuilder()
                .SetFirstName("Yurii")
                .SetLastName("Hoidyk")
                .SetEMail("yurii.hoidykkkkkkk@gmail.com")
                .SetTelephone("0637966103")
                .SetPassword("seva_noob")
                .Build();

            userEdited = User.CreateBuilder()
                .SetFirstName("Ostap")
                .SetLastName("Nikolaev")
                .SetEMail("seva.androiddddd@mail.ru")
                .SetTelephone("0637866105")
                .SetPassword("seva_pro")
                .Build();
        }

        [Test]
        [AllureTag("EditAccount")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void EditAccountInfo()
        {
            MyAccountPage myAccPage = new HomePage(driver).GoToLoginPage()
                                    .SuccessfullLogin(user)
                                    .GoToHomePage()
                                    .GoToMyAccountPage();

            myAccPage.ClickEditAccountButton();

            EditAccountPage editPage = new EditAccountPage(driver);

            editPage.FillEditForm(userEdited);
            editPage.ConfirmChanges();

            string expected = "Success: Your account has been successfully updated.";
            string actual = editPage.GetAccountUpdatedMessageText();

            Assert.AreEqual(expected, actual);
        }
    }
}*