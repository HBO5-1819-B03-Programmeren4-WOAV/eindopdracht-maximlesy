using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaveBase.Library.Models
{
    public class Cave : EntityBase
    {
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
        public Club Club { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public string PhotoName { get; set; }

        public ICollection<DifficultyRating> Ratings { get; set; }
    }

    public enum Difficulty
    {
        None,
        Easy,
        Normal,
        Medium,
        Difficult,
        Expert
    }
}
