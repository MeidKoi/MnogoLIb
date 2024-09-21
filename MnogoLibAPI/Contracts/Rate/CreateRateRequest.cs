namespace MnogoLibAPI.Contracts.Rate
{
    public class CreateRateRequest
    {
        public int IdUser { get; set; }
        public int IdMaterial { get; set; }
        public byte ValueRate { get; set; }
    }
}
