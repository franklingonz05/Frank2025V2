using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Domain.Dtos
{
    public class TransactionDTOList
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int CodeType { get; set; } // Código numérico del tipo de transacción (1 = Compra, 2 = Pago)
        public string Type { get; set; }  // Descripción textual de la transacción ("Compra" o "Pago")
        public int CreditCardID { get; set; }
    }
}
