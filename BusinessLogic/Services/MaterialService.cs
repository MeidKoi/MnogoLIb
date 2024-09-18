using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class MaterialService : IMaterialService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MaterialService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Material>> GetAll()
        {
            return _repositoryWrapper.Material.FindAll().ToListAsync();
        }

        public Task<Material> GetById(int id)
        {
            var material = _repositoryWrapper.Material
                .FindByCondition(x => x.IdMaterial == id).First();
            return Task.FromResult(material);
        }

        public Task Create(Material model)
        {
            _repositoryWrapper.Material.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Material model)
        {
            _repositoryWrapper.Material.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var material = _repositoryWrapper.Material
                .FindByCondition(x => x.IdMaterial == id).First();

            _repositoryWrapper.Material.Delete(material);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}