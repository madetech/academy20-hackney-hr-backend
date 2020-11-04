using System;
using System.Collections.Generic;
namespace API.Models
{
    public class UserDetails
    {
        public string name { get; set; }
        public string job_title { get; set; }
        public string email { get; set; }

        public decimal salary { get; set; }

        public string office { get; set; }

        public string contact_information { get; set; }

        public DateTime date_of_birth { get; set; }
        public string next_of_kin { get; set; }

    }
}