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
            var model = await _repositoryWrapper.GroupMaterial
                .FindByCondition(x => x.IdGroup == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
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
            var model = await _repositoryWrapper.GroupMaterial
                .FindByCondition(x => x.IdGroup == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            _repositoryWrapper.GroupMaterial.Delete(model.First());
            _repositoryWrapper.Save();
        }
    }
}