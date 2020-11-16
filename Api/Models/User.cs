namespace Api.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string job_title { get; set; }
        public string contact_email { get; set; }
        public long contact_number { get; set; }
        public string salary_band { get; set; }
        public string home_address_line_1 { get; set; }
        public string home_address_line_2 { get; set; }
        public string home_address_city {get; set; }
        public string home_address_postcode { get; set; }
        public string office_location {get; set; }
        public string manager { get; set; }
        public string reportees { get; set; }
        public string next_of_kin_first_name { get; set; }
        public string next_of_kin_last_name { get; set; }
        public long next_of_kin_contact_number { get; set; }
        
    }
}

