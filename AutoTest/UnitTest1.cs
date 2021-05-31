using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using VrrrRentAutoTest.Object;

namespace VrrrRentAutoTest
{
    [TestClass]

    public class UnitTest1
    {
        private IWebDriver webDriver;

        [TestInitialize]
        public void Initialize()
        {
            
            webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void TestAddVehicleCreate()
        {
            AddVehicle C1 = new AddVehicle(webDriver);
            Random randomNumber = new Random();
            string carName = "MyTest1Car " + randomNumber.Next(100, 10000000);
            DateTime time = DateTime.Today;
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("admin1@admin.com", "Abcdefgh1!");

            VehicleIndex indexPage = new VehicleIndex(webDriver);
            indexPage.GoToPage();
            AddVehicle addvehiclePage = indexPage.GoToAddVehiclePage();
            C1.Save(carName, "C", time,"Chevrolet");


            Assert.IsTrue(indexPage.VehicleExists(carName));
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
            C1.Save(carName, "C", time, "Chevrolet");

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
