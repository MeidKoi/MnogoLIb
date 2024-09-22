namespace MnogoLibAPI.Contracts.ChatUser
{
    public class GetChatUserRequest
    {
        public int IdUser { get; set; }
        public int IdChat { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}