using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blockchain
{
    class Contract
    {
        public int contract_no { get; set; }
        public string contract_name { get; set; }
        public string project { get; set; }
        public float amount { get; set; }
        public string date { get; set; }
        public string type { get; set; }
        public string parties { get; set; }
        public int penalty { get; set; }
        public string status { get; set; }
    }
}
