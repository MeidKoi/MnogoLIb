using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class ChatService : IChatService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ChatService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Chat>> GetAll()
        {
            return await _repositoryWrapper.Chat.FindAll();
        }

        public async Task<Chat> GetById(int id)
        {
            var model = await _repositoryWrapper.Chat
                .FindByCondition(x => x.IdChat == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
        }

        public async Task Create(Chat model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameChat))
            {
                throw new ArgumentException(nameof(model.NameChat));
            }

            await _repositoryWrapper.Chat.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Chat model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameChat))
            {
                throw new ArgumentException(nameof(model.NameChat));
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

            await _repositoryWrapper.Chat.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var model = await _repositoryWrapper.Chat
                .FindByCondition(x => x.IdChat == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            await _repositoryWrapper.Chat.Delete(model.First());
            await _repositoryWrapper.Save();
        }
    }
}