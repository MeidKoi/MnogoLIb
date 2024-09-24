using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class GroupMaterialService : IGroupMaterialService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupMaterialService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<GroupMaterial>> GetAll()
        {
            return await _repositoryWrapper.GroupMaterial.FindAll();
        }

        public async Task<GroupMaterial> GetById(int id)
        {
            var user = await _repositoryWrapper.GroupMaterial
                .FindByCondition(x => x.IdGroup == id);
            return user.First();
        }

        public async Task Create(GroupMaterial model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameGroup))
            {
                throw new ArgumentException(nameof(model.NameGroup));
            }

            if (string.IsNullOrEmpty(model.DescriptionGroup))
            {
                throw new ArgumentException(nameof(model.DescriptionGroup));
            }

            _repositoryWrapper.GroupMaterial.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(GroupMaterial model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameGroup))
            {
                throw new ArgumentException(nameof(model.NameGroup));
            }

            if (string.IsNullOrEmpty(model.DescriptionGroup))
            {
                throw new ArgumentException(nameof(model.DescriptionGroup));
            }

            _repositoryWrapper.GroupMaterial.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.GroupMaterial
                .FindByCondition(x => x.IdGroup == id);

            _repositoryWrapper.GroupMaterial.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}