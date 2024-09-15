﻿using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AuthorService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Author>> GetAll()
        {
            return _repositoryWrapper.Author.FindAll().ToListAsync();
        }

        public Task<Author> GetById(int id)
        {
            var material = _repositoryWrapper.Author
                .FindByCondition(x => x.IdAuthor == id).First();
            return Task.FromResult(material);
        }

        public Task Create(Author model)
        {
            _repositoryWrapper.Author.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Author model)
        {
            _repositoryWrapper.Author.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var material = _repositoryWrapper.Author
                .FindByCondition(x => x.IdAuthor == id).First();

            _repositoryWrapper.Author.Delete(material);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
