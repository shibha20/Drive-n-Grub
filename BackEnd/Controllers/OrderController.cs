using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;

namespace Backend.Controllers
{

    [Route("api/Orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderInterface _repo;
        private readonly IMapper _mapper;

        public OrderController(OrderInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<OrderReadDto>> GetAllOrder()
        {
            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(_repo.GetAllOrders()));
        }

        //Get api/Orders/{orderId}
        [HttpGet("{orderId}")]
        public ActionResult <OrderReadDto> GetOrderById(long orderId)
        {
            var order = _repo.GetOrderById(orderId);
            if(order != null)
            {
                return Ok(_mapper.Map<OrderReadDto>(order));
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <OrderReadDto> CreateNewOrder([FromBody] OrderReadDto order)
        {
            return _mapper.Map<OrderReadDto>(_repo.CreateNewOrder(order));
        }

        [HttpPut]
        public ActionResult <OrderReadDto> UpdateOrder([FromBody] OrderReadDto order)
        {            
            return _mapper.Map<OrderReadDto>(_repo.UpdateOrder(order));
        }

        [HttpDelete("{orderId}")]
        public ActionResult <bool> DeleteOrderById(long orderId)
        {
            return _repo.DeleteOrder(orderId);
        }
    }
}