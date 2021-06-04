using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrrrRent.AutomatedTests2.PageObject
{
    public class AddVehicle
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "Model")]
        private IWebElement Model;

        [FindsBy(How = How.Id, Using = "Class")]
        private IWebElement Class;

        [FindsBy(How = How.Id, Using = "Year")]
        private IWebElement Year;

        [FindsBy(How = How.Id, Using = "Brand")]
        private IWebElement Brand;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[6]/input")]
        private IWebElement createButton;

        public AddVehicle(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string Model, string Class, DateTime Year, string Brand)
        {
            this.Model.Clear();
            this.Model.SendKeys(Model);
            this.Class.Clear();
            this.Class.SendKeys(Class);
            this.Year.Clear();
            this.Year.SendKeys(Year.ToString());
            this.Brand.Clear();
            this.Brand.SendKeys(Brand);
            createButton.Click();
        }
    }
}
