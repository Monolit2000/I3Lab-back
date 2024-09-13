using I3Lab.BuildingBlocks.Infrastructure.InternalCommands;
using I3Lab.Works.Application.Configuration.Commands;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Polly;
using I3Lab.Works.Infrastructure;
using System.Reflection;
using MediatR;

namespace I3Lab.Works.Infrastructure.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommandHandler : ICommandHandler<ProcessInternalCommandsCommand>
    {
        private readonly WorkContext _dbContext;

        public ProcessInternalCommandsCommandHandler(WorkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(ProcessInternalCommandsCommand command, CancellationToken cancellationToken)
        {
            var internalCommands = await _dbContext.InternalCommands
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
                    _dbContext.InternalCommands.Update(internalCommand);
                }

                internalCommand.ProcessedDate = DateTime.UtcNow;

            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task ProcessCommand(InternalCommand internalCommand)
        {
            Type type = Assemblies.Application.GetType(internalCommand.Type);
            dynamic commandToProcess = JsonConvert.DeserializeObject(internalCommand.Data, type);

            await CommandsExecutor.Execute(commandToProcess);
        }
    }
}
