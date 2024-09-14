using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class PaymentUser
    {
        public int IdPayment { get; set; }
        public int IdUser { get; set; }
        public bool IsActive { get; set; }

        public virtual Payment IdPaymentNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
