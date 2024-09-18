using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MaterialFile
    {
        public int IdMaterial { get; set; }
        public int IdFile { get; set; }
        public int? Volume { get; set; }
        public int Chapter { get; set; }
        public byte? FrameNumber { get; set; }

        public virtual File IdFileNavigation { get; set; } = null!;
        public virtual Material IdMaterialNavigation { get; set; } = null!;
    }
}
