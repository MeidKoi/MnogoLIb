using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMaterialsUserStatusService
    {
        Task<List<MaterialsUserStatus>> GetAll();
        Task<MaterialsUserStatus> GetById(int idMaterial, int idUser, int idUserStatus);
        Task Create(MaterialsUserStatus model);
        Task Update(MaterialsUserStatus model);
        Task Delete(int idMaterial, int idUser, int idUserStatus);
    }
}
