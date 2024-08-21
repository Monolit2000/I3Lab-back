
using I3Lab.Works.Application.Treatments.ApplicationErrors;
using I3Lab.Works.Application.Treatments.CreateTreatment;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.Works;
using FluentAssertions;
using NSubstitute;

namespace I3Lab.Works.UnitTests.Treatments
{
    public class CreateTreatmentCommandHandlerTests
    {
        private static readonly CreateTreatmentCommand Command = new("TestTreatment");

        private  readonly CreateTreatmentCommandHandler _handler;
        private readonly ITretmentRepository _tretmentRepositoryMock;

        public CreateTreatmentCommandHandlerTests()
        {
            _tretmentRepositoryMock = Substitute.For<ITretmentRepository>();
            _handler = new CreateTreatmentCommandHandler(_tretmentRepositoryMock);
        }


        [Fact]
        public async Task Handle_Should_ReturnError_WhenNameIsEmpty()
        {
            //Arrange 
            var command = new CreateTreatmentCommand(string.Empty);

            _tretmentRepositoryMock.IsNameUniqueAsync(command.TreatmentName)
                .Returns(true);

            //Act
            var result = await _handler.Handle(command, default);

            //Assert
            result.Errors.First().Message.Should().Be("Treatment name is Empty");
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenNameIsNotUnique()
        {
            //Arrange 
            _tretmentRepositoryMock.IsNameUniqueAsync(Arg.Is<string>(e => e == Command.TreatmentName))
                .Returns(false);

            //Act
            var result = await _handler.Handle(Command, default);

            //Assert
            result.Errors.First().Message.Should().Be(TreatmentsErrors.NotUniqueName);        
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccess_WhenNameIsUnique()
        {
            //Arrange 
            _tretmentRepositoryMock.IsNameUniqueAsync(Arg.Is<string>(e => e == Command.TreatmentName))
               .Returns(true);

            //Act
            var result = await _handler.Handle(Command, default);

            //Assert
            result.IsSuccess.Should().Be(true);
        }


        [Fact]
        public async Task Handle_Should_CallRepositorySaveChengesAsync_WhenNameIsUnique()
        {
            //Arrange 
            _tretmentRepositoryMock.IsNameUniqueAsync(Arg.Is<string>(e => e == Command.TreatmentName))
               .Returns(true);

            //Act
            var result = await _handler.Handle(Command, default);

            //Assert
            await _tretmentRepositoryMock.Received(1).SaveChangesAsync();   
        }

        [Fact]
        public async Task Handle_Should_CallRepository_WhenNameIsUnique()
        {
            //Arrange 
            _tretmentRepositoryMock.IsNameUniqueAsync(Arg.Is<string>(e => e == Command.TreatmentName))
               .Returns(true);

            //Act
            var result = await _handler.Handle(Command, default);

            //Assert
            await _tretmentRepositoryMock.Received(1).AddAsync(Arg.Any<Treatment>());
        }
    }
}
//Arrange 

//Act

//Assert