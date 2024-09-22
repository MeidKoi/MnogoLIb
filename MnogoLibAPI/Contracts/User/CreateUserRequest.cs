namespace MnogoLibAPI.Contracts.User
{
    public class CreateUserRequest
    {
        //public int IdUser { get; set; }
        public string EmailUser { get; set; } = null!;
        public string PasswordUser { get; set; } = null!;
        public string NicknameUser { get; set; } = null!;
        //public int IdRole { get; set; }
        //public DateTime CreatedTime { get; set; }
        //public int LastUpdateBy { get; set; }
        //public DateTime LastUpdateTime { get; set; }
        //public int? DeletedBy { get; set; }
        //public DateTime? DeletedTime { get; set; }
    }
}