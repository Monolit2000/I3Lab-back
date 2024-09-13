using I3Lab.Works.Infrastructure.Processing.InternalCommands;
using Microsoft.Extensions.Logging;
using Quartz.Impl;
using Quartz.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Infrastructure.Processing.Quartz
{
    internal static class QuartzStartup
    {
        private static IScheduler _scheduler;
         
        internal static void Initialize(long? internalProcessingPoolingInterval = null)
        {
            //logger.Information("Quartz starting...");


            var schedulerConfiguration = new NameValueCollection();
            schedulerConfiguration.Add("quartz.scheduler.instanceName", "Meetings");

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
            _scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            //LogProvider.SetCurrentLogProvider(new SerilogLogProvider(logger));

            _scheduler.Start().GetAwaiter().GetResult();

            #region ProcessOutboxJob

            //var processOutboxJob = JobBuilder.Create<ProcessOutboxJob>().Build();

            //ITrigger trigger;
            //if (internalProcessingPoolingInterval.HasValue)
            //{
            //    trigger =
            //        TriggerBuilder
            //            .Create()
            //            .StartNow()
            //            .WithSimpleSchedule(x =>
            //                x.WithInterval(TimeSpan.FromMilliseconds(internalProcessingPoolingInterval.Value))
            //                    .RepeatForever())
            //            .Build();
            //}
            //else
            //{
            //    trigger =
            //        TriggerBuilder
            //            .Create()
            //            .StartNow()
            //            .WithCronSchedule("0/2 * * ? * *")
            //            .Build();
            //}

            //_scheduler
            //    .ScheduleJob(processOutboxJob, trigger)
            //    .GetAwaiter().GetResult();

            #endregion

            #region ProcessInboxJob

            //var processInboxJob = JobBuilder.Create<ProcessInboxJob>().Build();

            //ITrigger processInboxTrigger;
            //if (internalProcessingPoolingInterval.HasValue)
            //{
            //    processInboxTrigger =
            //        TriggerBuilder
            //            .Create()
            //            .StartNow()
            //            .WithSimpleSchedule(x =>
            //                x.WithInterval(TimeSpan.FromMilliseconds(internalProcessingPoolingInterval.Value))
            //                    .RepeatForever())
            //            .Build();
            //}
            //else
            //{
            //    processInboxTrigger =
            //        TriggerBuilder
            //            .Create()
            //            .StartNow()
            //            .WithCronSchedule("0/2 * * ? * *")
            //            .Build();
            //}

            //_scheduler
            //    .ScheduleJob(processInboxJob, processInboxTrigger)
            //    .GetAwaiter().GetResult();

            #endregion


            #region ProcessInternalCommandsJob

            var processInternalCommandsJob = JobBuilder.Create<ProcessInternalCommandsJob>().Build();

            ITrigger triggerCommandsProcessing;
            if (internalProcessingPoolingInterval.HasValue)
            {
                triggerCommandsProcessing =
                    TriggerBuilder
                        .Create()
                        .StartNow()
                        .WithSimpleSchedule(x =>
                            x.WithInterval(TimeSpan.FromMilliseconds(internalProcessingPoolingInterval.Value))
                                .RepeatForever())
                        .Build();
            }
            else
            {
                triggerCommandsProcessing =
                    TriggerBuilder
                        .Create()
                        .StartNow()
                        .WithCronSchedule("0/2 * * ? * *")
                        .Build();
            }

            _scheduler.ScheduleJob(processInternalCommandsJob, triggerCommandsProcessing).GetAwaiter().GetResult();

            #endregion
            //logger.Information("Quartz started.");
        }

        internal static void StopQuartz()
        {
            _scheduler?.Shutdown();
        }
    }

}
