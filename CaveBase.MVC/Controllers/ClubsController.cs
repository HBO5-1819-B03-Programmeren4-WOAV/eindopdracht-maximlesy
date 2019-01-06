using System.Collections.Generic;
using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using CaveBase.MVC.Constants;
using CaveBase.MVC.Helpers;
using CaveBase.MVC.ViewModels.Clubs;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.MVC.Controllers
{
    public class ClubsController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexViewModel { Clubs = WebApiHelper.GetApiResult<List<ClubBasic>>($"{CaveApi.BaseUrl}/clubs/basic") });
        }

        public IActionResult Detailed(int id)
        {
            return View(new DetailedClubViewModel { Club = WebApiHelper.GetApiResult<Club>($"{CaveApi.BaseUrl}/clubs/{id}") });
        }
    }
}