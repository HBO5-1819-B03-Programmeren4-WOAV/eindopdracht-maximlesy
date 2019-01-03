using CaveBase.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaveBase.Library.DTO
{
    public class CaveDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public int Depth { get; set; }
        public int Length { get; set; }

        public bool IsDivingCave { get; set; }
        public bool HasFormations { get; set; }

        public Difficulty Difficulty { get; set; }

        public int ClubId { get; set; }
        public string ClubName { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
