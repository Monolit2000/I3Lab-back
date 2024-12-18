﻿using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Domain.DoctorCreationProposals.Events
{
    public class DoctorCreationProposalConfirmedDomainEvent : DomainEventBase
    {
        public DoctorCreationProposalId DoctorCreationProposalId { get; set; }

        public DoctorCreationProposalConfirmedDomainEvent(DoctorCreationProposalId doctorCreationProposalId)
        {
            DoctorCreationProposalId = doctorCreationProposalId;
        }
    }
}
