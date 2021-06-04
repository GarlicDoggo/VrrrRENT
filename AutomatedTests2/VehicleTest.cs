using AutomatedTests2.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests2
{
    [TestClass]
    class VehiclesPageTest
    {
        IWebDriver webDriver;

        [TestInitialize]

        public void Initialize()
        {
            webDriver = new ChromeDriver();
        }
        [TestMethod]
        public void TestAddVehicle()
        {
            AddVehicle C1 = new AddVehicle(webDriver);
            Random randomNumber = new Random();
            string modelName = "MyTest1Car " + randomNumber.Next(100, 10000000);
            DateTime time = DateTime.Today;
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("admin1@admin.com", "Mihai123!");

            VehicleIndex indexPage = new VehicleIndex(webDriver);
            indexPage.GoToPage();
            AddVehicle addvehiclePage = indexPage.GoToAddVehiclePage();
            addvehiclePage.Save(modelName, "S", time, "Audi");


            Assert.IsTrue(indexPage.VehicleExists(modelName));


        }
        [TestMethod]
        public void TestDeleteVehicle()
        {
            AddVehicle C1 = new AddVehicle(webDriver);
            Random randomNumber = new Random();
            string carName = "MyTest2Chat " + randomNumber.Next(100, 10000000);
            DateTime time = DateTime.Today;
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("admin1@gmail.com", "Admin_1234");

            VehicleIndex indexPage = new VehicleIndex(webDriver);
            indexPage.GoToPage();
            AddVehicle addVehiclePage = indexPage.GoToAddVehiclePage();
            C1.Save(carName, "S", time, "Audi");

            DeleteVehicle deleteStationPage = indexPage.GoToDeleteVehiclePage();
            deleteStationPage.Delete();

            Assert.IsTrue(indexPage.CheckIfVehicleIsPresent(carName));

        }
        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }
    }
}
