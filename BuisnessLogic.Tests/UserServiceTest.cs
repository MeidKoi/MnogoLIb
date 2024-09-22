using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

namespace BuisnessLogic.Tests
{
    public class UserServiceTest
    {

        public readonly UserService service;
        private readonly Mock<IUserRepository> repMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(repMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectUser()
        {
            return new List<object[]>
            {
                new object[] {new User { EmailUser = "", PasswordUser = "", NicknameUser = "" } },
                new object[] {new User { EmailUser = "email@email.com", PasswordUser = "", NicknameUser = "Nick" } },
                new object[] {new User { EmailUser = "", PasswordUser = "12345pass", NicknameUser = "Nick" } },
                new object[] {new User { EmailUser = "email@email.com", PasswordUser = "12345pass", NicknameUser = "" } },
            };
        }


        [Fact]
        public async void CreateAsync_NullUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewUser_ShouldCreateNewUser()
        {
            var example = new User()
            {
                EmailUser = "email@email.com",
                PasswordUser = "12345pass",
                NicknameUser = "Nick"
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectUser))]
        public async Task CreateAsync_NewUser_ShouldNotCreateNewUser(User user)
        {
            var example = user;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

    }
}