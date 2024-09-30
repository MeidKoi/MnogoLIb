using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;

namespace BuisnessLogic.Tests
{
    public class ChatUserServiceTest
    {

        public readonly ChatUserService service;
        private readonly Mock<IChatUserRepository> repMoq;

        public ChatUserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IChatUserRepository>();

            repositoryWrapperMoq.Setup(x => x.ChatUser)
                .Returns(repMoq.Object);

            service = new ChatUserService(repositoryWrapperMoq.Object);
        }



        [Fact]
        public async void CreateAsync_NullChatUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<ChatUser>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewChatUser_ShouldCreateNewChatUser()
        {
            var example = new ChatUser()
            {
                IdUser = 1,
                IdChat = 1
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<ChatUser>()), Times.Once);
        }

        [Fact]
        public async void UpdateAsync_NullChatUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<ChatUser>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewChatUser_ShouldUpdateNewChatUser()
        {
            var example = new ChatUser()
            {
                IdUser = 1,
                IdChat = 1
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<ChatUser>()), Times.Once);
        }
        [Fact]
        public async void GetByIdAsync_NullChatUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1, -1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<ChatUser, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullChatUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1, -1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Delete(It.IsAny<ChatUser>()), Times.Never);
        }

    }
}