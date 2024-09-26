using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

namespace BuisnessLogic.Tests
{
    public class ChatServiceTest
    {

        public readonly ChatService service;
        private readonly Mock<IChatRepository> repMoq;

        public ChatServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IChatRepository>();

            repositoryWrapperMoq.Setup(x => x.Chat)
                .Returns(repMoq.Object);

            service = new ChatService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectChat()
        {
            return new List<object[]>
            {
                new object[] {new Chat { NameChat = "" } },
            };
        }


        [Fact]
        public async void CreateAsync_NullChat_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Chat>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewChat_ShouldCreateNewChat()
        {
            var example = new Chat()
            {
                IdOwner = 1,
                NameChat = "Name"
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<Chat>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectChat))]
        public async Task CreateAsync_NewChat_ShouldNotCreateNewChat(Chat model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Chat>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        public static IEnumerable<object[]> GetIncorrectChatUpdate()
        {
            return new List<object[]>
            {
                new object[] {new Chat { IdChat = 1, NameChat = "", CreatedTime = DateTime.Now, LastUpdateTime = DateTime.Now } },
                new object[] {new Chat { IdChat = 1, NameChat = "Name", CreatedTime = DateTime.MaxValue, LastUpdateTime = DateTime.Now } },
                new object[] {new Chat { IdChat = 1, NameChat = "Name", CreatedTime = DateTime.Now, LastUpdateTime = DateTime.MaxValue } },
                new object[] {new Chat { IdChat = 1, NameChat = "Name", CreatedTime = DateTime.Now, LastUpdateTime = DateTime.Now, DeletedBy = 1, DeletedTime = null} },
                new object[] {new Chat { IdChat = 1, NameChat = "Name", CreatedTime = DateTime.MinValue, LastUpdateTime = DateTime.Now, DeletedBy = null, DeletedTime = DateTime.Now } },
            };
        }


        [Fact]
        public async void UpdateAsync_NullChat_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<Chat>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewChat_ShouldUpdateNewChat()
        {
            var example = new Chat()
            {
                IdChat = 1,
                NameChat = "Name",
                IdOwner = 1,
                LastUpdateTime = DateTime.Now,
                LastUpdateBy = 1,
                CreatedTime = DateTime.Now,
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<Chat>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectChatUpdate))]
        public async Task UpdateAsync_NewChat_ShouldNotUpdateNewChat(Chat model)
        {
            var example = model;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<Chat>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

    }
}