using CaveBase.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaveBase.Library.DTO
{
    public class CaveStats
    {
        public int Id { get; set; }
        public string CaveName { get; set; }
        public int TotalRatings { get; set; }
        public Difficulty AverageDifficulty { get; set; }
    }
}
