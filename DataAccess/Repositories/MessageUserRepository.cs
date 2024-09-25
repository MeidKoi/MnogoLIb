using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repositories
{
    public class MessageUserRepository : RepositoryBase<MessagesUser>, IMessageUserRepository
    {
        public MessageUserRepository(MnogoLibContext repositoryContext)
                : base(repositoryContext)
        {
        }
    }
}