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
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return Ok(_mapper.Map<IEnumerable<ClassNameReadDto>>(_repo.GetAllClassNames(backEndContext)));
            }
        }

        //Get api/ClassNames/{classNameId}
        [HttpGet("{classNameId}")]
        public ActionResult <ClassNameReadDto> GetClassNameById(long classNameId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                var className = _repo.GetClassNameById(backEndContext, classNameId);
                if(className != null)
                {
                    return Ok(_mapper.Map<ClassNameReadDto>(className));
                }
                else{
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult <ClassNameReadDto> CreateNewClassName([FromBody] ClassName className)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<ClassNameReadDto>(_repo.CreateNewClassName(backEndContext, className));
            }
        }

        [HttpPut]
        public ActionResult <ClassNameReadDto> UpdateClassName([FromBody] ClassName className)
        {            
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<ClassNameReadDto>(_repo.UpdateClassName(backEndContext,className));
            }
        }

        [HttpDelete("{classNameId}")]
        public ActionResult <bool> DeleteClassNameById(long classNameId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _repo.DeleteClassName(backEndContext, classNameId);
            }
        }
        */
    }
}