using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

namespace BuisnessLogic.Tests
{
    public class AuthorServiceTest
    {

        public readonly AuthorService service;
        private readonly Mock<IAuthorRepository> repMoq;

        public AuthorServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IAuthorRepository>();

            repositoryWrapperMoq.Setup(x => x.Author)
                .Returns(repMoq.Object);

            service = new AuthorService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectAuthor()
        {
            return new List<object[]>
            {
                new object[] {new Author { NameAuthor = "" } },
            };
        }


        [Fact]
        public async void CreateAsync_NullAuthor_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Author>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewAuthor_ShouldCreateNewAuthor()
        {
            var example = new Author()
            {
                NameAuthor = "Name"
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<Author>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectAuthor))]
        public async Task CreateAsync_NewAuthor_ShouldNotCreateNewAuthor(Author model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Author>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

    }
}