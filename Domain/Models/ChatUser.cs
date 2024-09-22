using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ChatUser
    {
        public int IdUser { get; set; }
        public int IdChat { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual User? CreatedByNavigation { get; set; } = null!;
        public virtual User? DeletedByNavigation { get; set; }
        public virtual Chat? IdChatNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}