using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindsByAttribute = OpenQA.Selenium.Support.PageObjects.FindsByAttribute;
using How = OpenQA.Selenium.Support.PageObjects.How;

namespace AutomatedTests2.PageObjects
{
    public class HomePage
    {
        private IWebDriver webDriver;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Login")]
        private IWebElement loginButton;

        public LoginPage GoToLoginPage()
        {
            loginButton.Click();
            return new LoginPage(webDriver);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44341/");
        }
    }
}
