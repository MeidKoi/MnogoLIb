namespace MnogoLibAPI.Contracts.Comment
{
    public class GetCommentRequest
    {
        public int IdComment { get; set; }
        public string TextComment { get; set; } = null!;
        public int IdUser { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
