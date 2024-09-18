using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class MaterialService : IMaterialService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MaterialService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Material>> GetAll()
        {
            return await _repositoryWrapper.Material.FindAll();
        }

        public async Task<Material> GetById(int id)
        {
            var user = await _repositoryWrapper.Material
                .FindByCondition(x => x.IdMaterial == id);
            return user.First();
        }

        public async Task Create(Material model)
        {
            _repositoryWrapper.Material.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Material model)
        {
            _repositoryWrapper.Material.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Material
                .FindByCondition(x => x.IdMaterial == id);

            _repositoryWrapper.Material.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}