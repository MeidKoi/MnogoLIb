namespace MnogoLibAPI.Contracts.CommentRate
{
    public class GetCommentRateRequest
    {
        public int IdUser { get; set; }
        public int IdComment { get; set; }
        public int Value { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
