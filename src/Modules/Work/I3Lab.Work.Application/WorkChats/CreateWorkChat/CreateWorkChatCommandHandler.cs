using I3Lab.Works.Domain.TreatmentInvites;
using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Domain.WorkChats;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.WorkChats.CreateWorkChat
{
    public class CreateWorkChatCommandHandler(
        IWorkRepository workRepository,
        IWorkChatRepository workChatRepository,
        ITretmentRepository tretmentRepository) : IRequestHandler<CreateWorkChatCommand>
    {
        public async Task Handle(CreateWorkChatCommand request, CancellationToken cancellationToken)
        {
            var work = await workRepository.GetByIdAsync(new WorkId(request.WorkId));

            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);

            var members = treatment.TreatmentMemberss.Select(m => m.Member).ToList();

            var workChat = work.CreateWorkChat(members);

            await workChatRepository.AddAsync(workChat);

            await workChatRepository.SaveChangesAsync();
        }
    }
}
