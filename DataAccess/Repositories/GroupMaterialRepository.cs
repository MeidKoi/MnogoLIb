using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repositories
{
    public class GroupMaterialRepository : RepositoryBase<GroupMaterial>, IGroupMaterialRepository
    {
        public GroupMaterialRepository(MnogoLibContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}