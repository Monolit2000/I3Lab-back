﻿using I3Lab.Treatments.Application.Configuration.Commands;

namespace I3Lab.Treatments.Application.WorkChats.CreateWorkChat
{
    public class CreateTreatmentStageChatCommand : InternalCommandBase
    {
        public Guid WorkId { get; }
        public Guid TreatmentId { get; }

        public CreateTreatmentStageChatCommand(
            Guid workId, 
            Guid treatmentId = default)
        {
            WorkId = workId;
            TreatmentId = treatmentId;
        }
    }
}