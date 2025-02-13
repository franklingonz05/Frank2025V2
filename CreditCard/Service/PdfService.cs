using CreditCard.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CreditCard.Service
{
    public class PdfService : IPdfService
    {
        private readonly ICreditCardsService _creditCardsService;

        public PdfService(ICreditCardsService creditCardsService)
        {
            _creditCardsService = creditCardsService;
        }


        public async Task<byte[]> GeneratePdf(string cardId)
        {
            // Obtén la información del estado de cuenta desde ICreditCardsService
            var accountStatement = (await _creditCardsService.GetAccountStatemenByCardIdAsync(cardId)).Data;

            // Genera el PDF utilizando QuestPDF
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);

                    page.Header()
                        .AlignCenter()
                        .Text("Estado de Cuenta", TextStyle.Default.Size(18).Bold());

                    page.Content()
                        .Column(column =>
                        {
                            column.Item().Text($"Nombre del titular: {accountStatement.CardHolderName}");
                            column.Item().Text($"Número de tarjeta: {accountStatement.CardNumber}");
                            column.Item().Text($"Límite de crédito: {accountStatement.CreditLimit:C}");
                            column.Item().Text($"Crédito disponible: {accountStatement.AvailableCredit:C}");
                            column.Item().Text($"Balance total: {accountStatement.TotalBalance:C}");
                            column.Item().Text($"Compras mes actual: {accountStatement.TotalPurchasesCurrentMonth:C}");
                            column.Item().Text($"Compras mes anterior: {accountStatement.TotalPurchasesPreviousMonth:C}");
                            column.Item().Text($"Correo electrónico: {accountStatement.Email}");
                            column.Item().Text($"Número de teléfono: {accountStatement.PhoneNumber}");
                            column.Item().Text($"Intereses cobrados: {accountStatement.InterestCharged:C}");
                            column.Item().Text($"Pago mínimo: {accountStatement.MinimumPayment:C}");
                            column.Item().Text($"Monto total a pagar: {accountStatement.TotalAmountDue:C}");
                            column.Item().Text($"Monto total a pagar con intereses: {accountStatement.TotalAmountDueWithInterest:C}");
                        });
                });
            }).GeneratePdf();
        }
    }
}
