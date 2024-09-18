using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class PaymentService : IPaymentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PaymentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _repositoryWrapper.Payment.FindAll();
        }

        public async Task<Payment> GetById(int id)
        {
            var user = await _repositoryWrapper.Payment
                .FindByCondition(x => x.IdPayment == id);
            return user.First();
        }

        public async Task Create(Payment model)
        {
            _repositoryWrapper.Payment.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Payment model)
        {
            _repositoryWrapper.Payment.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Payment
                .FindByCondition(x => x.IdPayment == id);

            _repositoryWrapper.Payment.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}