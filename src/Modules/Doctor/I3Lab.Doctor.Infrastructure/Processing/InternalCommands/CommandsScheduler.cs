using I3Lab.BuildingBlocks.Infrastructure.InternalCommands;
using I3Lab.BuildingBlocks.Infrastructure.Serialization;
using I3Lab.Doctors.Infrastructure.Persistence;
using Newtonsoft.Json;
using I3Lab.Doctors.Application.Contract.Commands;

namespace I3Lab.Doctors.Infrastructure.Processing.InternalCommands
{
    public class CommandsScheduler : ICommandsScheduler
    {
        private readonly DoctorContext _dbContext;

        public CommandsScheduler(DoctorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task EnqueueAsync(ICommand command)
        {
            var internalCommand = new InternalCommand
            {
                Id = command.Id,
                EnqueueDate = DateTime.UtcNow,
                Type = command.GetType().FullName,
                Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContractResolver()
                })
            };

            _dbContext.InternalCommands.Add(internalCommand);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EnqueueAsync<T>(ICommand<T> command)
        {
            var internalCommand = new InternalCommand
            {
                Id = command.Id,
                EnqueueDate = DateTime.UtcNow,
                Type = command.GetType().FullName,
                Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContractResolver()
                })
            };

            _dbContext.InternalCommands.Add(internalCommand);
            await _dbContext.SaveChangesAsync();
        }
    }
}
