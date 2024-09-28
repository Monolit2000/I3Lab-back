using I3Lab.BuildingBlocks.Domain;


namespace I3Lab.Treatments.Domain.Treatments.Rules
{
    public class TreatmentMustNotBeCanceledRule : IBusinessRule
    {
        private readonly TreatmentStatus _status;

        public TreatmentMustNotBeCanceledRule(TreatmentStatus status)
        {
            _status = status;
        }

        public bool IsBroken() => _status.IsCanceled;

        public string Message => "Treatment is already canceled.";
    }

}
