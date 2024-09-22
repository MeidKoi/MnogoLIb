namespace MnogoLibAPI.Contracts.File
{
    public class GetFileRequest
    {
        public int IdFile { get; set; }
        public string NameFile { get; set; } = null!;
        public string PathFile { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}