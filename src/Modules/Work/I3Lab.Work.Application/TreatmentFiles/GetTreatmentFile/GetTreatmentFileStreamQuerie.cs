using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetTreatmentFile
{
    public class GetTreatmentFileStreamQuerie : IRequest<Result<TreatmentFileDto>>
    {
        public Guid BlobFileId { get; set; }


        public GetTreatmentFileStreamQuerie()
        {
                
        }

        public GetTreatmentFileStreamQuerie(Guid blobFileId)
        {
            BlobFileId = blobFileId;
        }

    }
}
