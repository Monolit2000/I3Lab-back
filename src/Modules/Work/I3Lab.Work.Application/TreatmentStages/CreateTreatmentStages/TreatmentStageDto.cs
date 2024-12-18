﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Works.CreateWorks
{
    public class TreatmentStageDto
    {
        public Guid Id { get; set; }
        public Guid TreatmentId { get; set; }
        public string TreatmentName { get; set; }
        public string WorkStatus { get; set; }
        public DateTime WorkStartedDate { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? CustomerId { get; set; }
        public string WorkAvatarImageUrl { get; set; }

        //public List<TreatmentMemberDto> TreatmentAccebilityMembers { get; set; } = new List<TreatmentMemberDto>();
        //public List<TreatmentStageFileDto> TreatmentStageFiles { get; set; } = new List<TreatmentStageFileDto>();
    }
}
