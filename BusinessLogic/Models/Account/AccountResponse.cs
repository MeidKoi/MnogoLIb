namespace BusinessLogic.Models.Accounts
{
    public class AccountResponse
    {
        public int IdUser { get; set; }
        public string EmailUser { get; set; } = null!;
        public string PasswordUser { get; set; } = null!;
        public string NicknameUser { get; set; } = null!;
        public int IdRole { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public bool IsVerified { get; set; }
    }
}