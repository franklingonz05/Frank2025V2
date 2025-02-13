using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Models.DTOs
{
    public class CreditCardDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClientID { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
        public int CreditCardID { get; set; }
    }
}
