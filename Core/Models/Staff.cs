namespace ParadisePromotions.Core.Models
{
    public class Staff
    {
        public int? StaffID { get; set; }
        public int? RoleID { get; set; }
        public string? Name { get; set; }
        public string? SSN { get; set; }
        public DateTime? Hire_date { get; set; }
        public string? Class { get; set; }
        public string? Password { get; set; }
        public bool? isAdmin { get; set; }
        public bool? IsVerifier { get; set; }
        public bool? IsActiveReloader { get; set; }
        public bool? Active { get; set; }



    }

    public class LoginRequestModel
    {
        public int? StaffID { get; set; }
        public string? Password { get; set; }
    }

    public class LoginResponceModel
    {
        public string? Name { get; set; }
        public string? token { get; set; }
    }
}
