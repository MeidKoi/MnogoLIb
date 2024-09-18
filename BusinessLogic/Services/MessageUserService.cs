using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class MessageUserService : IMessageUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MessageUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<MessagesUser>> GetAll()
        {
            return _repositoryWrapper.MessageUser.FindAll().ToListAsync();
        }

        public Task<MessagesUser> GetById(int id)
        {
            var material = _repositoryWrapper.MessageUser
                .FindByCondition(x => x.IdMessage == id).First();
            return Task.FromResult(material);
        }

        public Task Create(MessagesUser model)
        {
            _repositoryWrapper.MessageUser.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(MessagesUser model)
        {
            _repositoryWrapper.MessageUser.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var material = _repositoryWrapper.MessageUser
                .FindByCondition(x => x.IdMessage == id).First();

            _repositoryWrapper.MessageUser.Delete(material);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}