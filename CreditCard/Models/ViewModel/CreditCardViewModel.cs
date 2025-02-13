using CreditCard.Models.DTOs;

namespace CreditCard.Models.ViewModel
{
    public class CreditCardViewModel
    {
        public List<CreditCardDTO> CreditCards { get; set; }
        public string ErrorMessage { get; set; }
    }

}
