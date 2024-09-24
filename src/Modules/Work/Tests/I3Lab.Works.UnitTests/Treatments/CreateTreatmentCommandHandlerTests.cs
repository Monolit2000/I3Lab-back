
//using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
//using I3Lab.Treatments.Application.Treatments.CreateTreatment;
//using I3Lab.Treatments.Domain.Treatments;
//using FluentAssertions;
//using NSubstitute;
//using AutoFixture;
//using I3Lab.Treatments.Domain.Members;

//namespace I3Lab.Treatments.UnitTests.Treatments
//{
//    public class CreateTreatmentCommandHandlerTests
//    {
//        private static readonly CreateTreatmentCommand Command = new("TestTreatment");

//        private  readonly CreateTreatmentCommandHandler _handler;
//        private readonly ITretmentRepository _tretmentRepositoryMock;
//        private readonly IMemberRepository _memberRepository;

//        public CreateTreatmentCommandHandlerTests()
//        {
//            _tretmentRepositoryMock = Substitute.For<ITretmentRepository>();
//            _memberRepository = Substitute.For<IMemberRepository>();    
//            _handler = new CreateTreatmentCommandHandler(_tretmentRepositoryMock, _memberRepository);
//        }


//        [Fact]
//        public async Task Handle_Should_ReturnError_WhenNameIsEmpty()
//        {
//            //Arrange 

//            var fixture = new Fixture();

//            var command = fixture.Build<CreateTreatmentCommand>()
//                .With(command => command.TreatmentTitel, string.Empty)
//                .Create();

//            _tretmentRepositoryMock.IsNameUniqueAsync(command.TreatmentTitel)
//                .Returns(true);

//            //Act
//            var result = await _handler.Handle(command, default);

//            //Assert
//            result.Errors.First().Message.Should().Be("Treatments name is Empty");
//        }

//        [Fact]
//        public async Task Handle_Should_ReturnError_WhenNameIsNotUnique()
//        {
//            //Arrange 
//            _tretmentRepositoryMock.IsNameUniqueAsync(Arg.Is<string>(e => e == Command.TreatmentTitel))
//                .Returns(false);

//            //Act
//            var result = await _handler.Handle(Command, default);

//            //Assert
//            result.Errors.First().Message.Should().Be(TreatmentsErrors.NotUniqueName);        
//        }

//        [Fact]
//        public async Task Handle_Should_ReturnSuccess_WhenNameIsUnique()
//        {
//            var fixture = new Fixture();

//            var command = fixture.Create<CreateTreatmentCommand>();

//            //Arrange 
//            _tretmentRepositoryMock.IsNameUniqueAsync(Arg.Is<string>(e => e == command.TreatmentTitel))
//               .Returns(true);

//            //Act
//            var result = await _handler.Handle(command, default);

//            //Assert
//            result.IsSuccess.Should().Be(true);
//        }


//        [Fact]
//        public async Task Handle_Should_CallRepositorySaveChengesAsync_WhenNameIsUnique()
//        {

//            //Arrange 
//            var fixture = new Fixture();

//            var command = fixture.Create<CreateTreatmentCommand>();

//            _tretmentRepositoryMock.IsNameUniqueAsync(Arg.Is<string>(e => e == command.TreatmentTitel))
//               .Returns(true);

//            //Act
//            var result = await _handler.Handle(command, default);

//            //Assert
//            await _tretmentRepositoryMock.Received(1).SaveChangesAsync();   
//        }

//        [Fact]
//        public async Task Handle_Should_CallRepository_WhenNameIsUnique()
//        {
//            //Arrange 
//            var fixture = new Fixture();

//            var command = fixture.Create<CreateTreatmentCommand>();

//            _tretmentRepositoryMock.IsNameUniqueAsync(Arg.Is<string>(e => e == command.TreatmentTitel))
//               .Returns(true);

//            //Act
//            var result = await _handler.Handle(command, default);

//            //Assert
//            await _tretmentRepositoryMock.Received(1).AddAsync(Arg.Any<Treatment>());
//        }
//    }
//}
////Arrange 

////Act

////Assert