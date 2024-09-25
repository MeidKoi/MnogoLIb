using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Chat
    {
        public Chat()
        {
            ChatUsers = new HashSet<ChatUser>();
            MessagesUsers = new HashSet<MessagesUser>();
        }

        public int IdChat { get; set; } 
        public int IdOwner { get; set; }
        public string NameChat { get; set; } = null!;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; } = DateTime.Now;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual User? DeletedByNavigation { get; set; }
        public virtual User IdOwnerNavigation { get; set; } = null!;
        public virtual User LastUpdateByNavigation { get; set; } = null!;
        public virtual ICollection<ChatUser> ChatUsers { get; set; }
        public virtual ICollection<MessagesUser> MessagesUsers { get; set; }
    }
}