using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CaveBase.Library.DTO;
using CaveBase.MVC.ViewModels.Caves;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CaveBase.MVC.Controllers
{
    public class CavesController : Controller
    {
        string baseUrl = "https://localhost:5001/api/caves";

        public IActionResult Index()
        {
            string basicCaveUrl = $"{baseUrl}/basic";
            return View(new IndexViewModel { Caves = GetApiResult<List<CaveBasic>>(basicCaveUrl) });
        }

        public IActionResult Detailed(int id)
        {

            return View(new DetailedCaveViewModel { CaveDetail = GetApiResult<CaveDetail>($"{baseUrl}/detailed/{id}")});
        }

        public T GetApiResult<T>(string url)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(url);

                //Generic T represents the object ((List of) Cave, Caver, Club, ...) we want to send back
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response.Result)).Result;
            }
        }
    }
}