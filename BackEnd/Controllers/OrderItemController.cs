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
            return Ok(_mapper.Map<IEnumerable<OrderItemReadDto>>(_repo.GetAllOrderItems()));
        }

        //Get api/OrderItems/{orderItemId}
        [HttpGet("{orderItemId}")]
        public ActionResult <OrderItemReadDto> GetOrderItemById(long orderItemId)
        {
            var orderItem = _repo.GetOrderItemById(orderItemId);
            if(orderItem != null)
            {
                return Ok(_mapper.Map<OrderItemReadDto>(orderItem));
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <OrderItemReadDto> CreateNewOrderItem([FromBody] OrderItemReadDto orderItem)
        {
            return _mapper.Map<OrderItemReadDto>(_repo.CreateNewOrderItem(orderItem));
        }

        [HttpPut]
        public ActionResult <OrderItemReadDto> UpdateOrderItem([FromBody] OrderItemReadDto orderItem)
        {            
            return _mapper.Map<OrderItemReadDto>(_repo.UpdateOrderItem(orderItem));
        }

        [HttpDelete("{orderItemId}")]
        public ActionResult <bool> DeleteOrderItemById(long orderItemId)
        {
            return _repo.DeleteOrderItem(orderItemId);
        }
        [HttpGet("GetAllByOrderId/{orderId}")]
        public ActionResult<List<OrderItemReadDto>> GetAllOrderItem(long orderId)
        {
            return Ok(_mapper.Map<List<OrderItemReadDto>>(_repo.GetAllByOrderId(orderId)));
        }
    }
}