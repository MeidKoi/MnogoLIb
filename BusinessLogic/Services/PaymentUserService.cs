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

            await _repositoryWrapper.PaymentUser.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(PaymentUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _repositoryWrapper.PaymentUser.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int idPayment, int idUser)
        {
            var model = await _repositoryWrapper.PaymentUser
                .FindByCondition(x => x.IdPayment == idPayment && x.IdUser == idUser);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            await _repositoryWrapper.PaymentUser.Delete(model.First());
            await _repositoryWrapper.Save();
        }
    }
}