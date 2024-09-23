namespace ParadisePromotions.Core.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }


    }

    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
