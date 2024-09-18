using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class AuthorStatus
    {
        public AuthorStatus()
        {
            Materials = new HashSet<Material>();
        }

        public int IdAuthorStatus { get; set; }
        public string NameAuthorStatus { get; set; } = null!;

        public virtual ICollection<Material> Materials { get; set; }
    }
}
