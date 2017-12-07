using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceDay.BL.Interface;
using RaceDay.Api.Controllers;

namespace RaceDay.Api.Tests
{
    [TestClass]
    public class BetControllerTest
    {
        private Mock<IBetBL> _mockBetBL;

        [TestInitialize]
        public void Inititalize()
        {
            _mockBetBL = new Mock<IBetBL>();
        }

        [TestMethod]
        public void BetController_GetAllTotalAmountBets_Success_ReturnValue()
        {
            //arrange
            var expectedValue = 212M;
            var controller = new BetController(_mockBetBL.Object);
            _mockBetBL.Setup(x => x.GetTotalAmount()).Returns(expectedValue);
            //act
            var result = controller.GetAllTotalAmountBets();
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BetController_GetAllTotalAmountBets_Success_ZeroValue()
        {
            //arrange
            var expectedValue = 0;
            var controller = new BetController(_mockBetBL.Object);
            _mockBetBL.Setup(x => x.GetTotalAmount()).Returns(expectedValue);
            //act
            var result = controller.GetAllTotalAmountBets();
            //assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}
