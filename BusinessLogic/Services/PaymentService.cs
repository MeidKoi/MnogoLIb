using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class PaymentService : IPaymentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PaymentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Payment>> GetAll()
        {
            return _repositoryWrapper.Payment.FindAll().ToListAsync();
        }

        public Task<Payment> GetById(int id)
        {
            var material = _repositoryWrapper.Payment
                .FindByCondition(x => x.IdPayment == id).First();
            return Task.FromResult(material);
        }

        public Task Create(Payment model)
        {
            _repositoryWrapper.Payment.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Payment model)
        {
            _repositoryWrapper.Payment.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var material = _repositoryWrapper.Payment
                .FindByCondition(x => x.IdPayment == id).First();

            _repositoryWrapper.Payment.Delete(material);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}