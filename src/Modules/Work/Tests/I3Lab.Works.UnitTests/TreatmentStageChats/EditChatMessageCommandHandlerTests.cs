using AutoFixture;
using FluentAssertions;
using FluentResults;
using I3Lab.Treatments.Application.TreatmentStageChats.EditChatMessage;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using NSubstitute;

namespace I3Lab.Treatments.UnitTests.TreatmentStageChats
{
    public class EditChatMessageCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly ITreatmentStageChatRepository _treatmentStageChatRepository;
        private readonly EditChatMessageCommandHandler _handler;

        public EditChatMessageCommandHandlerTests()
        {
            _fixture = new Fixture();
            _treatmentStageChatRepository = Substitute.For<ITreatmentStageChatRepository>();

            _handler = new EditChatMessageCommandHandler(_treatmentStageChatRepository);
        }

        [Fact]
        public async Task Handle_ShouldEditMessageSuccessfully_WhenChatExistsAndEditIsSuccessful()
        {
            // Arrange
            var editor = _fixture.Create<Member>();
            var member2 = _fixture.Create<Member>();

            var testData = CreateTreatmentTestData(new TreatmentTestDataOptions
            {
                ChatMembers = [editor, member2]
            });

            var chat = testData.TreatmentStageChat;

            chat.AddMessage(editor.Id, "TestText");

            var command = _fixture.Build<EditChatMessageCommand>()
                .With(x => x.EditorId, editor.Id.Value)
                .With(x => x.MessageId, chat.Messages.Last().Id.Value)
                .With(x => x.EditedMessage, "EditedText")
                .Create();

            _treatmentStageChatRepository.GetByTreatmentStageIdAsync(Arg.Is<TreatmentStageId>(id => id == new TreatmentStageId(command.TreatmentStageId)))
                .Returns(chat);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentStageChatRepository.Received(1).SaveChangesAsync(CancellationToken.None);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenChatNotFound()
        {
            // Arrange
            var command = _fixture.Create<EditChatMessageCommand>();

            _treatmentStageChatRepository.GetByTreatmentStageIdAsync(Arg.Any<TreatmentStageId>()).Returns((TreatmentStageChat)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Chat not found");
            await _treatmentStageChatRepository.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenMessageEditFails()
        {
            // Arrange
            var command = _fixture.Create<EditChatMessageCommand>();
            var chat = CreateTreatmentTestData(new TreatmentTestDataOptions()).TreatmentStageChat;

            _treatmentStageChatRepository.GetByTreatmentStageIdAsync(Arg.Is<TreatmentStageId>(id => id == new TreatmentStageId(command.TreatmentStageId)))
                .Returns(chat);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            //result.Errors.Should().ContainSingle(e => e.Message == "Failed to edit message");
            await _treatmentStageChatRepository.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
        }


        [Fact]
        public async Task Handle_ShouldReturnError_WhenMessageNotFound()
        {
            // Arrange
            var command = _fixture.Create<EditChatMessageCommand>();
            var chat = CreateTreatmentTestData(new TreatmentTestDataOptions()).TreatmentStageChat;

            _treatmentStageChatRepository.GetByTreatmentStageIdAsync(Arg.Is<TreatmentStageId>(id => id == new TreatmentStageId(command.TreatmentStageId)))
                .Returns(chat);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Message not found");
            await _treatmentStageChatRepository.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
        }

    }
}
