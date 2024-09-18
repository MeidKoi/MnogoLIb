using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Genre
    {
        public Genre()
        {
            IdMaterials = new HashSet<Material>();
        }

        public int IdGenre { get; set; }
        public string NameGenre { get; set; } = null!;

        public virtual ICollection<Material> IdMaterials { get; set; }
    }
}
