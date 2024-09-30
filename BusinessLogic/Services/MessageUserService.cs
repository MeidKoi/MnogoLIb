using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class MessageUserService : IMessageUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MessageUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MessagesUser>> GetAll()
        {
            return await _repositoryWrapper.MessageUser.FindAll();
        }

        public async Task<MessagesUser> GetById(int id)
        {
            var model = await _repositoryWrapper.MessageUser
                .FindByCondition(x => x.IdMessage == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
        }

        public async Task Create(MessagesUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.TextMessage))
            {
                throw new ArgumentException(nameof(model.TextMessage));
            }

            _repositoryWrapper.MessageUser.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(MessagesUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.TextMessage))
            {
                throw new ArgumentException(nameof(model.TextMessage));
            }

            if (model.CreatedTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedTime));
            }

            if (model.LastUpdateTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.LastUpdateTime));
            }

            if (model.DeletedBy is not null && model.DeletedTime is null || model.DeletedTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.DeletedTime));
            }

            if (model.DeletedBy is null && model.DeletedTime is not null)
            {
                throw new ArgumentException(nameof(model.DeletedBy));
            }

            _repositoryWrapper.MessageUser.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var model = await _repositoryWrapper.MessageUser
                .FindByCondition(x => x.IdMessage == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            _repositoryWrapper.MessageUser.Delete(model.First());
            _repositoryWrapper.Save();
        }
    }
}