using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceDay.Entity.Interfaces;
using Moq;
using RaceDay.Entity;
using RaceDay.BL.Implementation;
using System.Collections.Generic;

namespace RaceDay.BL.Test
{
    [TestClass]
    public class BetBLTest
    {
        private Mock<IRepository<Bet>> _mockBetRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockBetRepository = new Mock<IRepository<Bet>>();
        }

        [TestMethod]
        public void BetBL_GetTotalAmount_ReturnValue()
        {
            //arrange
            var expectedValue = 40;
            var bets = new List<Bet> {
                new Bet { CustomerId = 1, HorseId = 1, RaceId = 1, Stake = 12 },
                new Bet { CustomerId = 1, HorseId = 2, RaceId = 1, Stake = 1 },
                new Bet { CustomerId = 2, HorseId = 1, RaceId = 1, Stake = 2 },
                new Bet { CustomerId = 3, HorseId = 2, RaceId = 1, Stake = 25 }
            };
            var bl = new BetBL(_mockBetRepository.Object);
            _mockBetRepository.Setup(x => x.All()).Returns(bets);
            //act
            var result = bl.GetTotalAmount();
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BetBL_GetTotalAmount_ReturnZero()
        {
            //arrange
            var expectedValue = 0;
            List<Bet> bets = null;
            var bl = new BetBL(_mockBetRepository.Object);
            _mockBetRepository.Setup(x => x.All()).Returns(bets);
            //act
            var result = bl.GetTotalAmount();
            //assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}
