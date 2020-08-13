using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrevithickP4.Models
{
    public class Campaign
    {

        public int Id { get; set; }
        
        public string Vendor { get; set; }
       
        public string Candidate { get; set; }
      
        public string Contributor { get; set; }
        
        public string Relationship { get; set; }
        
        public string Datetime { get; set; }
        
        public string Contribution { get; set; }

    }
}
