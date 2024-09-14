using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Author
    {
        public Author()
        {
            Materials = new HashSet<Material>();
        }

        public int IdAuthor { get; set; }
        public string NameAuthor { get; set; } = null!;

        public virtual ICollection<Material> Materials { get; set; }
    }
}
