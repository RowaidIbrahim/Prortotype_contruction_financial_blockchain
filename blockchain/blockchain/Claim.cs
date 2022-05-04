using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blockchain
{
    class Claim
    {
        public int claimId { get; set; }
        public string claim { get; set; }
        public string status { get; set; }
        public string username { get; set; }

        public string contract_name { get; set; }
        public DateTime timestamp { get; set; }
    }
}
