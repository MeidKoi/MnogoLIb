﻿using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class CommentRateService : ICommentRateService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CommentRateService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<CommentRate>> GetAll()
        {
            return await _repositoryWrapper.CommentRate.FindAll();
        }

        public async Task<CommentRate> GetById(int idComment, int idUser)
        {
            var model = await _repositoryWrapper.CommentRate
                .FindByCondition(x => x.IdComment == idComment && x.IdUser == idUser);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
        }

        public async Task Create(CommentRate model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.Value > 1 || model.Value < -1 || model.Value == 0)
            {
                throw new ArgumentException(nameof(model.Value));
            }

            _repositoryWrapper.CommentRate.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(CommentRate model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.Value > 1 || model.Value < -1 || model.Value == 0)
            {
                throw new ArgumentException(nameof(model.Value));
            }

            _repositoryWrapper.CommentRate.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int idComment, int idUser)
        {
            var model = await _repositoryWrapper.CommentRate
                .FindByCondition(x => x.IdComment == idComment && x.IdUser == idUser);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            _repositoryWrapper.CommentRate.Delete(model.First());
            _repositoryWrapper.Save();
        }
    }
}