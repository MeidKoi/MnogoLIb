namespace MnogoLibAPI.Contracts.Payment
{
    public class GetPaymentRequest
    {
        public int IdPayment { get; set; }
        public string CardNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public DateTime ExpressionDate { get; set; }
    }
}