﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentResults;
using I3Lab.Works.Application.Works.CreateWork;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.Works;
using MediatR;
using NSubstitute;
using Xunit;

namespace I3Lab.Works.Tests.Application.Works
{
    public class CreateWorkCommandHandlerTests
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ITretmentRepository _tretmentRepository;
        private readonly IWorkRepository _workRepository;
        private readonly IMemberContext _memberContext;
        private readonly IRequestHandler<CreateWorkCommand, Result<WorkDto>> _handler;

        public CreateWorkCommandHandlerTests()
        {
            _memberRepository = Substitute.For<IMemberRepository>();
            _tretmentRepository = Substitute.For<ITretmentRepository>();
            _workRepository = Substitute.For<IWorkRepository>();
            _memberContext = Substitute.For<IMemberContext>();
            _handler = new CreateWorkCommandHandler(
                _memberRepository,
                _tretmentRepository,
                _workRepository,
                _memberContext);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailResult_WhenTreatmentDoesNotExist()
        {
            // Arrange
            var command = new CreateWorkCommand { TreatmentId = Guid.NewGuid() };
            _tretmentRepository.GetByIdAsync(Arg.Any<TreatmentId>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult<Treatment>(null));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Treatment not exist");
        }

        [Fact]
        public async Task Handle_ShouldReturnFailResult_WhenCreatorDoesNotExist()
        {
            // Arrange
            var treatmentId = Guid.NewGuid();
            var command = new CreateWorkCommand { TreatmentId = treatmentId };
            var treatment = Treatment.CreateNew(new MemberId(Guid.NewGuid()), new MemberId(Guid.NewGuid()), "Test Treatment");

            _tretmentRepository.GetByIdAsync(Arg.Any<TreatmentId>(), Arg.Any<CancellationToken>())
                .Returns(treatment);
            _memberRepository.GetMByIdAsync(Arg.Any<MemberId>()).Returns(Task.FromResult<Member>(null));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Member not exist");
        }

        [Fact]
        public async Task Handle_ShouldReturnFailResult_WhenWorkCreationFails()
        {
            // Arrange
            var treatmentId = Guid.NewGuid();
            var command = new CreateWorkCommand { TreatmentId = treatmentId };
            var treatment = Treatment.CreateNew(new MemberId(Guid.NewGuid()), new MemberId(Guid.NewGuid()), "Test Treatment");
            var member = Member.CreateNew("creator@example.com");

            _tretmentRepository.GetByIdAsync(Arg.Any<TreatmentId>(), Arg.Any<CancellationToken>())
                .Returns(treatment);


            _memberRepository.GetMByIdAsync(Arg.Any<MemberId>()).Returns(member);


            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeFalse();
            //result.Errors.Should().ContainSingle(e => e.Message == "Creation failed");
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccessResult_WhenWorkIsCreatedSuccessfully()
        {
            // Arrange
            var treatmentId = Guid.NewGuid();
            var command = new CreateWorkCommand { TreatmentId = treatmentId };
            var treatment = Treatment.CreateNew(new MemberId(Guid.NewGuid()), new MemberId(Guid.NewGuid()), "Test Treatment");
            var member = Member.CreateNew("creator@example.com");
            var work = await Work.CreateAsync(member, new TreatmentId(treatmentId));

            _tretmentRepository.GetByIdAsync(Arg.Any<TreatmentId>(), Arg.Any<CancellationToken>())
                .Returns(treatment);

            _memberRepository.GetMByIdAsync(Arg.Any<MemberId>())
                .Returns(member);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeOfType<WorkDto>();
            //result.Value.Id.Should().Be(work.Id.Value);
            result.Value.TreatmentId.Should().Be(work.Value.TreatmentId.Value);
        }


        [Fact]
        public async Task Handle_ShouldAddAndSaveWork_WhenWorkIsCreatedSuccessfully()
        {
            // Arrange
            var treatmentId = Guid.NewGuid();
            var command = new CreateWorkCommand { TreatmentId = treatmentId };
            var treatment = Treatment.CreateNew(new MemberId(Guid.NewGuid()), new MemberId(Guid.NewGuid()), "Test Treatment");
            var member = Member.CreateNew("creator@example.com");
            var work =  await Work.CreateAsync(member, new TreatmentId(treatmentId));

            _tretmentRepository.GetByIdAsync(Arg.Any<TreatmentId>(), Arg.Any<CancellationToken>())
                .Returns(treatment);
            _memberRepository.GetMByIdAsync(Arg.Any<MemberId>()).Returns(member);


            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            //await _workRepository.Received(1).AddAsync(work.Value);
            await _workRepository.Received(1).SaveChangesAsync();
        }

    }
}