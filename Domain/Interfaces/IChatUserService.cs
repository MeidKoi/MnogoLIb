using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
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