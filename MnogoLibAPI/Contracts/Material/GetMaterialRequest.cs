namespace MnogoLibAPI.Contracts.Material
{
    public class GetMaterialRequest
    {
        public int IdMaterial { get; set; }
        public string NameMaterial { get; set; } = null!;
        public string DescriptionMaterial { get; set; } = null!;
        public int IdCategory { get; set; }
        public int IdAuthorStatus { get; set; }
        public int IdAuthor { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public int FileIcon { get; set; }
    }
}
