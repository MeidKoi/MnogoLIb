using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CommentService : ICommentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CommentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Comment>> GetAll()
        {
            return _repositoryWrapper.Comment.FindAll().ToListAsync();
        }

        public Task<Comment> GetById(int id)
        {
            var comment = _repositoryWrapper.Comment
                .FindByCondition(x => x.IdComment == id).First();
            return Task.FromResult(comment);
        }

        public Task Create(Comment model)
        {
            _repositoryWrapper.Comment.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Comment model)
        {
            _repositoryWrapper.Comment.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var comment = _repositoryWrapper.Comment
                .FindByCondition(x => x.IdComment == id).First();

            _repositoryWrapper.Comment.Delete(comment);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
