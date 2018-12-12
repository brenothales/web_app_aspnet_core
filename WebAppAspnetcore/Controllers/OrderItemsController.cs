using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppAspnetcore.Data;
using WebAppAspnetcore.Data.Entities;
using WebAppAspnetcore.ViewModels;

namespace WebAppAspnetcore.Controllers
{
    [Route("/api/orders/{orderid}/items")]
    public class OrderItemsController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(
            IDutchRepository repository, ILogger<OrderItemsController> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = _repository.GetOrdersById(orderId);
            if (order != null) return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderViewModels>>(order.Items));
            return NotFound();
        }

        public IActionResult Get(int orderId, int id)
        {
            var order = _repository.GetOrdersById(orderId);
            if (order != null) 
            {
                var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                if (item != null)
                {
                    return Ok(_mapper.Map<OrderItem, OrderViewModels>(item));
                }

            }
            return NotFound();
        }
    }
}
