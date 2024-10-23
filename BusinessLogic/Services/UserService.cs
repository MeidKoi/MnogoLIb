using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using System;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<User> GetById(int id)
        {
            var model = await _repositoryWrapper.User
                .FindByCondition(x => x.IdUser == id);

            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
        }

        public async Task Create(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.EmailUser))
            {
                throw new ArgumentException(nameof(model.EmailUser));
            }

            if (string.IsNullOrEmpty(model.PasswordUser))
            {
                throw new ArgumentException(nameof(model.PasswordUser));
            }

            if (string.IsNullOrEmpty(model.NicknameUser))
            {
                throw new ArgumentException(nameof(model.NicknameUser));
            }

            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.EmailUser))
            {
                throw new ArgumentException(nameof(model.EmailUser));
            }

            if (string.IsNullOrEmpty(model.PasswordUser))
            {
                throw new ArgumentException(nameof(model.PasswordUser));
            }

            if (string.IsNullOrEmpty(model.NicknameUser))
            {
                throw new ArgumentException(nameof(model.NicknameUser));
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


            await _repositoryWrapper.User.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var model = await _repositoryWrapper.User
                .FindByCondition(x => x.IdUser == id);

            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            await _repositoryWrapper.User.Delete(model.First());
            await _repositoryWrapper.Save();
        }
    }
}