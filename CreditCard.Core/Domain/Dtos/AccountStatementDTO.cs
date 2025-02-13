using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Domain.Dtos
{
    public class AccountStatementDTO
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal AvailableCredit { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal TotalPurchasesCurrentMonth { get; set; }
        public decimal TotalPurchasesPreviousMonth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal InterestCharged { get; set; }
        public decimal MinimumPayment { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal TotalAmountDueWithInterest { get; set; }
    }
}
