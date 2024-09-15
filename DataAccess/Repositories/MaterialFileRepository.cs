using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class MaterialFileRepository : RepositoryBase<MaterialFile>, IMaterialFileRepository
    {
        public MaterialFileRepository(MnogoLibContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
