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
            var user = await _repositoryWrapper.MessageUser
                .FindByCondition(x => x.IdMessage == id);
            return user.First();
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
            var user = await _repositoryWrapper.MessageUser
                .FindByCondition(x => x.IdMessage == id);

            _repositoryWrapper.MessageUser.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}