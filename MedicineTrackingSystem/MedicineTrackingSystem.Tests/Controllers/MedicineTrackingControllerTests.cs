using MedicineTrackingSystem.Controllers;
using MedicineTrackingSystem.Proxies;
using Moq;
using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicineTrackingSystem.Tests.Controllers
{
    public class MedicineTrackingControllerTests
    {
        private Mock<IMedicinesTrackingProxy> medTrackProxy;
        private MedicinesTrackingController medsTrackController;

        public MedicineTrackingControllerTests()
        {
            medTrackProxy = new Mock<IMedicinesTrackingProxy>();
            medsTrackController = new MedicinesTrackingController(medTrackProxy.Object);
        }

        [Fact]
        public void GetAllMedicinesShouldReturnAllMedsInSystem()
        {
            // Arrange / Act
            var response = medsTrackController.Get();

            // Assert
            response.Should().NotBeNull();
        }

        [Fact]
        public void GetMedicineByIdShouldReturnSingleMedicine()
        {
            // Arrange
            SetupSingleRetrievalResponses();

            // Act
            var response = medsTrackController.GetMedicineById(1);

            // Assert
            response.Id.Should().Be(1);
            response.Name.Should().Be("TestResponseForGetById");
        }

        [Fact]
        public void GetMedicineByNameShouldReturnMultipleMedicines()
        {
            // Arrange
            SetupMultipleRetrievalResponses();

            // Act
            var response = medsTrackController.GetMedicinesByName("Sample");

            // Assert
            response.Count().Should().NotBe(0);
            response.First().Id.Should().Be(2);
            response.First().Name.Should().Be("TestResponseForGetByName");
        }

        private void SetupSingleRetrievalResponses()
        {
            medTrackProxy.Setup(opt => opt.GetMedicineById(It.IsAny<int>())).Returns(new Models.Medicine() { Id = 1, Name = "TestResponseForGetById", Brand = "SomeBrand1", ExpiryDate = DateTime.Now.AddDays(30), Price = 12, Quantity = 10 });
        }

        private void SetupMultipleRetrievalResponses()
        {
            medTrackProxy.Setup(opt => opt.GetMedicines(It.IsAny<string>())).Returns(new List<Models.Medicine>() { new Models.Medicine() { Id = 2, Name = "TestResponseForGetByName", Brand = "SomeBrand2", ExpiryDate = DateTime.Now.AddDays(60), Price = 15, Quantity = 20 } });
        }
    }
}
