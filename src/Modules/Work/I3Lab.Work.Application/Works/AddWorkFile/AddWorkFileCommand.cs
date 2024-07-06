using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.AddWorkFile
{
    public class AddWorkFileCommand : IRequest<Result<WorkFileDto>>
    {
        public Guid WorkId { get; set; }   
        public Stream Stream { get; set; }



        [JsonConstructor]
        public AddWorkFileCommand()
        {
                
        }

    }
}
