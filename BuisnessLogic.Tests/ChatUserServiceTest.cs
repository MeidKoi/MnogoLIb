using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

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


        public static IEnumerable<object[]> GetIncorrectChatUser()
        {
            return new List<object[]>
            {
                new object[] {new ChatUser { IdChat = -1, IdUser = -1 } },
                new object[] {new ChatUser { IdChat = 0, IdUser = 0} }
            };
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

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<ChatUser>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectChatUser))]
        public async Task CreateAsync_NewChatUser_ShouldNotCreateNewChatUser(ChatUser user)
        {
            var example = user;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<ChatUser>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

    }
}