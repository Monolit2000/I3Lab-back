

namespace I3Lab.BuildingBlocks.Domain
{
    public interface IBusinessRule
    {
      public bool IsBroken();

      public string Message { get; }
    }   
}
