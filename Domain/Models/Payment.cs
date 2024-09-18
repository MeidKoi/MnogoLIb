using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Payment
    {
        public Payment()
        {
            PaymentUsers = new HashSet<PaymentUser>();
        }

        public int IdPayment { get; set; }
        public string CardNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public DateTime ExpressionDate { get; set; }

        public virtual ICollection<PaymentUser> PaymentUsers { get; set; }
    }
}
