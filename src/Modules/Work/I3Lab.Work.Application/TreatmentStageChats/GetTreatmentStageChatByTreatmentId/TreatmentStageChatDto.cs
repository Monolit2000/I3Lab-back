using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.GetTreatmentStageChatByTreatmentId
{
    public class TreatmentStageChatDto
    {
        public Guid TreatmentStageChatId { get; set; }

        public TreatmentStageChatDto(Guid treatmentStageChatId)
        {
            TreatmentStageChatId = treatmentStageChatId;
        }
    }
}
