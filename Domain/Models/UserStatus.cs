using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            MaterialsUserStatuses = new HashSet<MaterialsUserStatus>();
        }

        public int IdUserStatus { get; set; }
        public string NameUserStatus { get; set; } = null!;

        public virtual ICollection<MaterialsUserStatus> MaterialsUserStatuses { get; set; }
    }
}
