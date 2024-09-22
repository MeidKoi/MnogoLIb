namespace MnogoLibAPI.Contracts.MaterialFile
{
    public class CreateMaterialFileRequest
    {
        public int IdMaterial { get; set; }
        public int IdFile { get; set; }
        public int? Volume { get; set; }
        public int Chapter { get; set; }
        public byte? FrameNumber { get; set; }
    }
}