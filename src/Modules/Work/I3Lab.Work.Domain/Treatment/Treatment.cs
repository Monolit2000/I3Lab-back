using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Treatment
{
    public class Treatment : Entity, IAggregateRoot
    {
        public MemberId CreatorId { get; private set; }  

        public List<TreatmentStage> TreatmentStage = [];

        public TreatmentId Id { get; private set; }

        public DateTime CreateDate { get; private set; }

        private Treatment() { } // For Ef Core

        private Treatment(MemberId creatorId)
        {
            Id = new TreatmentId(Guid.NewGuid());
            CreatorId = creatorId;
            CreateDate = DateTime.UtcNow;
        }

        internal static Treatment CreateNew(MemberId creatorId)
        {
            return new Treatment(creatorId); 
        }

        internal static Treatment AddWork(MemberId creatorId, WorkId workId)
        {
            return new Treatment(creatorId);
        }
    }
}
