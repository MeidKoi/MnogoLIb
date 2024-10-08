using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;

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


        public static IEnumerable<object[]> GetIncorrectMessageUserUpdate()
        {
            return new List<object[]>
            {
                new object[] {new MessagesUser { IdChat = 1, TextMessage = "", IdUser = 1, DeliverDate = DateTime.Now, CreatedTime = DateTime.Now, LastUpdateTime = DateTime.Now } },
                new object[] {new MessagesUser { IdChat = 1, TextMessage = "Text", IdUser = 1, DeliverDate = DateTime.Now, CreatedTime = DateTime.MaxValue, LastUpdateTime = DateTime.Now } },
                new object[] {new MessagesUser { IdChat = 1, TextMessage = "Text", IdUser = 1, DeliverDate = DateTime.Now, CreatedTime = DateTime.Now, LastUpdateTime = DateTime.MaxValue } },
                new object[] {new MessagesUser { IdChat = 1, TextMessage = "Text", IdUser = 1, DeliverDate = DateTime.Now, CreatedTime = DateTime.Now, LastUpdateTime = DateTime.Now, DeletedBy = 1, DeletedTime = null} },
                new object[] {new MessagesUser { IdChat = 1, TextMessage = "Text", IdUser = 1, DeliverDate = DateTime.Now, CreatedTime = DateTime.Now, LastUpdateTime = DateTime.Now, DeletedBy = null, DeletedTime = DateTime.Now } },
            };
        }


        [Fact]
        public async void UpdateAsync_NullMessageUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<MessagesUser>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewMessageUser_ShouldUpdateNewMessageUser()
        {
            var example = new MessagesUser()
            {
                IdUser = 1,
                IdChat = 1,
                TextMessage = "Text",
                IdMessageStatus = 1
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<MessagesUser>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectMessageUserUpdate))]
        public async Task UpdateAsync_NewMessageUser_ShouldNotUpdateNewMessageUser(MessagesUser model)
        {
            var example = model;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<MessagesUser>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async void GetByIdAsync_NullMessagesUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<MessagesUser, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullMessagesUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Delete(It.IsAny<MessagesUser>()), Times.Never);
        }
    }
}