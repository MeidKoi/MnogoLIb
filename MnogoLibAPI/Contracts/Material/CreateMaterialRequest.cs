namespace MnogoLibAPI.Contracts.Material
{
    public class CreateMaterialRequest
    {
        public string NameMaterial { get; set; } = null!;
        public string DescriptionMaterial { get; set; } = null!;
        public int IdCategory { get; set; }
        public int IdAuthorStatus { get; set; }
        public int IdAuthor { get; set; }
        public int CreatedBy { get; set; }
        public int FileIcon { get; set; }
    }
}
