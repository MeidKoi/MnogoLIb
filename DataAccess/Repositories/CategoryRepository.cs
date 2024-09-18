﻿using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class CategoryRepository :RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(MnogoLibContext repositoryContext)
                : base(repositoryContext)
        {
        }
    }
}
