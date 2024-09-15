using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CategoryRepository :RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(MnogoLibContext repositoryContext)
                : base(repositoryContext)
        {
        }
    }
}
