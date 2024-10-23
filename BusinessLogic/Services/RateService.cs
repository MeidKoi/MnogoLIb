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
            var model = await _repositoryWrapper.Rate
                .FindByCondition(x => x.IdRate == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }


            return model.First();
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

            await _repositoryWrapper.Rate.Create(model);
            await _repositoryWrapper.Save();
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

            if (model.CreatedTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedTime));
            }

            if (model.LastUpdateTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.LastUpdateTime));
            }

            if (model.DeletedTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.DeletedTime));
            }

            await _repositoryWrapper.Rate.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var model = await _repositoryWrapper.Rate
                .FindByCondition(x => x.IdRate == id);

            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }


            await _repositoryWrapper.Rate.Delete(model.First());
            await _repositoryWrapper.Save();
        }
    }
}