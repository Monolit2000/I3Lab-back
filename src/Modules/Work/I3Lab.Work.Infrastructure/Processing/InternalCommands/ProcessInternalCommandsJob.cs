﻿using Quartz;

namespace I3Lab.Treatments.Infrastructure.Processing.InternalCommands
{
    [DisallowConcurrentExecution]
    public class ProcessInternalCommandsJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await CommandsExecutor.Execute(new ProcessInternalCommandsCommand());
        }
    }

    public class ProcessInternalCommandsHangFireJob
    {
        public async Task Execute()
        {
            await CommandsExecutor.Execute(new ProcessInternalCommandsCommand());
        }
    }
}
