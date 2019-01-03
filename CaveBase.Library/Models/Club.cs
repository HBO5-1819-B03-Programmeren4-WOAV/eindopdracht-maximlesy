using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaveBase.Library.Models
{
    public class Club : EntityBase
    {
        public string Name { get; set; }
        public string Streetname { get; set; }
        public int Housenumber { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
    }
}
