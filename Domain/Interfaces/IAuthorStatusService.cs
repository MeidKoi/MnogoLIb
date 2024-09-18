using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthorStatusService
    {
        Task<List<AuthorStatus>> GetAll();
        Task<AuthorStatus> GetById(int id);
        Task Create(AuthorStatus model);
        Task Update(AuthorStatus model);
        Task Delete(int id);
    }
}
