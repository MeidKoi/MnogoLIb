namespace MnogoLibAPI.Contracts.MaterialUserStatus
{
    public class CreateMaterialUserStatusRequest
    {
        public int IdMaterial { get; set; }
        public int IdUser { get; set; }
        public int IdUserStatus { get; set; }
    }
}
