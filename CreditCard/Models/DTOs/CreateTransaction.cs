namespace CreditCard.Models.DTOs
{
    public class CreateTransaction
    {
        public int CreditCardID { get; set; }
        public int Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }
}
