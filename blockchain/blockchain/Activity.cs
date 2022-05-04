using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blockchain
{
    class Activity
    {
        public int activity_no { get; set; }
        public string project { get; set; }
        public string activity_name { get; set; }
        public string duration { get; set; }
        public string start_date { get; set; }
        public string finish_date { get; set; }
        public string price { get; set; }
        public string status { get; set; }
        public string approved { get; set; }
        public string delays { get; set; }
        public string contract_name { get; set; }
    }
}
