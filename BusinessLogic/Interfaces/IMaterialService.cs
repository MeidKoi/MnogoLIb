using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMaterialService
    {
        Task<List<Material>> GetAll();
        Task<Material> GetById(int id);
        Task Create(Material model);
        Task Update(Material model);
        Task Delete(int id);
    }
}
