﻿using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AuthorService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _repositoryWrapper.Author.FindAll();
        }

        public async Task<Author> GetById(int id)
        {
            var model = await _repositoryWrapper.Author
                .FindByCondition(x => x.IdAuthor == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }

            return model.First();
        }

        public async Task Create(Author model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameAuthor))
            {
                throw new ArgumentException(nameof(model.NameAuthor));
            }

            _repositoryWrapper.Author.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Author model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameAuthor))
            {
                throw new ArgumentException(nameof(model.NameAuthor));
            }

            _repositoryWrapper.Author.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var model = await _repositoryWrapper.Author
                .FindByCondition(x => x.IdAuthor == id);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            _repositoryWrapper.Author.Delete(model.First());
            _repositoryWrapper.Save();
        }
    }
}