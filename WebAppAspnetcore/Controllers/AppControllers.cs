using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppAspnetcore.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAspnetcore.Controllers
{
    public class AppController : Controller
    {
        // GET: /<controller>/
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

            }else{

            }
            return View();

        }

        public IActionResult About(){
            ViewBag.Title = "Sobre";
            return View();
        }
    }
} 
