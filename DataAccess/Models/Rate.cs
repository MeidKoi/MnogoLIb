using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Rate
    {
        public int IdRate { get; set; }
        public int IdUser { get; set; }
        public int IdMaterial { get; set; }
        public byte ValueRate { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual Material IdMaterialNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
