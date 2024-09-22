using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

namespace BuisnessLogic.Tests
{
    public class MessageUserServiceTest
    {

        public readonly MessageUserService service;
        private readonly Mock<IMessageUserRepository> repMoq;

        public MessageUserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IMessageUserRepository>();

            repositoryWrapperMoq.Setup(x => x.MessageUser)
                .Returns(repMoq.Object);

            service = new MessageUserService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectMessageUser()
        {
            return new List<object[]>
            {
                new object[] {new MessagesUser { TextMessage = "" } },
            };
        }


        [Fact]
        public async void CreateAsync_NullMessageUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<MessagesUser>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewMessageUser_ShouldCreateNewMessageUser()
        {
            var example = new MessagesUser()
            {
                IdUser = 1,
                IdChat = 1,
                TextMessage = "Text",
                IdMessageStatus = 1
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<MessagesUser>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectMessageUser))]
        public async Task CreateAsync_NewMessageUser_ShouldNotCreateNewMessageUser(MessagesUser model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<MessagesUser>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

    }
}