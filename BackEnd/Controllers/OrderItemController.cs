using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;

namespace Backend.Controllers
{

    [Route("api/OrderItems")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemInterface _repo;
        private readonly IMapper _mapper;

        public OrderItemController(OrderItemInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

                [HttpGet]
        public ActionResult <IEnumerable<OrderItemReadDto>> GetAllOrderItem()
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return Ok(_mapper.Map<OrderItemReadDto>(_repo.GetAllOrderItems(backEndContext)));
            }
        }

        //Get api/OrderItems/{orderItemId}
        [HttpGet("{orderItemId}")]
        public ActionResult <OrderItemReadDto> GetOrderItemById(long orderItemId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                var orderItem = _repo.GetOrderItemById(backEndContext, orderItemId);
                if(orderItem != null)
                {
                    return Ok(_mapper.Map<OrderItemReadDto>(orderItem));
                }
                else{
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult <OrderItemReadDto> CreateNewOrderItem([FromBody] OrderItem orderItem)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<OrderItemReadDto>(_repo.CreateNewOrderItem(backEndContext, orderItem));
            }
        }

        [HttpPut]
        public ActionResult <OrderItemReadDto> UpdateOrderItem([FromBody] OrderItem orderItem)
        {            
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _mapper.Map<OrderItemReadDto>(_repo.UpdateOrderItem(backEndContext,orderItem));
            }
        }

        [HttpDelete("{orderItemId}")]
        public ActionResult <bool> DeleteOrderItemById(long orderItemId)
        {
            using(BackEndContext backEndContext = BackEndContext.CreateContext())
            {
                return _repo.DeleteOrderItem(backEndContext, orderItemId);
            }
        }
    }
}