using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;
using System.Numerics;

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
        public async Task CreateAsync_NewUser_ShouldNotCreateNewUser(User model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }


        public static IEnumerable<object[]> UpdateIncorrectUser()
        {
            return new List<object[]>
            {
                new object[] {new User { IdUser = 1, EmailUser = "", PasswordUser = "Password", NicknameUser = "Nick", IdRole = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now, DeletedBy = null, DeletedTime = null } },
                new object[] {new User { IdUser = 1, EmailUser = "email", PasswordUser = "Password", NicknameUser = "", IdRole = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now, DeletedBy = null, DeletedTime = null } },
                new object[] {new User { IdUser = 1, EmailUser = "email", PasswordUser = "Password", NicknameUser = "Nick", IdRole = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now, DeletedBy = 1, DeletedTime = null } },
                new object[] {new User { IdUser = 1, EmailUser = "email", PasswordUser = "Password", NicknameUser = "Nick", IdRole = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now, DeletedBy = null, DeletedTime = DateTime.Now } },
            };
        }


        [Fact]
        public async void UpdateAsync_NullUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewUser_ShouldCreateNewUser()
        {
            var example = new User()
            {
                IdUser = 1,
                EmailUser = "email@email.com",
                PasswordUser = "12345pass",
                NicknameUser = "Nick",
                IdRole = 1,
                CreatedTime = DateTime.ParseExact("22-09-2022", "dd-MM-yyyy", null),
                LastUpdateBy = 1,
                LastUpdateTime = DateTime.Now,
                DeletedBy = null,
                DeletedTime = null
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(UpdateIncorrectUser))]
        public async Task UpdateAsync_NewUser_ShouldNotCreateNewUser(User model)
        {
            var example = model;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }


        [Fact]
        public async void GetByIdAsync_NullUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Delete(It.IsAny<User>()), Times.Never);
        }



    }
}