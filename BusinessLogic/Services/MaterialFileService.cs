using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MaterialFileService : IMaterialFileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MaterialFileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<MaterialFile>> GetAll()
        {
            return _repositoryWrapper.MaterialFile.FindAll().ToListAsync();
        }

        public Task<MaterialFile> GetById(int idMaterial, int idFile)
        {
            var chat = _repositoryWrapper.MaterialFile
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdFile == idFile).First();
            return Task.FromResult(chat);
        }

        public Task Create(MaterialFile model)
        {
            _repositoryWrapper.MaterialFile.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(MaterialFile model)
        {
            _repositoryWrapper.MaterialFile.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int idMaterial, int idFile)
        {
            var chatUser = _repositoryWrapper.MaterialFile
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdFile == idFile).First();

            _repositoryWrapper.MaterialFile.Delete(chatUser);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
