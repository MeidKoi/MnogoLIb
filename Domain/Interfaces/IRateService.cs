using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRateService
    {
        Task<List<Rate>> GetAll();
        Task<Rate> GetById(int id);
        Task Create(Rate message);
        Task Update(Rate message);
        Task Delete(int id);
    }
}