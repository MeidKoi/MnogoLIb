using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MaterialsUserStatusService : IMaterialsUserStatusService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MaterialsUserStatusService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<MaterialsUserStatus>> GetAll()
        {
            return _repositoryWrapper.MaterialsUserStatus.FindAll().ToListAsync();
        }

        public Task<MaterialsUserStatus> GetById(int idMaterial, int idUser, int idUserStatus)
        {
            var chat = _repositoryWrapper.MaterialsUserStatus
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdUser == idUser && x.IdUserStatus == idUserStatus).First();
            return Task.FromResult(chat);
        }

        public Task Create(MaterialsUserStatus model)
        {
            _repositoryWrapper.MaterialsUserStatus.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(MaterialsUserStatus model)
        {
            _repositoryWrapper.MaterialsUserStatus.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int idMaterial, int idUser, int idUserStatus)
        {
            var chatUser = _repositoryWrapper.MaterialsUserStatus
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdUser == idUser && x.IdUserStatus == idUserStatus).First();

            _repositoryWrapper.MaterialsUserStatus.Delete(chatUser);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
