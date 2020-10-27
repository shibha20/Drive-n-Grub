using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;
namespace Backend.Controllers
{

    [Route("api/ItemTypes")]
    [ApiController]
    public class ItemTypeController : ControllerBase
    {
        private readonly ItemTypeInterface _repo;
        private readonly IMapper _mapper;

        public ItemTypeController(ItemTypeInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<ItemTypeReadDto>> GetAllItemType()
        {
            return Ok(_mapper.Map<IEnumerable<ItemTypeReadDto>>(_repo.GetAllItemTypes()));
        }

        //Get api/ItemTypes/{itemTypeId}
        [HttpGet("{itemTypeId}")]
        public ActionResult <ItemTypeReadDto> GetItemTypeById(long itemTypeId)
        {
            var itemType = _repo.GetItemTypeById(itemTypeId);
            if(itemType != null)
            {
                return Ok(_mapper.Map<ItemTypeReadDto>(itemType));
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <ItemTypeReadDto> CreateNewItemType([FromBody] ItemTypeReadDto itemType)
        {
            return _mapper.Map<ItemTypeReadDto>(_repo.CreateNewItemType(itemType));
        }

        [HttpPut]
        public ActionResult <ItemTypeReadDto> UpdateItemType([FromBody] ItemTypeReadDto itemType)
        {            
            return _mapper.Map<ItemTypeReadDto>(_repo.UpdateItemType(itemType));
        }

        [HttpDelete("{itemTypeId}")]
        public ActionResult <bool> DeleteItemTypeById(long itemTypeId)
        {
            return _repo.DeleteItemType(itemTypeId);
        }
    }
}