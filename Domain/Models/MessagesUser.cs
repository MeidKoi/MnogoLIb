using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MessagesUser
    {
        public int IdMessage { get; set; }
        public int IdUser { get; set; }
        public int IdChat { get; set; }
        public DateTime DeliverDate { get; set; } = DateTime.Now;
        public int IdMessageStatus { get; set; }
        public string TextMessage { get; set; } = null!;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime LastUpdateTime { get; set; } = DateTime.Now;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual User? DeletedByNavigation { get; set; }
        public virtual Chat IdChatNavigation { get; set; } = null!;
        public virtual MessageStatus IdMessageStatusNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}