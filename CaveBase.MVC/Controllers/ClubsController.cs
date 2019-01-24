using System.Collections.Generic;
using System.Threading.Tasks;
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
            ViewBag.Mode = "Detailed";
            return View(new DetailedClubViewModel { Club = WebApiHelper.GetApiResult<Club>($"{CaveApi.BaseUrl}/clubs/{id}") });
        }

        public IActionResult Insert()
        {
            ViewBag.Mode = "Edit";
            return View("Detailed", new DetailedClubViewModel { Club = new Club() });
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Mode = "Edit";
            return View("Detailed", new DetailedClubViewModel { Club = WebApiHelper.GetApiResult<Club>($"{CaveApi.BaseUrl}/clubs/{id}") });
        }

        [HttpPost]
        public async Task<IActionResult> Save(Club club)
        {
            if (club.Id == 0) club = await WebApiHelper.PostCallApi<Club, Club>($"{CaveApi.BaseUrl}/clubs", club); //insert
            else club = await WebApiHelper.PutCallApi<Club, Club>($"{CaveApi.BaseUrl}/clubs/{club.Id}", club); //update

            ViewBag.Mode = "Detailed";
            return View("Detailed", new DetailedClubViewModel { Club = club });
        }

        public async Task<IActionResult> Delete(int id)
        {
            Club deleteClub = await WebApiHelper.DeleteCallApi<Club>($"{CaveApi.BaseUrl}/clubs/{id}");
            return RedirectToAction("Index");
        }

        public IActionResult IndexVue()
        {
            return View(new IndexVueViewModel { ApiUrl = WebApiHelper.apiUrl });
        }


    }
}