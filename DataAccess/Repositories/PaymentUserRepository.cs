﻿using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PaymentUserRepository : RepositoryBase<PaymentUser>, IPaymentUserRepository
    {
        public PaymentUserRepository(MnogoLibContext repositoryContext)
                : base(repositoryContext)
        {
        }
    }
}
