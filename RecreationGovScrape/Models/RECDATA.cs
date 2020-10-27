using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecreationGovScrape.Models
{
    public class RECDATA
    {
        public string FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string FacilityDescription { get; set; }
        public string FacilityTypeDescription { get; set; }
        public double FacilityLongitude { get; set; }
        public double FacilityLatitude { get; set; }
        public string FacilityPhone { get; set; }
        public string FacilityEmail { get; set; }
    }
}
