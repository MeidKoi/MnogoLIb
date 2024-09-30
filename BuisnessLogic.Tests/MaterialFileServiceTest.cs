using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;

namespace BuisnessLogic.Tests
{
    public class MaterialFileServiceTest
    {

        public readonly MaterialFileService service;
        private readonly Mock<IMaterialFileRepository> repMoq;

        public MaterialFileServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IMaterialFileRepository>();

            repositoryWrapperMoq.Setup(x => x.MaterialFile)
                .Returns(repMoq.Object);

            service = new MaterialFileService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectMaterialFile()
        {
            return new List<object[]>
            {
                new object[] {new MaterialFile { IdFile = 1, IdMaterial = 1, Volume = -1, Chapter = 1, FrameNumber = 1 } },
                new object[] {new MaterialFile { IdFile = 1, IdMaterial = 1, Volume = 1, Chapter = -1, FrameNumber = 1 } },
                //new object[] {new MaterialFile { IdFile = 1, IdMaterial = 1, Volume = 1, Chapter = 1, FrameNumber = -1 } },
            };
        }


        [Fact]
        public async void CreateAsync_NullMaterialFile_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<MaterialFile>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewMaterialFile_ShouldCreateNewMaterialFile()
        {
            var example = new MaterialFile()
            {
                IdMaterial = 1,
                IdFile = 1,
                Volume = 1,
                Chapter = 1,
                FrameNumber = 1
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<MaterialFile>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectMaterialFile))]
        public async Task CreateAsync_NewMaterialFile_ShouldNotCreateNewMaterialFile(MaterialFile model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<MaterialFile>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async void UpdateAsync_NullMaterialFile_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<MaterialFile>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewMaterialFile_ShouldUpdateNewMaterialFile()
        {
            var example = new MaterialFile()
            {
                IdMaterial = 1,
                IdFile = 1,
                Volume = 1,
                Chapter = 1,
                FrameNumber = 1
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<MaterialFile>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectMaterialFile))]
        public async Task UpdateAsync_NewMaterialFile_ShouldNotUpdateNewMaterialFile(MaterialFile model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<MaterialFile>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async void GetByIdAsync_NullUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1, -1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<MaterialFile, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1, -1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Delete(It.IsAny<MaterialFile>()), Times.Never);
        }
    }
}