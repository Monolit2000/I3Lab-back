using System;
using FluentResults;
using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStageDate : ValueObject
    {
        public DateTime StageStarted { get; private set; }
        public DateTime StageFinished { get; private set; }

        private TreatmentStageDate(DateTime stageStarted)
        {
            StageStarted = stageStarted;
            StageFinished = default; 
        }

        public static TreatmentStageDate Start()
        {
            return new TreatmentStageDate(DateTime.UtcNow);
        }

        public Result End()
        {
            if (StageFinished != default)
            {
                return Result.Fail("The treatment stage has already been completed.");
            }

            var now = DateTime.UtcNow;
            if (now < StageStarted)
            {
                return Result.Fail("The treatment stage cannot be finished before it starts.");
            }

            StageFinished = now;
            return Result.Ok();
        }

        public bool IsFinished()
        {
            return StageFinished != default;
        }

        public static Result<TreatmentStageDate> Create(DateTime? stageStarted = null, DateTime? stageFinished = null)
        {
            var start = stageStarted ?? DateTime.UtcNow;

            if (stageFinished.HasValue && stageFinished < start)
            {
                return Result.Fail<TreatmentStageDate>("The treatment stage cannot finish before it starts.");
            }

            var stageDate = new TreatmentStageDate(start)
            {
                StageFinished = stageFinished ?? default
            };

            return Result.Ok(stageDate);
        }
    }
}
