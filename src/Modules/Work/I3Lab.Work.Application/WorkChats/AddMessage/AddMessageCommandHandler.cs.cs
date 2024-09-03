using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.WorkChats;
using I3Lab.Works.Domain.Works;
using MediatR;

namespace I3Lab.Works.Application.WorkChats.AddMessage
{
    public class AddMessageCommandHendler(
        IWorkRepository workRepository,
        IMemberRepository memberRepository, 
        IWorkChatRepository workChatRepository) : IRequestHandler<AddMessageCommand, Result>
    {
        public async Task<Result> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var workChat = await workChatRepository.GetByWorkIdAsync(new WorkId(request.WorkId));

            if (workChat == null)
                return Result.Fail("WorkChat not found");

            workChat.AddMessage(new MemberId(request.MemberId), request.Message);

            return Result.Ok();
        }
    }
}
