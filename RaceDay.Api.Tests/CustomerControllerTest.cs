using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceDay.BL.Interface;
using RaceDay.Api.Controllers;
using RaceDay.Contracts.Dto;
using System.Collections.Generic;

namespace RaceDay.Api.Tests
{
    [TestClass]
    public class CustomerControllerTest
    {
        private Mock<ICustomerBL> _mockCustomerBL;

        [TestInitialize]
        public void Inititalize()
        {
            _mockCustomerBL = new Mock<ICustomerBL>();
        }

        [TestMethod]
        public void CustomerController_Get_ReturnList()
        {
            //arrange
            var expectedValue = new List<CustomerDto>() {
                new  CustomerDto() {  Id = 1, Name = "John"},
                new  CustomerDto() { Id=2, Name = "Tese" }
            };
            var controller = new CustomerController(_mockCustomerBL.Object);
            _mockCustomerBL.Setup(x => x.GetAll()).Returns(expectedValue);
            //act
            var result = controller.Get();
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerController_Get_ReturnNull()
        {
            //arrange
            List<CustomerDto> expectedValue = null;
            var controller = new CustomerController(_mockCustomerBL.Object);
            _mockCustomerBL.Setup(x => x.GetAll()).Returns(expectedValue);
            //act
            var result = controller.Get();
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerController_GetTotalBets_ReturnValue()
        {
            //arrange
            var expectedValue = 3;
            var controller = new CustomerController(_mockCustomerBL.Object);
            _mockCustomerBL.Setup(x => x.GetTotalBets(It.IsAny<int>())).Returns(expectedValue);
            //act
            var result = controller.GetTotalBets(1);
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerController_GetTotalBets_ReturnZero()
        {
            //arrange
            var expectedValue = 0;
            var controller = new CustomerController(_mockCustomerBL.Object);
            _mockCustomerBL.Setup(x => x.GetTotalBets(It.IsAny<int>())).Returns(expectedValue);
            //act
            var result = controller.GetTotalBets(2);
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerController_GetTotalAmountBets_ReturnAmount()
        {
            //arrange
            var expectedValue = 1231M;
            var controller = new CustomerController(_mockCustomerBL.Object);
            _mockCustomerBL.Setup(x => x.GetTotalAmountBets(It.IsAny<int>())).Returns(expectedValue);
            //act
            var result = controller.GetTotalAmountBets(1);
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerController_GetTotalAmountBets_ReturnZero()
        {
            //arrange
            var expectedValue = 0;
            var controller = new CustomerController(_mockCustomerBL.Object);
            _mockCustomerBL.Setup(x => x.GetTotalAmountBets(It.IsAny<int>())).Returns(expectedValue);
            //act
            var result = controller.GetTotalAmountBets(2);
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerController_GetAllAtRisk_ReturnList()
        {
            //arrange
            var expectedValue = new List<CustomerDto>() {
                new  CustomerDto() {  Id = 1, Name = "John"}
            };
            var controller = new CustomerController(_mockCustomerBL.Object);
            _mockCustomerBL.Setup(x => x.GetAllAtRisk()).Returns(expectedValue);
            //act
            var result = controller.GetAllAtRisk();
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerController_GetAllAtRisk_ReturnNull()
        {
            //arrange
            List<CustomerDto> expectedValue = null;
            var controller = new CustomerController(_mockCustomerBL.Object);
            _mockCustomerBL.Setup(x => x.GetAllAtRisk()).Returns(expectedValue);
            //act
            var result = controller.GetAllAtRisk();
            //assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}
