using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class RateService : IRateService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RateService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Rate>> GetAll()
        {
            return await _repositoryWrapper.Rate.FindAll();
        }

        public async Task<Rate> GetById(int id)
        {
            var user = await _repositoryWrapper.Rate
                .FindByCondition(x => x.IdRate == id);
            return user.First();
        }

        public async Task Create(Rate model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.ValueRate < 1 || model.ValueRate > 10)
            {
                throw new ArgumentException(nameof(model.ValueRate));
            }

            _repositoryWrapper.Rate.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Rate model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.ValueRate < 1 || model.ValueRate > 10)
            {
                throw new ArgumentException(nameof(model.ValueRate));
            }

            _repositoryWrapper.Rate.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Rate
                .FindByCondition(x => x.IdRate == id);

            _repositoryWrapper.Rate.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}