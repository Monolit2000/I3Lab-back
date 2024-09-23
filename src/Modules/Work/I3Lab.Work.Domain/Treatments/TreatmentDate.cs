using FluentResults;

namespace I3Lab.Treatments.Domain.Treatments
{
    public class TreatmentDate
    {
        public DateTime TreatmentStarted { get; private set; }
        public DateTime TreatmentFinished { get; private set; }

        private TreatmentDate(DateTime treatmentStarted)
        {
            TreatmentStarted = treatmentStarted;
            TreatmentFinished = default; 
        }

        public static TreatmentDate Start() 
            => new TreatmentDate(DateTime.UtcNow);

        public Result End()
        {
            if (TreatmentFinished != default)
                return Result.Fail("Treatment has already been completed.");

            var now = DateTime.UtcNow;

            if (now < TreatmentStarted)
                return Result.Fail("Treatment cannot be completed before it begins.");

            TreatmentFinished = now;
            return Result.Ok();
        }

        public bool IsFinished()
            => TreatmentFinished != default;

        public static Result<TreatmentDate> Create(DateTime? treatmentStarted = null, DateTime? treatmentFinished = null)
        {
            var start = treatmentStarted ?? DateTime.UtcNow;

            if (treatmentFinished.HasValue && treatmentFinished < start)
                return Result.Fail<TreatmentDate>("The end date of treatment cannot be earlier than the start date.");

            var treatmentDate = new TreatmentDate(start)
            {
                TreatmentFinished = treatmentFinished ?? default
            };

            return Result.Ok(treatmentDate);
        }
    }
}




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace I3Lab.Treatments.Domain.Treatments
//{
//    public class TreatmentDate
//    {
//        public DateTime TreatmentStarted { get; set; }

//        public DateTime TreatmentFinished { get; set; }

//        private TreatmentDate(
//            DateTime treatmentStarted)
//        {
//            TreatmentStarted = treatmentStarted;
//            TreatmentFinished = default;
//        }

//        public static TreatmentDate Start()
//        {
//            return new TreatmentDate(DateTime.UtcNow);
//        }

//        public void End()
//        {
//            TreatmentFinished = DateTime.UtcNow;
//        }
//    }
//}
