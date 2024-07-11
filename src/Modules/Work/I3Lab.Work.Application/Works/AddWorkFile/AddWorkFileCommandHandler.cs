using FluentResults;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.AddWorkFile
{
    public class AddWorkFileCommandHandler : IRequestHandler<AddWorkFileCommand, Result<WorkFileDto>>
    {
        private IWorkRepository _workRepository;

        public AddWorkFileCommandHandler(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<Result<WorkFileDto>> Handle(AddWorkFileCommand request, CancellationToken cancellationToken)
        {
            var work = await _workRepository.GetByIdAsync(new WorkId(request.WorkId));

            if (work == null)
                return Result.Fail("Work not found");

            var newWork = await Work.CreateNewWork();
            throw new NotImplementedException();
        }
    }
}
