using Microsoft.EntityFrameworkCore;
using VrrrRent.Models;
using VrrrRent.Repositories;
using VrrrRent.Services;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VrrrRent.Abstractions;

namespace VrrrRent.UnitTest
{

    static class MessageTextComparer
    {
        public static void AssertAreEqual(Vehicle expected, Vehicle actual)
        {
            Assert.AreEqual(expected.Model, actual.Model);
        }
    }
    static class AllMessageComparer
    {
        public static void AssertAreEqual(Vehicle expected, Vehicle actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.Model, actual.Model);
            Assert.AreEqual(expected.Class, actual.Class);
            Assert.AreEqual(expected.Year, actual.Year);
            Assert.AreEqual(expected.Brand, actual.Brand);
            Assert.AreEqual(expected.Inventory, actual.Inventory);
            Assert.AreEqual(expected.Rental, actual.Rental);

        }
    }
    [TestClass]
    public class UnitTest1
    {
        private static VehicleService vehicleService;
        private List<Vehicle> expectedAllChat = new List<Vehicle>();
        private List<Vehicle> expectedChatByCondition = new List<Vehicle>();

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            var options = new DbContextOptionsBuilder<VrrrRentContext>().UseInMemoryDatabase(databaseName: "UnitTestVehicle").Options;
            VrrrRentContext context = new VrrrRentContext(options);
            IRepositoryWrapper repositoryWrapper = new RepositoryWrapper(context);
            vehicleService = new VehicleService(repositoryWrapper);
            populateDatabase();
        }
        private static void populateDatabase()
        {
            DateTime DT = new DateTime(2021, 05, 09, 9, 15, 0);
            vehicleService.AddVehicle(new Vehicle
            {
                ID = 1,
                Model = "Duster",
                Class = 'C',
                Brand = "Dacia",
                Year = DT,
                Available = true,
            });
            vehicleService.AddVehicle(new Vehicle
            {
                ID = 2,
                Model = "Megan",
                Class = 'B',
                Brand = "Renault",
                Year = DT,
                Available = true,
            });
            vehicleService.AddVehicle(new Vehicle
            {
                ID = 3,
                Model = "Sandero",
                Class = 'D',
                Brand = "Dacia",
                Year = DT,
                Available = false,
            });
            vehicleService.Save();
        }
        [TestMethod]
        public void TestGetChats()
        {
            populateExpectedAllVehicle();

            //act
            List<Vehicle> actualcar = vehicleService.GetVehicles();

            //assert
            Assert.AreEqual(3, actualcar.Count);
            for (int index = 0; index < actualcar.Count; index++)
            {
                Vehicle actualcars = actualcar[index];
                Vehicle expectedcars = expectedAllChat[index];
                AllMessageComparer.AssertAreEqual(expectedcars, actualcars);
            }
        }
        [TestMethod]
        public void TestGetVehiclesByCondition()
        {
            //arrange
            populateExpectedVehicleByCondition();

            //act
            List<Vehicle> actualcars = vehicleService.GetVehiclesByCondition(car => car.Model.Equals("Sandero"));

            //assert
            Assert.AreEqual(2, actualcars.Count);
            for (int index = 0; index < actualcars.Count; index++)
            {
                Vehicle actualcar = actualcars[index];
                Vehicle expectedcar = expectedChatByCondition[index];
                MessageTextComparer.AssertAreEqual(expectedcar, actualcar);
            }
        }
        [TestMethod]
        public void TestAddChat()
        {
            DateTime DT = new DateTime(2021, 05, 09, 9, 15, 0);
            Vehicle newChat = new Vehicle
            {
                ID = 4,
                Model = "3310",
                Class = 'D',
                Brand = "Dacia",
                Year = DT,
                Available = false,
            };

            vehicleService.AddVehicle(newChat);

            vehicleService.Save();
            List<Vehicle> actualsCars = vehicleService.GetVehicles();
            Assert.AreEqual(4, actualsCars.Count);
            vehicleService.DeleteVehicle(newChat);
            vehicleService.Save();
        }
        [TestMethod]
        public void TestDeleteChat()
        {
            DateTime DT = new DateTime(2021, 05, 09, 9, 15, 0);
            Vehicle newStation = new Vehicle
            {
                ID = 5,
                Model = "3310",
                Class = 'D',
                Brand = "Dacia",
                Year = DT,
                Available = false,
            };

            vehicleService.AddVehicle(newStation);
            vehicleService.Save();

            vehicleService.DeleteVehicle(newStation);

            vehicleService.Save();
            List<Vehicle> actualsCars = vehicleService.GetVehicles();
            Assert.AreEqual(3, actualsCars.Count);
        }

        [TestMethod]
        public void TestUpdateChat()
        {
            DateTime DT = new DateTime(2021, 05, 09, 9, 15, 0);
            Vehicle vehicleToEdit = new Vehicle
            {
                ID = 4,
                Model = "2310",
                Class = 'D',
                Brand = "Dacia",
                Year = DT,
                Available = false,
            };
            vehicleService.AddVehicle(vehicleToEdit);
            vehicleService.Save();

            vehicleToEdit.Model = "Sandero";


            vehicleService.UpdateVehicle(vehicleToEdit);

            vehicleService.Save();
            List<Vehicle> actualVehicle = vehicleService.GetVehiclesByCondition(ca => ca.ID == 4);
            Vehicle updatedvehicle = actualVehicle[0];
            Assert.AreEqual("Sandero", updatedvehicle.Model);
            vehicleService.DeleteVehicle(vehicleToEdit);
            vehicleService.Save();
        }

        private void populateExpectedVehicleByCondition()
        {
            DateTime DT = new DateTime(2021, 05, 09, 9, 15, 0);
            expectedChatByCondition.Add(new Vehicle
            {
                ID = 1,
                Model = "Duster",
                Class = 'C',
                Brand = "Dacia",
                Year = DT,
                Available = true,
            });
            expectedChatByCondition.Add(new Vehicle
            {
                ID = 3,
                Model = "Sandero",
                Class = 'D',
                Brand = "Dacia",
                Year = DT,
                Available = false,
            });
        }

        private void populateExpectedAllVehicle()
        {
            DateTime DT = new DateTime(2021, 05, 09, 9, 15, 0);
            expectedAllChat.Add(new Vehicle
            {
                ID = 1,
                Model = "Duster",
                Class = 'C',
                Brand = "Dacia",
                Year = DT,
                Available = true,
            });
            expectedAllChat.Add(new Vehicle
            {
                ID = 2,
                Model = "Megan",
                Class = 'B',
                Brand = "Renault",
                Year = DT,
                Available = true,
            });
            expectedAllChat.Add(new Vehicle
            {
                ID = 3,
                Model = "Sandero",
                Class = 'D',
                Brand = "Dacia",
                Year = DT,
                Available = false,
            });
        }
    }
}