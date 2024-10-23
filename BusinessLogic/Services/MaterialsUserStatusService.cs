using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class MaterialsUserStatusService : IMaterialsUserStatusService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MaterialsUserStatusService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MaterialsUserStatus>> GetAll()
        {
            return await _repositoryWrapper.MaterialsUserStatus.FindAll();
        }

        public async Task<MaterialsUserStatus> GetById(int idMaterial, int idUserStatus, int idUser)
        {
            var model = await _repositoryWrapper.MaterialsUserStatus
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdUserStatus == idUserStatus && x.IdUser == idUser);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
        }

        public async Task Create(MaterialsUserStatus model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _repositoryWrapper.MaterialsUserStatus.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(MaterialsUserStatus model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _repositoryWrapper.MaterialsUserStatus.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int idMaterial, int idUserStatus, int idUser)
        {
            var model = await _repositoryWrapper.MaterialsUserStatus
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdUserStatus == idUserStatus && x.IdUser == idUser);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            await _repositoryWrapper.MaterialsUserStatus.Delete(model.First());
            await _repositoryWrapper.Save();
        }
    }
}