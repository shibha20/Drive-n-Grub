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
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(_repo.GetAllCustomers(backEndContext)));
            }
        }

        //Get api/Customers/{customerId}
        [HttpGet("{customerId}")]
        public ActionResult <CustomerReadDto> GetCustomerById(long customerId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                    Customer customer = _repo.GetCustomerById(backEndContext, customerId);
                    if(customer != null)
                    {
                        return Ok(_mapper.Map<CustomerReadDto>(customer));
                    }
                    else{
                        return NotFound();
                    }
            }
        }

        [HttpPost]
        public ActionResult <CustomerReadDto> CreateNewCustomer([FromBody] Customer customer)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<CustomerReadDto>(_repo.CreateNewCustomer(backEndContext, customer));
            }
        }

        [HttpPut]
        public ActionResult <CustomerReadDto> UpdateCustomer([FromBody] Customer customer)
        {            
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<CustomerReadDto>(_repo.UpdateCustomer(backEndContext,customer));
            }
        }

        [HttpDelete("{customerId}")]
        public ActionResult <bool> DeleteCustomerById(long customerId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _repo.DeleteCustomer(backEndContext, customerId);
            }
        }

        //Get api/Customers/GetByEmailAndPassword/{email}/{password}
        [HttpGet("GetByEmailAndPassword/{email}/{password}")]
        public ActionResult <CustomerReadDto> GetByEmailAndPassword(string email, string password)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                var customer = _repo.GetByEmailAndPassword(backEndContext, email, password);
                if(customer != null)
                {
                    return Ok(_mapper.Map<CustomerReadDto>(customer));
                }
                else{
                    return NotFound();
                }
            }
        }

        [HttpGet("ValidateCustomer/{email}")]
        public ActionResult <bool> ValidateCustomer(string email)
        {
           return _repo.ValidateCustomer(email);
        }
    }
}