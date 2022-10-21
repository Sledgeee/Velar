namespace Velar.Core.Models.User
{
    public class ChangePassword
    {
        public string Code { get; set; }
        public string NewPassword { get; set; }
        public string UserId { get; set; }
    }
}