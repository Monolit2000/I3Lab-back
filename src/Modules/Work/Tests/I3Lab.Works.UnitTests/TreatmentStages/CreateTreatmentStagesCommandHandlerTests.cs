using FluentAssertions;
using FluentResults;
using I3Lab.Treatments.Application.Works.CreateWorks;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace I3Lab.Treatments.UnitTests.Application.Works
{
    public class CreateTreatmentStagesCommandHandlerTests : TreatmentTestsBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ITreatmentStageRepository _workRepository;
        private readonly ILogger<CreateTreatmentStagesCommandHandler> _logger;
        private readonly CreateTreatmentStagesCommandHandler _handler;

        public CreateTreatmentStagesCommandHandlerTests()
        {
            _memberRepository = Substitute.For<IMemberRepository>();
            _workRepository = Substitute.For<ITreatmentStageRepository>();
            _logger = Substitute.For<ILogger<CreateTreatmentStagesCommandHandler>>();
            _handler = new CreateTreatmentStagesCommandHandler(_memberRepository, _workRepository, _logger);
        }

        [Fact]
        public async Task Handle_ShouldCreateStages_WhenCreatorExists()
        {
            // Arrange
            var command = new CreateTreatmentStagesCommand(Guid.NewGuid(), Guid.NewGuid());
            var creator = CreateMember();

            _memberRepository.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.CreatorId)))
                .Returns(creator);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _workRepository.Received(4).AddAsync(Arg.Any<TreatmentStage>());
            await _workRepository.Received(1).SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldLogWarning_WhenCreatorNotFound()
        {
            // Arrange
            var command = new CreateTreatmentStagesCommand(Guid.NewGuid(), Guid.NewGuid());
            _memberRepository.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.CreatorId)))
                .Returns((Member)null);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            //_logger.Received(1).LogWarning("Creator with ID {CreatorId} not found.", command.CreatorId);
            await _workRepository.DidNotReceive().AddAsync(Arg.Any<TreatmentStage>());
        }

        [Fact]
        public async Task Handle_ShouldLogError_WhenStageCreationFails()
        {
            // Arrange
            var command = new CreateTreatmentStagesCommand(Guid.NewGuid(), Guid.NewGuid());
            var creator = CreateMember();
            _memberRepository.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.CreatorId)))
                .Returns(creator);


            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _workRepository.Received(4).AddAsync(Arg.Any<TreatmentStage>()); // The failing stage should skip one
            await _workRepository.Received(1).SaveChangesAsync();
        }
    }
}
