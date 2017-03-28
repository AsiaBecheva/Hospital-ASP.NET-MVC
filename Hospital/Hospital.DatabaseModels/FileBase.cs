namespace Hospital.DatabaseModels
{
    public abstract class FileBase
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string Path { get; set; }
    }
}
