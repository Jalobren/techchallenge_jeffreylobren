using RaceDay.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDay.Contracts.Dto;
using RaceDay.Entity.Interfaces;
using AutoMapper;
using RaceDay.Entity;

namespace RaceDay.BL.Implementation
{
    public class CustomerBL : ICustomerBL
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Bet> _betRepository;
        private readonly ICustomerBetRepository _customerBetRepository;
        private readonly IMapper _mapper;

        public CustomerBL(IMapper mapper, IRepository<Customer> customerRepository, IRepository<Bet> betRepository, ICustomerBetRepository customerBetRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _betRepository = betRepository;
            _customerBetRepository = customerBetRepository;
        }

        public List<CustomerDto> GetAll()
        {
            return _mapper.Map<List<CustomerDto>>(_customerRepository.All());
        }

        public List<CustomerDto> GetAllAtRisk()
        {
            var customers = _customerBetRepository.GetAllCustomerAtRisk();
            if (customers != null)
            {
                return _mapper.Map<List<CustomerDto>>(customers);
            }
            return null;
        }

        public decimal GetTotalAmountBets(int customerId)
        {
            var customerbets = _betRepository.FindBy(x => x.CustomerId == customerId);
            if (customerbets != null)
            {
                return customerbets.Sum(x => x.Stake);
            }
            return 0;
        }

        public int GetTotalBets(int customerId)
        {
            var customerbets = _betRepository.FindBy(x => x.CustomerId == customerId);
            if (customerbets != null)
            {
                return customerbets.Count();
            }
            return 0;
        }
    }
}
