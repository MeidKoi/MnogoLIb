using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMaterialFileService
    {
        Task<List<MaterialFile>> GetAll();
        Task<MaterialFile> GetById(int idMaterial, int idFile);
        Task Create(MaterialFile model);
        Task Update(MaterialFile model);
        Task Delete(int idMaterial, int idFile);
    }
}
