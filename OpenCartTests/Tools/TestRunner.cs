using NUnit.Framework;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Tools
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        protected abstract string OpenCartURL { get; } 

        [SetUp]
        public void BeforeEachMethod()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("window-size=1920,1080");
            options.AddArgument("start-maximized");
            options.AddArgument("headless");
            options.AddArgument("disable-gpu");
            options.AddArgument("no-sandbox");
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
        }

        [TearDown]
        public void AfterEachMethod()
        {
            AHeadComponent.LoggedUser = false;
            driver.Quit();
        }

        protected HomePage LoadApplication()
        {
            return new HomePage(driver);
        }
    }
}
