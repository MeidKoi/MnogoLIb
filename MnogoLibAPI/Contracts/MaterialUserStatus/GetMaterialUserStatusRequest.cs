namespace MnogoLibAPI.Contracts.MaterialUserStatus
{
    public class GetMaterialUserStatusRequest
    {
        public int IdMaterial { get; set; }
        public int IdUser { get; set; }
        public int IdUserStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}