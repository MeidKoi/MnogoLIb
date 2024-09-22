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
            var user = await _repositoryWrapper.MaterialFile
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdFile == idFile);
            return user.First();
        }

        public async Task Create(MaterialFile model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.IdFile < 1)
            {
                throw new ArgumentException(nameof(model.IdFile));
            }

            if (model.IdMaterial < 1)
            {
                throw new ArgumentException(nameof(model.IdMaterial));
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

            _repositoryWrapper.MaterialFile.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(MaterialFile model)
        {
            _repositoryWrapper.MaterialFile.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int idMaterial, int idFile)
        {
            var user = await _repositoryWrapper.MaterialFile
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdFile == idFile);

            _repositoryWrapper.MaterialFile.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}