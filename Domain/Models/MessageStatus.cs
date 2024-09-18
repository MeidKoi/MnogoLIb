using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MessageStatus
    {
        public MessageStatus()
        {
            MessagesUsers = new HashSet<MessagesUser>();
        }

        public int IdMessageStatus { get; set; }
        public string NameMessageStatus { get; set; } = null!;

        public virtual ICollection<MessagesUser> MessagesUsers { get; set; }
    }
}
