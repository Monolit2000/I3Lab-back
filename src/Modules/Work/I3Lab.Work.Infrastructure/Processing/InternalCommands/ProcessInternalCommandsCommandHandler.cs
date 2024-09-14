using I3Lab.BuildingBlocks.Infrastructure.InternalCommands;
using I3Lab.Works.Application.Configuration.Commands;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Polly;

namespace I3Lab.Works.Infrastructure.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommandHandler(
        WorkContext dbContext) : ICommandHandler<ProcessInternalCommandsCommand>
    {
        public async Task Handle(ProcessInternalCommandsCommand command, CancellationToken cancellationToken)
        {
            var internalCommands = await dbContext.InternalCommands
                .Where(c => c.ProcessedDate == null)
                .OrderBy(c => c.ProcessedDate)
                .ToListAsync(cancellationToken);

            var policy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                });

            foreach (var internalCommand in internalCommands)
            {
                var result = await policy.ExecuteAndCaptureAsync(() => ProcessCommand(internalCommand));

                if (result.Outcome == OutcomeType.Failure)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;
                    internalCommand.Error = result.FinalException.ToString();
                    dbContext.InternalCommands.Update(internalCommand);
                }

                internalCommand.ProcessedDate = DateTime.UtcNow;

            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task ProcessCommand(InternalCommand internalCommand)
        {
            Type type = Assemblies.Application.GetType(internalCommand.Type);
            dynamic commandToProcess = JsonConvert.DeserializeObject(internalCommand.Data, type);

            await CommandsExecutor.Execute(commandToProcess);
        }
    }
}
