using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

namespace BuisnessLogic.Tests
{
    public class RateServiceTest
    {

        public readonly RateService service;
        private readonly Mock<IRateRepository> repMoq;

        public RateServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IRateRepository>();

            repositoryWrapperMoq.Setup(x => x.Rate)
                .Returns(repMoq.Object);

            service = new RateService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectRate()
        {
            return new List<object[]>
            {
                new object[] {new Rate { IdUser = 1, IdMaterial = 1, ValueRate = 0, } },
                new object[] {new Rate { IdUser = 1, IdMaterial = 1, ValueRate = 11, } },
            };
        }


        [Fact]
        public async void CreateAsync_NullRate_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Rate>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewRate_ShouldCreateNewRate()
        {
            var example = new Rate()
            {
                IdUser = 1,
                IdMaterial = 1,
                ValueRate = 9,
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<Rate>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectRate))]
        public async Task CreateAsync_NewRate_ShouldNotCreateNewRate(Rate model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Rate>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async void UpdateAsync_NullRate_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<Rate>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewRate_ShouldUpdateNewRate()
        {
            var example = new Rate()
            {
                IdUser = 1,
                IdMaterial = 1,
                ValueRate = 9,
            };

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<Rate>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectRate))]
        public async Task UpdateAsync_NewRate_ShouldNotCreateNewRate(Rate model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<Rate>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }


    }
}