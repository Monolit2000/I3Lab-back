﻿using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.CreateWorks
{
    public class CreateWorksCommand : IRequest<Result<WorkDto>>
    {
        public Guid TreatmentId {  get; set; }

        public Guid CreatorId { get; set; }

        public CreateWorksCommand(Guid treatmentId, Guid creatorId)
        {
            TreatmentId = treatmentId;
            CreatorId = creatorId;
        }
    }
}