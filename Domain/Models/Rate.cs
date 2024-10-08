﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Rate
    {
        public int IdRate { get; set; }
        public int IdUser { get; set; }
        public int IdMaterial { get; set; }
        public byte ValueRate { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime LastUpdateTime { get; set; } = DateTime.Now;
        public DateTime? DeletedTime { get; set; }

        public virtual Material IdMaterialNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}