﻿
namespace I3Lab.Treatments.Application.Treatments
{
    public class TreatmentDto
    {
        public Guid TreatmentId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime TreatmentDate { get; set; }
        public Guid CreatorId { get; set; }
        public Guid PatientId { get; set; }

        public string InviteToken { get; set; }
    }
}
