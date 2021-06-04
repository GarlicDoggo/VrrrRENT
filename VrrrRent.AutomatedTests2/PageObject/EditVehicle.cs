using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrrrRent.AutomatedTests2.PageObject
{
    public class EditVehicle
    {
        private IWebDriver webDriver;
        
        [FindsBy(How = How.Id, Using = "Model")]
        private IWebElement Model;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[6]/input")]
        private IWebElement editButton;

        
        public EditVehicle(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(webDriver, this);
        }

        public void Edit(string Model)
        {
            this.Model.Clear();
            this.Model.SendKeys(Model);
            editButton.Click();
        }
    }
}
