using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

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

    }
}