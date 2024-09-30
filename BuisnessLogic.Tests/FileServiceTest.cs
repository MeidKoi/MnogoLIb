using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;
using File = Domain.Models.File;

namespace BuisnessLogic.Tests
{
    public class FileServiceTest
    {

        public readonly FileService service;
        private readonly Mock<IFileRepository> repMoq;

        public FileServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IFileRepository>();

            repositoryWrapperMoq.Setup(x => x.File)
                .Returns(repMoq.Object);

            service = new FileService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectFile()
        {
            return new List<object[]>
            {
                new object[] {new File { NameFile = "Name", PathFile = "" } },
                new object[] {new File {NameFile = "", PathFile = "Path" } },
                new object[] {new File {NameFile = "", PathFile = "" } },
            };
        }


        [Fact]
        public async void CreateAsync_NullFile_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<File>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewFile_ShouldCreateNewFile()
        {
            var example = new File()
            {
                NameFile = "Name",
                PathFile = "Path"
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<File>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectFile))]
        public async Task CreateAsync_NewFile_ShouldNotCreateNewFile(File model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<File>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        public static IEnumerable<object[]> GetIncorrectFileUpdate()
        {
            return new List<object[]>
            {
                new object[] {new File {IdFile = 1, NameFile = "Name", PathFile = "", CreatedBy = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now } },
                new object[] {new File {IdFile = 1, NameFile = "Name", PathFile = "Path", CreatedBy = 1, CreatedTime = DateTime.MaxValue, LastUpdateBy = 1, LastUpdateTime = DateTime.Now } },
                new object[] {new File {IdFile = 1, NameFile = "Name", PathFile = "Path", CreatedBy = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.MaxValue } },
                new object[] {new File {IdFile = 1, NameFile = "Name", PathFile = "Path", CreatedBy = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now, DeletedBy = 1, DeletedTime = null } },
                new object[] {new File {IdFile = 1, NameFile = "Name", PathFile = "Path", CreatedBy = 1, CreatedTime = DateTime.Now, LastUpdateBy = 1, LastUpdateTime = DateTime.Now, DeletedBy = null, DeletedTime = DateTime.Now } },
            };
        }


        [Fact]
        public async void UpdateAsync_NullFile_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<File>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewFile_ShouldCreateNewFile()
        {
            var example = new File()
            {
                IdFile = 1,
                NameFile = "Name",
                PathFile = "Path",
                CreatedBy = 1,
                CreatedTime = DateTime.Now,
                LastUpdateBy = 1,
                LastUpdateTime = DateTime.Now,
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<File>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectFileUpdate))]
        public async Task UpdateAsync_NewFile_ShouldNotCreateNewFile(File model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<File>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }


        [Fact]
        public async void GetByIdAsync_NullFile_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<File, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullFile_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Delete(It.IsAny<File>()), Times.Never);
        }

    }
}