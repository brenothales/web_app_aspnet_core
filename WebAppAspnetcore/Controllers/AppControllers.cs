using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppAspnetcore.Data;
using WebAppAspnetcore.Services;
using WebAppAspnetcore.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAspnetcore.Controllers
{
    public class AppController : Controller
    {
        public IMailService _mailService;
        private readonly IDutchRepository _repository;


        public AppController(IMailService mailService, IDutchRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
         
        }


        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Contato")]
        public IActionResult Contact(){
            ViewBag.Title = "Contato";

            return View();
        }


        [HttpPost("Contato")]
        public IActionResult Contact(ContactViewModels model){
           
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("breno.thales@gmail.com", model.Observacao, $"From:{model.Email}, Messege:{model.Message}");
                ViewBag.UserMessage = "Email Enviado";

            }
            else{

            }
            return View();

        }

        public IActionResult About(){
            ViewBag.Title = "Sobre";
            return View();
        }

        public IActionResult Shop(){
            var results = _repository.GetAllProducts();
            return View(results);
        }
    }
} 
