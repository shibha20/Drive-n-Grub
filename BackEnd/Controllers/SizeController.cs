using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;

namespace Backend.Controllers
{

    [Route("api/Sizes")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly SizeInterface _repo;
        private readonly IMapper _mapper;

        public SizeController(SizeInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

                [HttpGet]
        public ActionResult <IEnumerable<SizeReadDto>> GetAllSize()
        {
            return Ok(_mapper.Map<IEnumerable<SizeReadDto>>(_repo.GetAllSizes()));
        }

        //Get api/Sizes/{sizeId}
        [HttpGet("{sizeId}")]
        public ActionResult <SizeReadDto> GetSizeById(long sizeId)
        {
            var size = _repo.GetSizeById(sizeId);
            if(size != null)
            {
                return Ok(_mapper.Map<SizeReadDto>(size));
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <SizeReadDto> CreateNewSize([FromBody] SizeReadDto size)
        {
            return _mapper.Map<SizeReadDto>(_repo.CreateNewSize(size));
        }

        [HttpPut]
        public ActionResult <SizeReadDto> UpdateSize([FromBody] SizeReadDto size)
        {            
            return _mapper.Map<SizeReadDto>(_repo.UpdateSize(size));
        }

        [HttpDelete("{sizeId}")]
        public ActionResult <bool> DeleteSizeById(long sizeId)
        {
            return _repo.DeleteSize(sizeId);
        }
    }
}