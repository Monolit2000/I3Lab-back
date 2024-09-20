using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.WorkChats.GetAllChatMessageByWorkId
{
    public class ChatMessageDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public string MessageText { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime? EditDate { get; set; }
        public bool IsEdited { get; set; }
        public Guid? RepliedToMessageId { get; set; }
        public bool IsResponseToFile { get; set; }
    }

}
