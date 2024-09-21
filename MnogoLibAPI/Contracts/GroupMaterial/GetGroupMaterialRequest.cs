namespace MnogoLibAPI.Contracts.GroupMaterial
{
    public class GetGroupMaterialRequest
    {
        public int IdGroup { get; set; }
        public string NameGroup { get; set; } = null!;
        public string DescriptionGroup { get; set; } = null!;
    }
}
