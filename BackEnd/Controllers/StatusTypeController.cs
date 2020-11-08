using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;
namespace SampleProject.Controllers
{

    [Route("api/StatusTypes")]
    [ApiController]
    public class StatusTypeController : ControllerBase
    {
        private readonly StatusTypeInterface _repo;
        private readonly IMapper _mapper;

        public StatusTypeController(StatusTypeInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<StatusTypeReadDto>> GetAllStatusType()
        {
            return Ok(_mapper.Map<IEnumerable<StatusTypeReadDto>>(_repo.GetAllStatusTypes()));
        }

        //Get api/StatusTypes/{statusTypeId}
        [HttpGet("{statusTypeId}")]
        public ActionResult <StatusTypeReadDto> GetStatusTypeById(long statusTypeId)
        {
            var statusType = _repo.GetStatusTypeById(statusTypeId);
            if(statusType != null)
            {
                return Ok(_mapper.Map<StatusTypeReadDto>(statusType));
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <StatusTypeReadDto> CreateNewStatusType([FromBody] StatusTypeReadDto statusType)
        {
            return _mapper.Map<StatusTypeReadDto>(_repo.CreateNewStatusType(statusType));
        }

        [HttpPut]
        public ActionResult <StatusTypeReadDto> UpdateStatusType([FromBody] StatusTypeReadDto statusType)
        {            
            return _mapper.Map<StatusTypeReadDto>(_repo.UpdateStatusType(statusType));
        }

        [HttpDelete("{statusTypeId}")]
        public ActionResult <bool> DeleteStatusTypeById(long statusTypeId)
        {
            return _repo.DeleteStatusType(statusTypeId);
        }
    }
}