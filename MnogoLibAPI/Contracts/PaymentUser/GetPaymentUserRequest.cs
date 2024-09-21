namespace MnogoLibAPI.Contracts.PaymentUser
{
    public class GetPaymentUserRequest
    {
        public int IdPayment { get; set; }
        public int IdUser { get; set; }
        public bool IsActive { get; set; }
    }
}
