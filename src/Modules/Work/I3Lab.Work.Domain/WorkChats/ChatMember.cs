using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkChats
{
    public class ChatMember : Entity
    {
        public WorkChatId WorkChatId { get; set; }

        [Key]
        public ChatMemberId Id { get; set; }  
        
        public MemberId MemberId { get; private set; }

        private ChatMember() { } // For EF Core

        private ChatMember(
            WorkChatId workChatId, 
            MemberId memberId)
        {
            Id = new ChatMemberId(Guid.NewGuid());
            MemberId = memberId;
            WorkChatId = workChatId;
        }

        public static ChatMember CreateNew(
            WorkChatId workChatId, 
            MemberId memberId)
        {
            return new ChatMember(
                workChatId, 
                memberId);
        }
    }
}
