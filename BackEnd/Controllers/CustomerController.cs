using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;

namespace Backend.Controllers
{

    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerInterface _repo;
        private readonly IMapper _mapper;

        public CustomerController(CustomerInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<CustomerReadDto>> GetAllCustomer()
        {
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(_repo.GetAllCustomers()));
        }

        //Get api/Customers/{customerId}
        [HttpGet("{customerId}")]
        public ActionResult <CustomerReadDto> GetCustomerById(long customerId)
        {
            var customer = _repo.GetCustomerById(customerId);
            if(customer != null)
            {
                return Ok(_mapper.Map<CustomerReadDto>(customer));
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <CustomerReadDto> CreateNewCustomer([FromBody] CustomerReadDto customer)
        {
            return _mapper.Map<CustomerReadDto>(_repo.CreateNewCustomer(customer));
        }

        [HttpPut]
        public ActionResult <CustomerReadDto> UpdateCustomer([FromBody] CustomerReadDto customer)
        {            
            return _mapper.Map<CustomerReadDto>(_repo.UpdateCustomer(customer));
        }

        [HttpDelete("{customerId}")]
        public ActionResult <bool> DeleteCustomerById(long customerId)
        {
            return _repo.DeleteCustomer(customerId);
        }

        //Get api/Customers/GetByEmailAndPassword/{email}/{password}
        [HttpGet("GetByEmailAndPassword/{email}/{password}")]
        public ActionResult <CustomerReadDto> GetByEmailAndPassword(string email, string password)
        {
            return Ok(_mapper.Map<CustomerReadDto>(_repo.GetByEmailAndPassword(email, password)));
        }

        [HttpGet("ValidateCustomer/{email}")]
        public ActionResult <bool> ValidateCustomer(string email)
        {
           return _repo.ValidateCustomer(email);
        }
    }
}