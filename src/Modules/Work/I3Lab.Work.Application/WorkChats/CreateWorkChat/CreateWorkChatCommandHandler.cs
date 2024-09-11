using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Domain.WorkChats;
using I3Lab.Works.Domain.Works;
using MediatR;

namespace I3Lab.Works.Application.WorkChats.CreateWorkChat
{
    public class CreateWorkChatCommandHandler(
        IWorkRepository workRepository,
        IWorkChatRepository workChatRepository,
        ITretmentRepository tretmentRepository) : IRequestHandler<CreateWorkChatCommand>
    {
        public async Task Handle(CreateWorkChatCommand request, CancellationToken cancellationToken)
        {
            //var work = await workRepository.GetByIdAsync(new WorkId(request.WorkId));

            //if (work == null)
            //    return;

            // var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);

            //var members = treatment.TreatmentMemberss.Select(m => m.Member).ToList();

            var workChat = WorkChat.CreateBaseOnWork(new WorkId(request.WorkId), new List<Member>());

            await workChatRepository.AddAsync(workChat);

            await workChatRepository.SaveChangesAsync();
        }
    }
}
