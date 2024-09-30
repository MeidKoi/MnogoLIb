using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;

namespace BuisnessLogic.Tests
{
    public class MaterialServiceTest
    {

        public readonly MaterialService service;
        private readonly Mock<IMaterialRepository> repMoq;

        public MaterialServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IMaterialRepository>();

            repositoryWrapperMoq.Setup(x => x.Material)
                .Returns(repMoq.Object);

            service = new MaterialService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectMaterial()
        {
            return new List<object[]>
            {
                new object[] {new Material { NameMaterial = "", DescriptionMaterial = "Description", IdCategory = 1, IdAuthor = 1, IdAuthorStatus = 1, CreatedBy = 1, FileIcon = 1  } },
                new object[] {new Material { NameMaterial = "Name", DescriptionMaterial = "", IdCategory = 1, IdAuthor = 1, IdAuthorStatus = 1, CreatedBy = 1, FileIcon = 1 } },
            };
        }


        [Fact]
        public async void CreateAsync_NullMaterial_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Material>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewMaterial_ShouldCreateNewMaterial()
        {
            var example = new Material()
            {
                NameMaterial = "Name",
                DescriptionMaterial = "Description",
                IdCategory = 1,
                CreatedBy = 1,
                IdAuthor = 1,
                IdAuthorStatus = 1,
                FileIcon = 1,
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<Material>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectMaterial))]
        public async Task CreateAsync_NewMaterial_ShouldNotCreateNewMaterial(Material model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Material>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        public static IEnumerable<object[]> GetIncorrectMaterialUpdate()
        {
            return new List<object[]>
            {
                new object[] {new Material { IdMaterial = 1, NameMaterial = "", DescriptionMaterial = "Description", IdCategory = 1, IdAuthor = 1, IdAuthorStatus = 1, CreatedBy = 1, FileIcon = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now  } },
                new object[] {new Material { IdMaterial = 1, NameMaterial = "Name", DescriptionMaterial = "", IdCategory = 1, IdAuthor = 1, IdAuthorStatus = 1, CreatedBy = 1, FileIcon = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now  } },
                new object[] {new Material { IdMaterial = 1, NameMaterial = "Name", DescriptionMaterial = "Description", IdCategory = 1, IdAuthor = 1, IdAuthorStatus = 1, CreatedBy = 1, FileIcon = 1, CreatedTime = DateTime.MaxValue, LastUpdateBy = 1, LastUpdateTime = DateTime.Now  } },
                new object[] {new Material { IdMaterial = 1, NameMaterial = "Name", DescriptionMaterial = "Description", IdCategory = 1, IdAuthor = 1, IdAuthorStatus = 1, CreatedBy = 1, FileIcon = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.MaxValue  } },
                new object[] {new Material { IdMaterial = 1, NameMaterial = "Name", DescriptionMaterial = "Description", IdCategory = 1, IdAuthor = 1, IdAuthorStatus = 1, CreatedBy = 1, FileIcon = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now, DeletedBy = 1, DeletedTime = null  } },
                new object[] {new Material { IdMaterial = 1, NameMaterial = "Name", DescriptionMaterial = "Description", IdCategory = 1, IdAuthor = 1, IdAuthorStatus = 1, CreatedBy = 1, FileIcon = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now, DeletedBy = null, DeletedTime = DateTime.Now  } },
            };
        }


        [Fact]
        public async void UpdateAsync_NullMaterial_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<Material>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewMaterial_ShouldUpdateNewMaterial()
        {
            var example = new Material()
            {
                NameMaterial = "Name",
                DescriptionMaterial = "Description",
                IdCategory = 1,
                CreatedBy = 1,
                IdAuthor = 1,
                IdAuthorStatus = 1,
                FileIcon = 1,
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<Material>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectMaterialUpdate))]
        public async Task UpdateAsync_NewMaterial_ShouldNotUpdateNewMaterial(Material model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<Material>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async void GetByIdAsync_NullMaterial_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<Material, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullMaterial_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Delete(It.IsAny<Material>()), Times.Never);
        }
    }
}