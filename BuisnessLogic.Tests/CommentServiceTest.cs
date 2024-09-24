using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

namespace BuisnessLogic.Tests
{
    public class CommentServiceTest
    {

        public readonly CommentService service;
        private readonly Mock<ICommentRepository> repMoq;

        public CommentServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<ICommentRepository>();

            repositoryWrapperMoq.Setup(x => x.Comment)
                .Returns(repMoq.Object);

            service = new CommentService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectComment()
        {
            return new List<object[]>
            {
                new object[] {new Comment { IdUser = 1, TextComment = "",  } },
                new object[] {new Comment { IdUser = -1, TextComment = "" } },
            };
        }


        [Fact]
        public async void CreateAsync_NullComment_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Comment>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewComment_ShouldCreateNewComment()
        {
            var example = new Comment()
            {
                IdUser = 1,
                TextComment = "Comment"
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<Comment>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectComment))]
        public async Task CreateAsync_NewComment_ShouldNotCreateNewComment(Comment model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Comment>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        public static IEnumerable<object[]> GetIncorrectCommentUpdate()
        {
            return new List<object[]>
            {
                new object[] {new Comment { IdComment = 1, IdUser = 1, TextComment = "", CreatedTime = DateTime.Now, LastUpdateTime = DateTime.Now, DeletedTime = DateTime.Now} },
                new object[] {new Comment { IdComment = 1, IdUser = 1, TextComment = "Name", CreatedTime = DateTime.MaxValue, LastUpdateTime = DateTime.Now, DeletedTime = DateTime.Now} },
                new object[] {new Comment { IdComment = 1, IdUser = 1, TextComment = "Name", CreatedTime = DateTime.Now, LastUpdateTime = DateTime.MaxValue, DeletedTime = DateTime.MaxValue} },
            };
        }


        [Fact]
        public async void UpdateAsync_NullComment_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<Comment>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewComment_ShouldUpdateNewComment()
        {
            var example = new Comment()
            {
                IdUser = 1,
                TextComment = "Comment"
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<Comment>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectCommentUpdate))]
        public async Task UpdateAsync_NewComment_ShouldNotCreateNewComment(Comment model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<Comment>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }


    }
}