using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;

namespace Backend.Controllers
{

    [Route("api/Items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemInterface _repo;
        private readonly IMapper _mapper;

        public ItemController(ItemInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<ItemReadDto>> GetAllItem()
        {
            return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(_repo.GetAllItems()));
        }

        //Get api/Items/{itemId}
        [HttpGet("{itemId}")]
        public ActionResult <ItemReadDto> GetItemById(long itemId)
        {
            var item = _repo.GetItemById(itemId);
            if(item != null)
            {
                return Ok(_mapper.Map<ItemReadDto>(item));
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <ItemReadDto> CreateNewItem([FromBody] ItemReadDto item)
        {
            return _mapper.Map<ItemReadDto>(_repo.CreateNewItem(item));
        }

        [HttpPut]
        public ActionResult <ItemReadDto> UpdateItem([FromBody] ItemReadDto item)
        {            
            return _mapper.Map<ItemReadDto>(_repo.UpdateItem(item));
        }

        [HttpDelete("{itemId}")]
        public ActionResult <bool> DeleteItemById(long itemId)
        {
            return _repo.DeleteItem(itemId);
        }

        //Get api/Items/GetItemByItemTypeId/{itemTypeId}
        [HttpGet("GetItemByItemTypeId/{itemTypeId}")]
        public ActionResult<IEnumerable<ItemReadDto>> GetItemByItemTypeId(long itemTypeId)
        {
            return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(_repo.GetItemByItemTypeId(itemTypeId)));
        }
    }
}