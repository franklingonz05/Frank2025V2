using CreditCard.Models.Enum;

namespace CreditCard.Interfaces
{
    public interface IReportService
    {
        Task<byte[]> GenerateReportAsync(string reportName, RenderReportType reportType,string id);
        string GetReportExtensionType(RenderReportType reportType);
    }
}