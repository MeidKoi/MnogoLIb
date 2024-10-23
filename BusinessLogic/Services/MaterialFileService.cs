using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class MaterialFileService : IMaterialFileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MaterialFileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MaterialFile>> GetAll()
        {
            return await _repositoryWrapper.MaterialFile.FindAll();
        }

        public async Task<MaterialFile> GetById(int idMaterial, int idFile)
        {
            var model = await _repositoryWrapper.MaterialFile
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdFile == idFile);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
        }

        public async Task Create(MaterialFile model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.FrameNumber < 1)
            {
                throw new ArgumentException(nameof(model.FrameNumber));
            }

            if (model.Volume < 1)
            {
                throw new ArgumentException(nameof(model.Volume));
            }

            if (model.Chapter < 1)
            {
                throw new ArgumentException(nameof(model.Chapter));
            }

            await _repositoryWrapper.MaterialFile.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(MaterialFile model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.FrameNumber < 1)
            {
                throw new ArgumentException(nameof(model.FrameNumber));
            }

            if (model.Volume < 1)
            {
                throw new ArgumentException(nameof(model.Volume));
            }

            if (model.Chapter < 1)
            {
                throw new ArgumentException(nameof(model.Chapter));
            }

            await _repositoryWrapper.MaterialFile.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int idMaterial, int idFile)
        {
            var model = await _repositoryWrapper.MaterialFile
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdFile == idFile);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            await _repositoryWrapper.MaterialFile.Delete(model.First());
            await _repositoryWrapper.Save();
        }
    }
}