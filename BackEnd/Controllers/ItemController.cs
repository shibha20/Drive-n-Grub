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
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(_repo.GetAllItems(backEndContext)));
            }
        }

        //Get api/Items/{itemId}
        [HttpGet("{itemId}")]
        public ActionResult <ItemReadDto> GetItemById(long itemId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                var item = _repo.GetItemById(backEndContext, itemId);
                if(item != null)
                {
                    return Ok(_mapper.Map<ItemReadDto>(item));
                }
                else{
                    return NotFound();
                }
            }
        }

        //Get api/Items/GetItemByItemTypeId/{itemTypeId}
        [HttpGet("GetItemByItemTypeId/{itemTypeId}")]
        public ActionResult <IEnumerable<ItemReadDto>> GetItemByItemTypeId(long itemTypeId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(_repo.GetItemByItemTypeId(backEndContext, itemTypeId)));
            }
        }

        [HttpPost]
        public ActionResult <ItemReadDto> CreateNewItem([FromBody] Item item)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<ItemReadDto>(_repo.CreateNewItem(backEndContext, item));
            }
        }

        [HttpPut]
        public ActionResult <ItemReadDto> UpdateItem([FromBody] Item item)
        {            
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<ItemReadDto>(_repo.UpdateItem(backEndContext,item));
            }
        }

        [HttpDelete("{itemId}")]
        public ActionResult <bool> DeleteItemById(long itemId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _repo.DeleteItem(backEndContext, itemId);
            }
        }
    }
}