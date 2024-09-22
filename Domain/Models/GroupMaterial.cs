using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class GroupMaterial
    {
        public GroupMaterial()
        {
            IdMaterials = new HashSet<Material>();
        }

        public int IdGroup { get; set; }
        public string NameGroup { get; set; } = null!;
        public string DescriptionGroup { get; set; } = null!;

        public virtual ICollection<Material> IdMaterials { get; set; }
    }
}