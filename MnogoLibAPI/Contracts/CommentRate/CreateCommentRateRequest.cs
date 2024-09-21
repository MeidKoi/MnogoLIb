namespace MnogoLibAPI.Contracts.CommentRate
{
    public class CreateCommentRateRequest
    {
        public int IdUser { get; set; }
        public int IdComment { get; set; }
        public int Value { get; set; }
    }
}
