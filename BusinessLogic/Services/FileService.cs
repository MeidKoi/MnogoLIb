using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = DataAccess.Models.File;

namespace BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<File>> GetAll()
        {
            return _repositoryWrapper.File.FindAll().ToListAsync();
        }

        public Task<File> GetById(int id)
        {
            var file = _repositoryWrapper.File
                .FindByCondition(x => x.IdFile == id).First();
            return Task.FromResult(file);
        }

        public Task Create(File model)
        {
            _repositoryWrapper.File.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(File model)
        {
            _repositoryWrapper.File.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var file = _repositoryWrapper.File
                .FindByCondition(x => x.IdFile == id).First();

            _repositoryWrapper.File.Delete(file);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
