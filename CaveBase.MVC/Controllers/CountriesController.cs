using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveBase.MVC.Helpers;
using CaveBase.MVC.ViewModels.Countries;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.MVC.Controllers
{
    public class CountriesController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexViewModel { BaseUrl = WebApiHelper.apiUrl });
        }
    }
}