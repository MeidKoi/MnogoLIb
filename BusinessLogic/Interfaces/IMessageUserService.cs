using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMessageUserService
    {
        Task<List<MessagesUser>> GetAll();
        Task<MessagesUser> GetById(int id);
        Task Create(MessagesUser message);
        Task Update(MessagesUser message);
        Task Delete(int id);
    }
}
