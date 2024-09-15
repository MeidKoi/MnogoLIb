using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ChatUserRepository : RepositoryBase<ChatUser>, IChatUserRepository
    {
        public ChatUserRepository(MnogoLibContext repositoryContext)
                : base(repositoryContext)
        {
        }
    }
}
