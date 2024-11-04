using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.GetTreatmentStageChatByTreatmentId
{
    public class GetTreatmentStageChatByTreatmentIdQueryHandler(
        ITreatmentStageChatRepository treatmentStageChatRepository)  : IRequestHandler<GetTreatmentStageChatByTreatmentIdQuery, Result<List<TreatmentStageChatDto>>>
    {
        public async Task<Result<List<TreatmentStageChatDto>>> Handle(GetTreatmentStageChatByTreatmentIdQuery request, CancellationToken cancellationToken)
        {
            var chats = await treatmentStageChatRepository.GetAllByTreatmentIdAsync(new TreatmentId(request.TreatmentId));

            var chatDtos = chats.Select(x => new TreatmentStageChatDto(x.Id.Value)).ToList();

            return chatDtos;
        }
    }
}
