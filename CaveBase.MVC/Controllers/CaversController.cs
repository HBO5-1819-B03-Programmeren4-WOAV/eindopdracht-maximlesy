using CaveBase.MVC.ViewModels.Cavers;
using System.Collections.Generic;
using CaveBase.Library.DTO;
using CaveBase.MVC.Constants;
using CaveBase.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.MVC.Controllers
{
    public class CaversController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexViewModel { Cavers = WebApiHelper.GetApiResult<List<CaverBasic>>($"{CaveApi.BaseUrl}/cavers/basic") });
        }
    }
}