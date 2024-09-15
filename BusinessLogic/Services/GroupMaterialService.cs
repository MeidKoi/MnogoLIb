using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class GroupMaterialService : IGroupMaterialService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupMaterialService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<GroupMaterial>> GetAll()
        {
            return _repositoryWrapper.GroupMaterial.FindAll().ToListAsync();
        }

        public Task<GroupMaterial> GetById(int id)
        {
            var material = _repositoryWrapper.GroupMaterial
                .FindByCondition(x => x.IdGroup == id).First();
            return Task.FromResult(material);
        }

        public Task Create(GroupMaterial model)
        {
            _repositoryWrapper.GroupMaterial.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(GroupMaterial model)
        {
            _repositoryWrapper.GroupMaterial.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var material = _repositoryWrapper.GroupMaterial
                .FindByCondition(x => x.IdGroup == id).First();

            _repositoryWrapper.GroupMaterial.Delete(material);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}