using Domain.Interfaces;
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
            var user = await _repositoryWrapper.Author
                .FindByCondition(x => x.IdAuthor == id);
            return user.First();
        }

        public async Task Create(Author model)
        {
            _repositoryWrapper.Author.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Author model)
        {
            _repositoryWrapper.Author.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Author
                .FindByCondition(x => x.IdAuthor == id);

            _repositoryWrapper.Author.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}