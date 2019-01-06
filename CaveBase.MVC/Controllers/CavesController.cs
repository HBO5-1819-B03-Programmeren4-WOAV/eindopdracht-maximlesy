using System.Collections.Generic;
using CaveBase.Library.DTO;
using CaveBase.MVC.Constants;
using CaveBase.MVC.Helpers;
using CaveBase.MVC.ViewModels.Caves;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.MVC.Controllers
{
    public class CavesController : Controller
    {
        public IActionResult Index()
        {
            string caveBasic = $"{CaveApi.BaseUrl}/caves/basic";
            return View(new IndexViewModel { Caves = WebApiHelper.GetApiResult<List<CaveBasic>>(caveBasic) });
        }

        public IActionResult Detailed(int id)
        {
            return View(new DetailedCaveViewModel { CaveDetail = WebApiHelper.GetApiResult<CaveDetail>($"{CaveApi.BaseUrl}/caves/detailed/{id}") });
        }
    }
}