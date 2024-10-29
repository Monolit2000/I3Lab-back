using AutoFixture;
using FluentAssertions;
using I3Lab.Treatments.Application.TreatmentStageChats.AddMessage;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using NSubstitute;

namespace I3Lab.Treatments.UnitTests.TreatmentStageChats
{
    public class AddMessageCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly ITreatmentStageChatRepository _treatmentStageChatRepository;
        private readonly AddMessageCommandHandler _handler;

        public AddMessageCommandHandlerTests()
        {
            _fixture = new Fixture();
            _treatmentStageChatRepository = Substitute.For<ITreatmentStageChatRepository>();
            _handler = new AddMessageCommandHandler(_treatmentStageChatRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentStageChatNotFound()
        {
            // Arrange
            var command = _fixture.Create<AddMessageCommand>();
            _treatmentStageChatRepository.GetByTreatmentStageIdAsync(Arg.Any<TreatmentStageId>())
                .Returns((TreatmentStageChat)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "TreatmentStageChat not found");
            await _treatmentStageChatRepository.DidNotReceive().SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldAddMessageSuccessfully_WhenTreatmentStageChatExists()
        {

            // Arrange
            var member1 = _fixture.Create<Member>();
            var member2 = _fixture.Create<Member>();

            var testData = CreateTreatmentTestData(new TreatmentTestDataOptions 
            {
                ChatMembers = [member1, member2] 
            });

            var command = _fixture.Build<AddMessageCommand>().With(c => c.SenderId, member1.Id.Value).Create();
            var treatmentStageChat = testData.TreatmentStageChat;

            _treatmentStageChatRepository.GetByTreatmentStageIdAsync(Arg.Is<TreatmentStageId>(id => id == new TreatmentStageId(command.TreatmentStageId)))
                .Returns(treatmentStageChat);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentStageChatRepository.Received(1).SaveChangesAsync();
        }
    }
}
