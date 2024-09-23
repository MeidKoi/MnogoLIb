using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;

namespace BuisnessLogic.Tests
{
    public class PaymentServiceTest
    {

        public readonly PaymentService service;
        private readonly Mock<IPaymentRepository> repMoq;

        public PaymentServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IPaymentRepository>();

            repositoryWrapperMoq.Setup(x => x.Payment)
                .Returns(repMoq.Object);

            service = new PaymentService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectPayment()
        {
            return new List<object[]>
            {
                new object[] {new Payment { CardNumber = "-123456789012345", ExpressionDate = DateTime.ParseExact("22-10-2027", "dd-MM-yyyy", null), Cvv = "333"  } },
                new object[] {new Payment { CardNumber = "", ExpressionDate = DateTime.ParseExact("22-10-2027", "dd-MM-yyyy", null), Cvv = "333"  } },
                new object[] {new Payment { CardNumber = "adssdadsa", ExpressionDate = DateTime.ParseExact("22-10-2027", "dd-MM-yyyy", null), Cvv = "333"  } },
                new object[] {new Payment { CardNumber = "1234567890123456", ExpressionDate = DateTime.MinValue, Cvv = "333"  } },
                new object[] {new Payment { CardNumber = "1234567890123456", ExpressionDate = DateTime.ParseExact("22-10-2027", "dd-MM-yyyy", null), Cvv = "-23"  } },
                new object[] {new Payment { CardNumber = "1234567890123456", ExpressionDate = DateTime.ParseExact("22-10-2027", "dd-MM-yyyy", null), Cvv = "ads"  } },
                new object[] {new Payment { CardNumber = "1234567890123456", ExpressionDate = DateTime.ParseExact("22-10-2027", "dd-MM-yyyy", null), Cvv = ""  } },

            };
        }


        [Fact]
        public async void CreateAsync_NullPayment_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Payment>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewPayment_ShouldCreateNewPayment()
        {
            var example = new Payment()
            {
                CardNumber = "1234567890123456",
                ExpressionDate = DateTime.MaxValue,
                Cvv = "333"
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<Payment>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectPayment))]
        public async Task CreateAsync_NewPayment_ShouldNotCreateNewPayment(Payment model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<Payment>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }

    }
}