using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PaymentUserService : IPaymentUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PaymentUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<PaymentUser>> GetAll()
        {
            return _repositoryWrapper.PaymentUser.FindAll().ToListAsync();
        }

        public Task<PaymentUser> GetById(int idPayment, int idUser)
        {
            var chat = _repositoryWrapper.PaymentUser
                .FindByCondition(x => x.IdPayment == idPayment && x.IdUser == idUser).First();
            return Task.FromResult(chat);
        }

        public Task Create(PaymentUser model)
        {
            _repositoryWrapper.PaymentUser.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(PaymentUser model)
        {
            _repositoryWrapper.PaymentUser.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int idPayment, int idUser)
        {
            var chatUser = _repositoryWrapper.PaymentUser
                .FindByCondition(x => x.IdPayment == idPayment && x.IdUser == idUser).First();

            _repositoryWrapper.PaymentUser.Delete(chatUser);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
