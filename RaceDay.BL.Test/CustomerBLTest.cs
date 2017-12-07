using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceDay.Entity.Interfaces;
using RaceDay.Entity;
using System.Collections.Generic;
using RaceDay.BL.Implementation;
using AutoMapper;
using RaceDay.Contracts.Dto;
using System.Linq.Expressions;

namespace RaceDay.BL.Test
{
    [TestClass]
    public class CustomerBLTest
    {
        private Mock<IRepository<Bet>> _mockBetRepository;
        private Mock<IRepository<Customer>> _mockCustomerRepository;
        private Mock<ICustomerBetRepository> _mockCustomerBetRepository;
        private Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Initialize()
        {
            _mockBetRepository = new Mock<IRepository<Bet>>();
            _mockCustomerRepository = new Mock<IRepository<Customer>>();
            _mockCustomerBetRepository = new Mock<ICustomerBetRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [TestMethod]
        public void CustomerBL_GetAll_ReturnValue()
        {
            //arrange
            var customers = new List<Customer> {
                new Customer { Id = 1, Name = "John" },
                new Customer { Id = 2, Name = "Mark" },
                new Customer { Id = 3, Name = "Eric" },
                new Customer { Id = 4, Name = "Grace" }
            };
            var expectedValue = new List<CustomerDto> {
                new CustomerDto { Id = 1, Name = "John" },
                new CustomerDto { Id = 2, Name = "Mark" },
                new CustomerDto { Id = 3, Name = "Eric" },
                new CustomerDto { Id = 4, Name = "Grace" }
            };
            var bl = new CustomerBL(_mockMapper.Object, _mockCustomerRepository.Object, _mockBetRepository.Object, _mockCustomerBetRepository.Object);
            _mockCustomerRepository.Setup(x => x.All()).Returns(customers);
            _mockMapper.Setup(x => x.Map<List<CustomerDto>>(customers)).Returns(expectedValue);
            //act
            var result = bl.GetAll();
            //assert
            Assert.AreEqual(expectedValue.Count, result.Count);
        }

        [TestMethod]
        public void CustomerBL_GetAll_ReturnNull()
        {
            //arrange
            List<Customer> customers = null;
            List<CustomerDto> expectedValue = null;
            var bl = new CustomerBL(_mockMapper.Object, _mockCustomerRepository.Object, _mockBetRepository.Object, _mockCustomerBetRepository.Object);
            _mockCustomerRepository.Setup(x => x.All()).Returns(customers);
            _mockMapper.Setup(x => x.Map<List<CustomerDto>>(customers)).Returns(expectedValue);
            //act
            var result = bl.GetAll();
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerBL_GetAllAtRisk_ReturnValue()
        {
            //arrange
            var customers = new List<Customer> {
                new Customer { Id = 1, Name = "John" },
                new Customer { Id = 4, Name = "Grace" }
            };
            var expectedValue = new List<CustomerDto> {
                new CustomerDto { Id = 1, Name = "John" },
                new CustomerDto { Id = 4, Name = "Grace" }
            };
            var bl = new CustomerBL(_mockMapper.Object, _mockCustomerRepository.Object, _mockBetRepository.Object, _mockCustomerBetRepository.Object);
            _mockCustomerBetRepository.Setup(x => x.GetAllCustomerAtRisk()).Returns(customers);
            _mockMapper.Setup(x => x.Map<List<CustomerDto>>(customers)).Returns(expectedValue);
            //act
            var result = bl.GetAllAtRisk();
            //assert
            Assert.AreEqual(expectedValue.Count, result.Count);
        }

        [TestMethod]
        public void CustomerBL_GetAllAtRisk_ReturnNull()
        {
            //arrange
            List<Customer> customers = null;
            List<CustomerDto> expectedValue = null;
            var bl = new CustomerBL(_mockMapper.Object, _mockCustomerRepository.Object, _mockBetRepository.Object, _mockCustomerBetRepository.Object);
            _mockCustomerBetRepository.Setup(x => x.GetAllCustomerAtRisk()).Returns(customers);
            _mockMapper.Setup(x => x.Map<List<CustomerDto>>(customers)).Returns(expectedValue);
            //act
            var result = bl.GetAllAtRisk();
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerBL_GetTotalAmountBets_ReturnValue()
        {
            //arrange
            var bets = new List<Bet> {
                new Bet { CustomerId = 1, HorseId = 1, RaceId = 1, Stake = 12 },
                new Bet { CustomerId = 1, HorseId = 2, RaceId = 1, Stake = 1 },
            };

            var expectedValue = 13;
            var bl = new CustomerBL(_mockMapper.Object, _mockCustomerRepository.Object, _mockBetRepository.Object, _mockCustomerBetRepository.Object);
            _mockBetRepository.Setup(x => x.FindBy(It.IsAny<Expression<Func<Bet, bool>>>())).Returns(bets);
            //act
            var result = bl.GetTotalAmountBets(1);
            //assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void CustomerBL_GetTotalAmountBets_ReturnZero()
        {
            //arrange
            List<Bet> bets = null;
            var expectedValue = 0;
            var bl = new CustomerBL(_mockMapper.Object, _mockCustomerRepository.Object, _mockBetRepository.Object, _mockCustomerBetRepository.Object);
            _mockBetRepository.Setup(x => x.FindBy(It.IsAny<Expression<Func<Bet, bool>>>())).Returns(bets);
            //act
            var result = bl.GetTotalAmountBets(2);
            //assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}
