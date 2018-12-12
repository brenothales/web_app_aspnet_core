using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppAspnetcore.Data;
using WebAppAspnetcore.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAspnetcore.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IDutchRepository repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
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

                if (order != null) return Ok(order);
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders? {ex}");
                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]Order model)
        {
            try
            {
                _repository.AddEntity(model);

               if (_repository.SaveAll())
                {
                    return Created($"/api/orders/{model.Id}", model);
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
