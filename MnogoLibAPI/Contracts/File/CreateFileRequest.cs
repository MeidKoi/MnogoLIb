namespace MnogoLibAPI.Contracts.File
{
    public class CreateFileRequest
    {
        public string NameFile { get; set; } = null!;
        public string PathFile { get; set; } = null!;
        public int CreatedBy { get; set; }
    }
}