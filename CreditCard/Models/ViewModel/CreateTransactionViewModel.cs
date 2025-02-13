using System.ComponentModel.DataAnnotations;

namespace CreditCard.Models.ViewModel
{
    public class CreateTransactionViewModel
    {
        public int CreditCardID { get; set; }

        [Required(ErrorMessage = "El tipo de transacción es obligatorio.")]
        [Range(1, 2, ErrorMessage = "Seleccione un tipo de transacción válido.")]
        public int Type { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(250, ErrorMessage = "La descripción no puede tener más de 250 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La fecha de la transacción es obligatoria.")]
        public DateTime TransactionDate { get; set; }
    }
}
