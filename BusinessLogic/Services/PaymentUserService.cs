﻿using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class PaymentUserService : IPaymentUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PaymentUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PaymentUser>> GetAll()
        {
            return await _repositoryWrapper.PaymentUser.FindAll();
        }

        public async Task<PaymentUser> GetById(int idPayment, int idUser)
        {
            var model = await _repositoryWrapper.PaymentUser
                .FindByCondition(x => x.IdPayment == idPayment && x.IdUser == idUser);

            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }


            return model.First();
        }

        public async Task Create(PaymentUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _repositoryWrapper.PaymentUser.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(PaymentUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _repositoryWrapper.PaymentUser.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int idPayment, int idUser)
        {
            var model = await _repositoryWrapper.PaymentUser
                .FindByCondition(x => x.IdPayment == idPayment && x.IdUser == idUser);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            _repositoryWrapper.PaymentUser.Delete(model.First());
            _repositoryWrapper.Save();
        }
    }
}