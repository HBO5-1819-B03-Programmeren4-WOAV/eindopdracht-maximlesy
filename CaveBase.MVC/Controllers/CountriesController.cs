using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.MVC.Controllers
{
    public class CountriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}