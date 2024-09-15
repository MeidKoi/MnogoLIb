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
    public class ChatUserService : IChatUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ChatUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<ChatUser>> GetAll()
        {
            return _repositoryWrapper.ChatUser.FindAll().ToListAsync();
        }

        public Task<ChatUser> GetById(int idChat, int idUser)
        {
            var chat = _repositoryWrapper.ChatUser
                .FindByCondition(x => x.IdChat == idChat && x.IdUser == idUser).First();
            return Task.FromResult(chat);
        }

        public Task Create(ChatUser model)
        {
            _repositoryWrapper.ChatUser.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ChatUser model)
        {
            _repositoryWrapper.ChatUser.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int idChat, int idUser)
        {
            var chatUser = _repositoryWrapper.ChatUser
                .FindByCondition(x => x.IdChat == idChat && x.IdUser == idUser).First();

            _repositoryWrapper.ChatUser.Delete(chatUser);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
