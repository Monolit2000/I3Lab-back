namespace I3Lab.API.Modules.Treatments.TreatmentFiles
{
    public class UploadWorkFileRequest
    {
        public Guid TreatmentId { get; set; }
        public string FileName { get; set; }

         public IFormFile formFile {  get; set; }


        public UploadWorkFileRequest()
        {
                
        }
        public UploadWorkFileRequest(
            Guid workId,
            string fileName)
        {
            FileName = fileName;
            TreatmentId = workId;
        }
    }
}
