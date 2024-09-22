using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

namespace BuisnessLogic.Tests
{
    public class PaymentUserServiceTest
    {

        public readonly PaymentUserService service;
        private readonly Mock<IPaymentUserRepository> repMoq;

        public PaymentUserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IPaymentUserRepository>();

            repositoryWrapperMoq.Setup(x => x.PaymentUser)
                .Returns(repMoq.Object);

            service = new PaymentUserService(repositoryWrapperMoq.Object);
        }



        [Fact]
        public async void CreateAsync_NullPaymentUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<PaymentUser>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewPaymentUser_ShouldCreateNewPaymentUser()
        {
            var example = new PaymentUser()
            {
                IdPayment = 1,
                IdUser = 1,
                IsActive = true
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<PaymentUser>()), Times.Once);
        }

    }
}