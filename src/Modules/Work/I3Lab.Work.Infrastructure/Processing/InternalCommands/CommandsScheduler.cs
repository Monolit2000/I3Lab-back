using I3Lab.BuildingBlocks.Infrastructure.InternalCommands;
using I3Lab.BuildingBlocks.Infrastructure.Serialization;
using I3Lab.Works.Application.Configuration.Commands;
using I3Lab.Works.Application.Contract;
using I3Lab.Works.Infrastructure.Persistence;
using Newtonsoft.Json;

namespace I3Lab.Works.Infrastructure.Processing.InternalCommands
{
    public class CommandsScheduler : ICommandsScheduler
    {
        private readonly WorkContext _dbContext;

        public CommandsScheduler(WorkContext dbContext)
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
