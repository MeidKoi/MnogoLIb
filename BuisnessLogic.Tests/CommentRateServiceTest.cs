using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

namespace BuisnessLogic.Tests
{
    public class CommentRateServiceTest
    {

        public readonly CommentRateService service;
        private readonly Mock<ICommentRateRepository> repMoq;

        public CommentRateServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<ICommentRateRepository>();

            repositoryWrapperMoq.Setup(x => x.CommentRate)
                .Returns(repMoq.Object);

            service = new CommentRateService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectCommentRate()
        {
            return new List<object[]>
            {
                new object[] {new CommentRate { IdComment = 1, IdUser = 1, Value = -5 } },
                new object[] {new CommentRate { IdComment = 1, IdUser = 1, Value = 5 } },
                new object[] {new CommentRate { IdComment = 1, IdUser = 1, Value = 0 } },
            };
        }


        [Fact]
        public async void CreateAsync_NullCommentRate_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<CommentRate>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewCommentRate_ShouldCreateNewCommentRate()
        {
            var example = new CommentRate()
            {
                IdComment = 1,
                IdUser = 1,
                Value = 1
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<CommentRate>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectCommentRate))]
        public async Task CreateAsync_NewCommentRate_ShouldNotCreateNewCommentRate(CommentRate model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<CommentRate>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async void UpdateAsync_NullCommentRate_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<CommentRate>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewCommentRate_ShouldUpdateNewCommentRate()
        {
            var example = new CommentRate()
            {
                IdComment = 1,
                IdUser = 1,
                Value = 1
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<CommentRate>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectCommentRate))]
        public async Task UpdateAsync_NewCommentRate_ShouldNotUpdateNewCommentRate(CommentRate model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<CommentRate>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

    }
}