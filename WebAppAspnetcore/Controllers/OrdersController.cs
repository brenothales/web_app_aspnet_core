using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppAspnetcore.Data;
using WebAppAspnetcore.Data.Entities;
using WebAppAspnetcore.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAspnetcore.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(IDutchRepository repository, 
                                ILogger<OrdersController> logger,
                                IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModels>>(_repository.GetAllOrders()));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get orders? {ex}");
                return BadRequest("Failed to get orders");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetAllOrdersById(id);

                if (order != null) return Ok(_mapper.Map<Order, OrderViewModels>(order));
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders? {ex}");
                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = _mapper.Map<OrderViewModels, Order>(model);

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }
                    _repository.AddEntity(newOrder);

                    if (_repository.SaveAll())
                    {
                        return Created($"/api/orders/{newOrder.Id}", _mapper.Map<Order, OrderViewModels>(newOrder));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"Falha para a salvar uma nova order: {ex}");
            }

            return BadRequest("Falha para salvar nova ordem");
        }   


    }

}
