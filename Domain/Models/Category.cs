using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Materials = new HashSet<Material>();
        }

        public int IdCategory { get; set; }
        public string NameCategory { get; set; } = null!;

        public virtual ICollection<Material> Materials { get; set; }
    }
}
