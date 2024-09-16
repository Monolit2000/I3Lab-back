namespace I3Lab.API.Modules.Works.Files
{
    public class UploadWorkFileRequest
    {
        public Guid WorkId { get; set; }
        public string FileName { get; set; }

        public UploadWorkFileRequest()
        {
                
        }
        public UploadWorkFileRequest(
            Guid workId,
            string fileName)
        {
            FileName = fileName;
            WorkId = workId;
        }
    }
}
