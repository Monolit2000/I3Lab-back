using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Works.AddTreatmentStageFile
{
    public class AddTreatmentStageFileCommand : IRequest<Result<TreatmentStageFileDto>>
    {
        public Guid WorkId { get; set; }   
        public Stream Stream { get; set; }



        [JsonConstructor]
        public AddTreatmentStageFileCommand()
        {
                
        }

    }
}
