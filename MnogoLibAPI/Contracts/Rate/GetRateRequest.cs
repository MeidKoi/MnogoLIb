namespace MnogoLibAPI.Contracts.Rate
{
    public class GetRateRequest
    {
        public int IdRate { get; set; }
        public int IdUser { get; set; }
        public int IdMaterial { get; set; }
        public byte ValueRate { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}