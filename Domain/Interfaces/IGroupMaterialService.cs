using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGroupMaterialService
    {
        Task<List<GroupMaterial>> GetAll();
        Task<GroupMaterial> GetById(int id);
        Task Create(GroupMaterial model);
        Task Update(GroupMaterial model);
        Task Delete(int id);
    }
}