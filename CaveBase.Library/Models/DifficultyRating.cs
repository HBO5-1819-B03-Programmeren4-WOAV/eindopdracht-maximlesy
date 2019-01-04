using System;
using System.Collections.Generic;
using System.Text;

namespace CaveBase.Library.Models
{
    public class DifficultyRating : EntityBase
    {
        public Difficulty Difficulty { get; set; } //defined @ cave

        public int CaverId { get; set; }
        public Caver Caver { get; set; }

        public int CaveId { get; set; }
        public Cave Cave { get; set; }
    }
}
