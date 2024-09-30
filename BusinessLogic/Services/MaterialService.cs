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
            var model = await _repositoryWrapper.Material
                .FindByCondition(x => x.IdMaterial == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
        }

        public async Task Create(Material model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameMaterial))
            {
                throw new ArgumentException(nameof(model.NameMaterial));
            }

            if (string.IsNullOrEmpty(model.DescriptionMaterial))
            {
                throw new ArgumentException(nameof(model.DescriptionMaterial));
            }

            _repositoryWrapper.Material.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Material model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameMaterial))
            {
                throw new ArgumentException(nameof(model.NameMaterial));
            }

            if (string.IsNullOrEmpty(model.DescriptionMaterial))
            {
                throw new ArgumentException(nameof(model.DescriptionMaterial));
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

            _repositoryWrapper.Material.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var model = await _repositoryWrapper.Material
                .FindByCondition(x => x.IdMaterial == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            _repositoryWrapper.Material.Delete(model.First());
            _repositoryWrapper.Save();
        }
    }
}