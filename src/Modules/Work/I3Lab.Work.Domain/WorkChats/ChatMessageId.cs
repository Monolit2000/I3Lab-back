using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkChats
{
    public class ChatMessageId : TypedIdValueBase
    {
        public ChatMessageId(Guid value) 
            : base(value)
        {
        }
    }
}
