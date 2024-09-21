namespace MnogoLibAPI.Contracts.PaymentUser
{
    public class CreatePaymentUserRequest
    {
        public int IdPayment { get; set; }
        public int IdUser { get; set; }
        public bool IsActive { get; set; }
    }
}
