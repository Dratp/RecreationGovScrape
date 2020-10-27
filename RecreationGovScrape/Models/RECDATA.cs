using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace RecreationGovScrape.Models
{
    [Table("RIDB")]
    public class RECDATA
    {
        public string FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string FacilityDescription { get; set; }
        public string FacilityTypeDescription { get; set; }
        public string FacilityLongitude { get; set; }
        public string FacilityLatitude { get; set; }
        public string FacilityPhone { get; set; }
        public string FacilityEmail { get; set; }
    }
}
