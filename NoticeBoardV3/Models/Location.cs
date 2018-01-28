using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoardV3.Models
{
    public class Location
    {
        [Key]
        public int Location_ID { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        public virtual ICollection<PerOrgLocation> PerOrgLocations { get; set; }
    }
}