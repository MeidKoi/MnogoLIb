namespace MnogoLibAPI.Contracts.Chat
{
    public class CreateChatRequest
    {
        public int IdOwner {get; set;}
        public string NameChat { get; set; } = null!;
    }
}