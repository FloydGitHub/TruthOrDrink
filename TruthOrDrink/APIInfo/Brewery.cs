﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.APIInfo
{
    public class Brewery
    {
        public string id { get; set; }
        public string name { get; set; }
        public string brewery_type { get; set; }
        public string address_1 { get; set; }
        public object address_2 { get; set; }
        public object address_3 { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string phone { get; set; }
        public string website_url { get; set; }
        public string state { get; set; }
        public string street { get; set; }
    }
}
