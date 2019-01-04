using System;
using System.Collections.Generic;
using System.Text;

namespace CaveBase.Library.Models
{
    public class Caver : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<DifficultyRating> DifficultyRatings { get; set; }
    }
}
