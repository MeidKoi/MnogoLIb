using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class File
    {
        public File()
        {
            MaterialFiles = new HashSet<MaterialFile>();
            Materials = new HashSet<Material>();
        }

        public int IdFile { get; set; }
        public string NameFile { get; set; } = null!;
        public string PathFile { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual User? DeletedByNavigation { get; set; }
        public virtual User LastUpdateByNavigation { get; set; } = null!;
        public virtual ICollection<MaterialFile> MaterialFiles { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
}
