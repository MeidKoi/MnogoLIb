using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAll();
        Task<Payment> GetById(int id);
        Task Create(Payment message);
        Task Update(Payment message);
        Task Delete(int id);
    }
}
