using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;
namespace SampleProject.Controllers
{

    [Route("api/Businesses")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly BusinessInterface _repo;
        private readonly IMapper _mapper;

        public BusinessController(BusinessInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<BusinessReadDto>> GetAllBusinesses()
        {
            return Ok(_mapper.Map<IEnumerable<BusinessReadDto>>(_repo.GetAllBusinesses()));
        }

        //Get api/Businesss/{businessId}
        [HttpGet("{businessId}")]
        public ActionResult <BusinessReadDto> GetBusinessById(long businessId)
        {
            var business = _repo.GetBusinessById(businessId);
            if(business != null)
            {
                return Ok(_mapper.Map<BusinessReadDto>(business));
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <BusinessReadDto> CreateNewBusiness([FromBody] BusinessReadDto business)
        {
            return _mapper.Map<BusinessReadDto>(_repo.CreateNewBusiness(business));
        }

        [HttpPut]
        public ActionResult <BusinessReadDto> UpdateBusiness([FromBody] BusinessReadDto business)
        {            
            return _mapper.Map<BusinessReadDto>(_repo.UpdateBusiness(business));
        }

        [HttpDelete("{businessId}")]
        public ActionResult <bool> DeleteBusinessById(long businessId)
        {
            return _repo.DeleteBusiness(businessId);
        }

        [HttpGet("GetByEmailAndPassword/{email}/{password}")]
        public ActionResult <BusinessReadDto> GetByEmailAndPassword(string email, string password)
        {
            var business = _repo.GetByEmailAndPassword(email, password);
            if(business != null)
            {
                return Ok(_mapper.Map<BusinessReadDto>(business));
            }
            else{
                return NotFound();
            }
        }
    }
}