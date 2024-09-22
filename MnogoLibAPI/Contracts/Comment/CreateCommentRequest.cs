namespace MnogoLibAPI.Contracts.Comment
{
    public class CreateCommentRequest
    {
        public string TextComment { get; set; } = null!;
        public int IdUser { get; set; }
    }
}