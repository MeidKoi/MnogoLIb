using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
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

    }
}