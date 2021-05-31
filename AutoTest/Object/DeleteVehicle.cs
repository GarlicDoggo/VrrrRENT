using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VrrrRentAutoTest.Object
{
    class DeleteVehicle
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/form/input[2]")]
        private IWebElement deleteButton;
        public DeleteVehicle(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        public void Delete()
        {
            deleteButton.Click();
        }
    }
}