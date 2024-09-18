using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AuthorStatusService : IAuthorStatusService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AuthorStatusService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<AuthorStatus>> GetAll()
        {
            return _repositoryWrapper.AuthorStatus.FindAll().ToListAsync();
        }

        public Task<AuthorStatus> GetById(int id)
        {
            var material = _repositoryWrapper.AuthorStatus
                .FindByCondition(x => x.IdAuthorStatus == id).First();
            return Task.FromResult(material);
        }

        public Task Create(AuthorStatus model)
        {
            _repositoryWrapper.AuthorStatus.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(AuthorStatus model)
        {
            _repositoryWrapper.AuthorStatus.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var material = _repositoryWrapper.AuthorStatus
                .FindByCondition(x => x.IdAuthorStatus == id).First();

            _repositoryWrapper.AuthorStatus.Delete(material);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
