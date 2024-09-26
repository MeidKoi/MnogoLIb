namespace MnogoLibAPI.Contracts.ChatUser
{
    public class CreateChatUserRequest
    {
        public int IdUser { get; set; }
        public int IdChat { get; set; }
        public int CreatedBy { get; set; }
    }
}