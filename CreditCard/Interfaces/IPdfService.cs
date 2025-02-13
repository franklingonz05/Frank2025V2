namespace CreditCard.Interfaces
{
    public interface IPdfService
    {
        Task<byte[]> GeneratePdf(string cardId);
    }
}