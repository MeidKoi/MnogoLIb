using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IChatUserService
    {
        Task<List<ChatUser>> GetAll();
        Task<ChatUser> GetById(int idChat, int idUser);
        Task Create(ChatUser model);
        Task Update(ChatUser model);
        Task Delete(int idChat, int idUser);
    }
}
