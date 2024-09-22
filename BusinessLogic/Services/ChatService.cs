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
            var user = await _repositoryWrapper.Chat
                .FindByCondition(x => x.IdChat == id);
            return user.First();
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

            _repositoryWrapper.Chat.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Chat model)
        {
            _repositoryWrapper.Chat.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Chat
                .FindByCondition(x => x.IdChat == id);

            _repositoryWrapper.Chat.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}