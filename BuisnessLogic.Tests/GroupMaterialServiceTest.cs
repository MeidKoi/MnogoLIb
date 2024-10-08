using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;

namespace BuisnessLogic.Tests
{
    public class GroupMaterialServiceTest
    {

        public readonly GroupMaterialService service;
        private readonly Mock<IGroupMaterialRepository> repMoq;

        public GroupMaterialServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IGroupMaterialRepository>();

            repositoryWrapperMoq.Setup(x => x.GroupMaterial)
                .Returns(repMoq.Object);

            service = new GroupMaterialService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectGroupMaterial()
        {
            return new List<object[]>
            {
                new object[] {new GroupMaterial { NameGroup = "", DescriptionGroup = "Description",} },
                new object[] {new GroupMaterial { NameGroup = "Name", DescriptionGroup = "",} },
                new object[] {new GroupMaterial { NameGroup = "", DescriptionGroup = "",} },
            };
        }


        [Fact]
        public async void CreateAsync_NullGroupMaterial_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<GroupMaterial>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewGroupMaterial_ShouldCreateNewGroupMaterial()
        {
            var example = new GroupMaterial()
            {
                NameGroup = "Name",
                DescriptionGroup = "Description",
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<GroupMaterial>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectGroupMaterial))]
        public async Task CreateAsync_NewGroupMaterial_ShouldNotCreateNewGroupMaterial(GroupMaterial model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<GroupMaterial>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }


        [Fact]
        public async void UpdateAsync_NullGroupMaterial_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<GroupMaterial>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewGroupMaterial_ShouldUpdateNewGroupMaterial()
        {
            var example = new GroupMaterial()
            {
                NameGroup = "Name",
                DescriptionGroup = "Description",
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<GroupMaterial>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectGroupMaterial))]
        public async Task UpdateAsync_NewGroupMaterial_ShouldNotUpdateNewGroupMaterial(GroupMaterial model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<GroupMaterial>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async void GetByIdAsync_NullGroupMaterial_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<GroupMaterial, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullGroupMaterial_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Delete(It.IsAny<GroupMaterial>()), Times.Never);
        }

    }
}