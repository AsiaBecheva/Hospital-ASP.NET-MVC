namespace Hospital.DatabaseModels
{
    public class FileBase
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }
    }
}
