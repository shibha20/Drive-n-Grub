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
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                var itemTypes = _repo.GetAllItemTypes(backEndContext);
                return Ok(_mapper.Map<IEnumerable<ItemTypeReadDto>>(itemTypes));
            }
        }

        //Get api/ItemTypes/{itemTypeId}
        [HttpGet("{itemTypeId}")]
        public ActionResult <ItemTypeReadDto> GetItemTypeById(long itemTypeId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                var itemType = _repo.GetItemTypeById(backEndContext, itemTypeId);
                if(itemType != null)
                {
                    return Ok(_mapper.Map<ItemTypeReadDto>(itemType));
                }
                else{
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult <ItemTypeReadDto> CreateNewItemType([FromBody] ItemType itemType)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<ItemTypeReadDto>(_repo.CreateNewItemType(backEndContext, itemType));
            }
        }

        [HttpPut]
        public ActionResult <ItemTypeReadDto> UpdateItemType([FromBody] ItemType itemType)
        {            
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<ItemTypeReadDto>(_repo.UpdateItemType(backEndContext,itemType));
            }
        }

        [HttpDelete("{itemTypeId}")]
        public ActionResult <bool> DeleteItemTypeById(long itemTypeId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _repo.DeleteItemType(backEndContext, itemTypeId);
            }
        }
    }
}