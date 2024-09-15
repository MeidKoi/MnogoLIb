using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPaymentUserService
    {
        Task<List<PaymentUser>> GetAll();
        Task<PaymentUser> GetById(int idPayment, int idUser);
        Task Create(PaymentUser model);
        Task Update(PaymentUser model);
        Task Delete(int idPayment, int idUser);
    }
}
