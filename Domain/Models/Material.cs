using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Material
    {
        public Material()
        {
            MaterialFiles = new HashSet<MaterialFile>();
            MaterialsUserStatuses = new HashSet<MaterialsUserStatus>();
            Rates = new HashSet<Rate>();
            IdComments = new HashSet<Comment>();
            IdGenres = new HashSet<Genre>();
            IdGroups = new HashSet<GroupMaterial>();
        }

        public int IdMaterial { get; set; }
        public string NameMaterial { get; set; } = null!;
        public string DescriptionMaterial { get; set; } = null!;
        public int IdCategory { get; set; }
        public int IdAuthorStatus { get; set; }
        public int IdAuthor { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; } = DateTime.Now;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public int FileIcon { get; set; }

        public virtual User? CreatedByNavigation { get; set; } = null!;
        public virtual User? DeletedByNavigation { get; set; }
        public virtual File? FileIconNavigation { get; set; } = null!;
        public virtual Author? IdAuthorNavigation { get; set; } = null!;
        public virtual AuthorStatus? IdAuthorStatusNavigation { get; set; } = null!;
        public virtual Category? IdCategoryNavigation { get; set; } = null!;
        public virtual User? LastUpdateByNavigation { get; set; } = null!;
        public virtual ICollection<MaterialFile>? MaterialFiles { get; set; }
        public virtual ICollection<MaterialsUserStatus>? MaterialsUserStatuses { get; set; }
        public virtual ICollection<Rate>? Rates { get; set; }

        public virtual ICollection<Comment>? IdComments { get; set; }
        public virtual ICollection<Genre>? IdGenres { get; set; }
        public virtual ICollection<GroupMaterial>? IdGroups { get; set; }
    }
}