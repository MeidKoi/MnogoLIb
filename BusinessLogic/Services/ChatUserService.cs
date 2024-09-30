using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class ChatUserService : IChatUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ChatUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ChatUser>> GetAll()
        {
            return await _repositoryWrapper.ChatUser.FindAll();
        }

        public async Task<ChatUser> GetById(int idChat, int idUser)
        {
            var model = await _repositoryWrapper.ChatUser
                .FindByCondition(x => x.IdChat == idChat && x.IdUser == idUser);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
        }

        public async Task Create(ChatUser model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _repositoryWrapper.ChatUser.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ChatUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _repositoryWrapper.ChatUser.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int idChat, int idUser)
        {
            var model = await _repositoryWrapper.ChatUser
                .FindByCondition(x => x.IdChat == idChat && x.IdUser == idUser);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            _repositoryWrapper.ChatUser.Delete(model.First());
            _repositoryWrapper.Save();
        }
    }
}