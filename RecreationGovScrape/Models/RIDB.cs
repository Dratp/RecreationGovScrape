using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecreationGovScrape.Models
{
    public class RIDB
    {
        public RECDATA[] recData { get; set; }
        public METADATA metaData { get; set; }
    }


    public class METADATA
    {
        public Results results { get; set; }
    }

    public class Results
    {
        public int current_count { get; set; }
        public int total_count { get; set; }
    }

}


