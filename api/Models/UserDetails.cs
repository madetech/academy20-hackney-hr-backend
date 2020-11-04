using System;
using System.Collections.Generic;
namespace API.Models
{
    public class UserDetails
    {
        public long id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string job_title { get; set; }
        public string contact_email { get; set; }
        public decimal salary { get; set; }
        public string street_address { get; set; }
        public string postcode { get; set; }
        public string next_of_kin_first_name { get; set; }
        public string next_of_kin_last_name { get; set; }

    }
}

