namespace MnogoLibAPI.Contracts.MessageUser
{
    public class CreateMessageUserRequest
    {
        public int IdUser { get; set; }
        public int IdChat { get; set; }
        public int IdMessageStatus { get; set; }
        public string TextMessage { get; set; } = null!;
    }
}
