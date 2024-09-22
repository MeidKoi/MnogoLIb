using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class CommentService : ICommentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CommentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _repositoryWrapper.Comment.FindAll();
        }

        public async Task<Comment> GetById(int id)
        {
            var user = await _repositoryWrapper.Comment
                .FindByCondition(x => x.IdComment == id);
            return user.First();
        }

        public async Task Create(Comment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.TextComment))
            {
                throw new ArgumentException(nameof(model.TextComment));
            }

            if (model.IdUser < 1)
            {
                throw new ArgumentException(nameof(model.IdUser));
            }

            _repositoryWrapper.Comment.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Comment model)
        {
            _repositoryWrapper.Comment.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Comment
                .FindByCondition(x => x.IdComment == id);

            _repositoryWrapper.Comment.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}