using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Domain
{
    public interface IBusinessRule
    {
      public bool IsBroken();

      public string Message { get; }
    }   
}
