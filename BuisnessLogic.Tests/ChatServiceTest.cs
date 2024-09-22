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

    }
}