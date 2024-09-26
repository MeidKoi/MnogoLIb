namespace MnogoLibAPI.Contracts.Comment
{
    public class CreateCommentRequest
    {
        public int IdUser { get; set; }
        public string TextComment { get; set; } = null!;
    }
}