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
    public class CommentRateServices : ICommentRateService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CommentRateServices(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<CommentRate>> GetAll()
        {
            return _repositoryWrapper.CommentRate.FindAll().ToListAsync();
        }

        public Task<CommentRate> GetById(int idComment, int idUser)
        {
            var chat = _repositoryWrapper.CommentRate
                .FindByCondition(x => x.IdComment == idComment && x.IdUser == idUser).First();
            return Task.FromResult(chat);
        }

        public Task Create(CommentRate model)
        {
            _repositoryWrapper.CommentRate.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(CommentRate model)
        {
            _repositoryWrapper.CommentRate.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int idComment, int idUser)
        {
            var chatUser = _repositoryWrapper.CommentRate
                .FindByCondition(x => x.IdComment == idComment && x.IdUser == idUser).First();

            _repositoryWrapper.CommentRate.Delete(chatUser);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
