using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CommentRate
    {
        public int IdUser { get; set; }
        public int IdComment { get; set; }
        public int Value { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual Comment? IdCommentNavigation { get; set; } = null!;
        public virtual User? IdUserNavigation { get; set; } = null!;
    }
}