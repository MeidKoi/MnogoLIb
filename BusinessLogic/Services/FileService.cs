using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using File = Domain.Models.File;

namespace BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<File>> GetAll()
        {
            return await _repositoryWrapper.File.FindAll();
        }

        public async Task<File> GetById(int id)
        {
            var user = await _repositoryWrapper.File
                .FindByCondition(x => x.IdFile == id);
            return user.First();
        }

        public async Task Create(File model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameFile))
            {
                throw new ArgumentException(nameof(model.NameFile));
            }

            if (string.IsNullOrEmpty(model.PathFile))
            {
                throw new ArgumentException(nameof(model.PathFile));
            }

            _repositoryWrapper.File.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(File model)
        {
            _repositoryWrapper.File.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.File
                .FindByCondition(x => x.IdFile == id);

            _repositoryWrapper.File.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}