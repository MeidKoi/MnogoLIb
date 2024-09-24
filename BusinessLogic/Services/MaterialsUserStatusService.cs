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
            var user = await _repositoryWrapper.MaterialsUserStatus
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdUserStatus == idUserStatus && x.IdUser == idUser);
            return user.First();
        }

        public async Task Create(MaterialsUserStatus model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _repositoryWrapper.MaterialsUserStatus.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(MaterialsUserStatus model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _repositoryWrapper.MaterialsUserStatus.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int idMaterial, int idUserStatus, int idUser)
        {
            var user = await _repositoryWrapper.MaterialsUserStatus
                .FindByCondition(x => x.IdMaterial == idMaterial && x.IdUserStatus == idUserStatus && x.IdUser == idUser);

            _repositoryWrapper.MaterialsUserStatus.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}

//(int idMaterial, int idMaterialsUserStatus, int idMaterialsUserStatusStatus)
//(x => x.IdMaterial == idMaterial && x.IdMaterialsUserStatus == idMaterialsUserStatus && x.IdMaterialsUserStatusStatus == idMaterialsUserStatusStatus).First();