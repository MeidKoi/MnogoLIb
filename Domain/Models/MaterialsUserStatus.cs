using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MaterialsUserStatus
    {
        public int IdMaterial { get; set; }
        public int IdUser { get; set; }
        public int IdUserStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual Material IdMaterialNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual UserStatus IdUserStatusNavigation { get; set; } = null!;
    }
}
