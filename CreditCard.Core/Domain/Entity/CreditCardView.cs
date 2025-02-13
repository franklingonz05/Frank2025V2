using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Domain.Entity
{
    public class CreditCardView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClientID { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
        public int CreditCardID { get; set; }

    }
}
