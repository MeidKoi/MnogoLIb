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
            var model = await _repositoryWrapper.Comment
                .FindByCondition(x => x.IdComment == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.TextComment))
            {
                throw new ArgumentException(nameof(model.TextComment));
            }

            if (model.CreatedTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedTime));
            }

            if (model.LastUpdateTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.LastUpdateTime));
            }

            if (model.DeletedTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.DeletedTime));
            }

            _repositoryWrapper.Comment.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var model = await _repositoryWrapper.Comment
                .FindByCondition(x => x.IdComment == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            _repositoryWrapper.Comment.Delete(model.First());
            _repositoryWrapper.Save();
        }
    }
}