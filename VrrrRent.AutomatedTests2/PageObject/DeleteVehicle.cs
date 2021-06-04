using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrrrRent.AutomatedTests2.PageObject
{
    public class DeleteVehicle
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/form/input[2]")]
        private IWebElement deleteButton;
        public DeleteVehicle(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(webDriver, this);
        }

        public void Delete()
        {
            deleteButton.Click();
        }
    }
}
