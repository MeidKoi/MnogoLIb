namespace MnogoLibAPI.Contracts.MessageUser
{
    public class GetMessageUserRequest
    {
        public int IdMessage { get; set; }
        public int IdUser { get; set; }
        public int IdChat { get; set; }
        public DateTime DeliverDate { get; set; }
        public int IdMessageStatus { get; set; }
        public string TextMessage { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}