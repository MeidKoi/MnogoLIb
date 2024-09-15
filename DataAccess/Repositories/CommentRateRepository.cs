﻿using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CommentRateRepository : RepositoryBase<CommentRate>, ICommentRateRepository
    {
        public CommentRateRepository(MnogoLibContext repositoryContext)
                : base(repositoryContext)
        {
        }
    }
}
