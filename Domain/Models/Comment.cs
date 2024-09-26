using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentRates = new HashSet<CommentRate>();
            IdMaterials = new HashSet<Material>();
        }

        public int IdComment { get; set; }
        public string TextComment { get; set; } = null!;
        public int IdUser { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime LastUpdateTime { get; set; } = DateTime.Now;
        public DateTime? DeletedTime { get; set; }

        public virtual User? IdUserNavigation { get; set; } = null!;
        public virtual ICollection<CommentRate>? CommentRates { get; set; }

        public virtual ICollection<Material>? IdMaterials { get; set; }
    }
}