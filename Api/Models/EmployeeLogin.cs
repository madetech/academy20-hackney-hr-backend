namespace Api.Models
{
    public class EmployeeLogin
    {
        public int id { get; set; }
        public string contact_email { get; set; }
        public string password { get; set; }
        public bool manager { get; set; }
        public bool admin { get; set; }
        public bool employee { get; set; }
        public bool contractor_or_volunteer { get; set; }

    }
}
