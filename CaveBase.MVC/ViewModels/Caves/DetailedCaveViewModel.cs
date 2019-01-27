using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.MVC.ViewModels.Caves
{
    public class DetailedCaveViewModel
    {
        public CaveDetail CaveDetail { get; set; }
        public string ApiUrl { get; set; }
        public int Id { get; set; }
    }
}
