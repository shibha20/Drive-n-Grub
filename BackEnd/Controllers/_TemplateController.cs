using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;
namespace SampleProject.Controllers
{

    [Route("api/ClassNames")]
    [ApiController]
    public class ClassNameController : ControllerBase
    {
        /*
        private readonly ClassNameInterface _repo;
        private readonly IMapper _mapper;

        public ClassNameController(ClassNameInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<ClassNameReadDto>> GetAllClassName()
        {
            return Ok(_mapper.Map<IEnumerable<ClassNameReadDto>>(_repo.GetAllClassNames()));
        }

        //Get api/ClassNames/{classNameId}
        [HttpGet("{classNameId}")]
        public ActionResult <ClassNameReadDto> GetClassNameById(long classNameId)
        {
            var className = _repo.GetClassNameById(classNameId);
            if(className != null)
            {
                return Ok(_mapper.Map<ClassNameReadDto>(className));
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <ClassNameReadDto> CreateNewClassName([FromBody] ClassNameReadDto className)
        {
            return _mapper.Map<ClassNameReadDto>(_repo.CreateNewClassName(className));
        }

        [HttpPut]
        public ActionResult <ClassNameReadDto> UpdateClassName([FromBody] ClassNameReadDto className)
        {            
            return _mapper.Map<ClassNameReadDto>(_repo.UpdateClassName(className));
        }

        [HttpDelete("{classNameId}")]
        public ActionResult <bool> DeleteClassNameById(long classNameId)
        {
            return _repo.DeleteClassName(classNameId);
        }
        */
    }
}