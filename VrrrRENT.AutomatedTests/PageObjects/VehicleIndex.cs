﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindsByAttribute = OpenQA.Selenium.Support.PageObjects.FindsByAttribute;
using How = OpenQA.Selenium.Support.PageObjects.How;

namespace VrrrRent.AutomatedTests.PageObjects
{
    public class VehicleIndex
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement vehiclesList;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/p/a/img")]
        private IWebElement addVehicleButton;

        public VehicleIndex(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44341/Vehicles");
        }

        public AddVehicle GoToAddVehiclePage()
        {
            addVehicleButton.Click(); 
            return new AddVehicle(webDriver);
        }

        public DeleteVehicle GoToDeleteVehiclePage()
        {
            var elements = vehiclesList.FindElements(By.TagName("tr"));
            var nr = elements.Count();
            vehiclesList.FindElement(By.XPath("/html/body/div/main/table/tbody/tr/td[6]/a[3]/img")).Click();
            return new DeleteVehicle(webDriver);
        }

        public bool VehicleExists(string vehicleName)
        {
            var elements = vehiclesList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(vehicleName)).Count() > 0;
        }

        public bool CheckIfVehicleIsPresent(string vehicleName)
        {
            var elements = vehiclesList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(vehicleName)).Count() == 0;
        }
    }
}