using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class RateService : IRateService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RateService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Rate>> GetAll()
        {
            return _repositoryWrapper.Rate.FindAll().ToListAsync();
        }

        public Task<Rate> GetById(int id)
        {
            var user = _repositoryWrapper.Rate
                .FindByCondition(x => x.IdRate == id).First();
            return Task.FromResult(user);
        }

        public Task Create(Rate model)
        {
            _repositoryWrapper.Rate.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Rate model)
        {
            _repositoryWrapper.Rate.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var user = _repositoryWrapper.Rate
                .FindByCondition(x => x.IdRate == id).First();

            _repositoryWrapper.Rate.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}