using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;

namespace BuisnessLogic.Tests
{
    public class MaterialsUserStatusServiceTest
    {

        public readonly MaterialsUserStatusService service;
        private readonly Mock<IMaterialsUserStatusRepository> repMoq;

        public MaterialsUserStatusServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IMaterialsUserStatusRepository>();

            repositoryWrapperMoq.Setup(x => x.MaterialsUserStatus)
                .Returns(repMoq.Object);

            service = new MaterialsUserStatusService(repositoryWrapperMoq.Object);
        }


        [Fact]
        public async void CreateAsync_NullMaterialsUserStatus_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<MaterialsUserStatus>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewMaterialsUserStatus_ShouldCreateNewMaterialsUserStatus()
        {
            var example = new MaterialsUserStatus()
            {
                IdUserStatus = 1,
                IdMaterial = 1,
                IdUser = 1,
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<MaterialsUserStatus>()), Times.Once);
        }

        [Fact]
        public async void UpdateAsync_NullMaterialsUserStatus_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<MaterialsUserStatus>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewMaterialsUserStatus_ShouldCreateNewMaterialsUserStatus()
        {
            var example = new MaterialsUserStatus()
            {
                IdUserStatus = 1,
                IdMaterial = 1,
                IdUser = 1,
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<MaterialsUserStatus>()), Times.Once);
        }

        [Fact]
        public async void GetByIdAsync_NullMaterialUserStatus_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1, -1, -1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<MaterialsUserStatus, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1, -1, -1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Delete(It.IsAny<MaterialsUserStatus>()), Times.Never);
        }
    }
}