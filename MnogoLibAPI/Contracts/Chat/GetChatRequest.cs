namespace MnogoLibAPI.Contracts.Chat
{
    public class GetChatRequest
    {
        public int IdChat { get; set; }
        public int IdOwner { get; set; }
        public string NameChat { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}