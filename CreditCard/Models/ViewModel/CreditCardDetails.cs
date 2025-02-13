using CreditCard.Models.DTOs;

namespace CreditCard.Models.ViewModel
{
    public class CreditCardDetails
    {
        public CreditCardDTO CreditCard { get; set; }
        public IEnumerable<TransactionDTOList> Transactions { get; set; }


    }
}
