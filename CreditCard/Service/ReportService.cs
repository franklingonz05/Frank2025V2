using CreditCard.Interfaces;
using CreditCard.Models.DTOs;
using CreditCard.Models.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Reporting.NETCore;

namespace CreditCard.Service
{
    public class ReportService : IReportService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICreditCardsService creditCardsService;

        public ReportService(IWebHostEnvironment webHostEnvironment, ICreditCardsService creditCardsService)
        {
            _webHostEnvironment = webHostEnvironment;
            this.creditCardsService = creditCardsService;
        }


        /// <summary>
        /// Genera un reporte de jugadores.
        /// </summary>
        /// <param name="reportName">Nombre del archivo .rdlc del reporte</param>
        /// <param name="reportType">Tipo del reporte que se desea obtener.</param>
        /// <returns>Un byte[] con los datos.</returns>
        public async Task<byte[]> GenerateReportAsync(string reportName, RenderReportType reportType, string id)
        {

            string reportPath = Path.Combine(_webHostEnvironment.WebRootPath, "RDLC", $"rpt_cuenta.rdlc");

            //var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes/RDLC/AlphaCCF.rdlc");

            var data = creditCardsService.GetAccountStatemenByCardIdAsync(id).Result;
            var ds = data.Data != null ? new List<AccountStatementDTO> { data.Data } : new List<AccountStatementDTO>();

            //RDLC con el reporte que necesitamos
            using FileStream fs = new(reportPath, FileMode.Open);

            LocalReport report = new();
            report.LoadReportDefinition(fs);
            report.DataSources.Add(new ReportDataSource("DataSet1", ds));

            //si tenemos parametros en el reporte los agregariamos asi
            // report.SetParameters(new[] { new ReportParameter("parameter1", "RDLC Sample Report ") });

            byte[] output = report.Render(GetRenderType(reportType));
            fs.Dispose();

            return output;
        }

        /// <summary>
        /// Devuelve el nombre de renderizado para un archivo.
        /// </summary>
        /// <param name="reportType">Tipo de reporte que se desea generar.</param>
        /// <returns>Un string con el nombre del tipo.</returns>
        private string GetRenderType(RenderReportType reportType)
        {

            return reportType switch
            {
                RenderReportType.Word => "WORDOPENXML",
                RenderReportType.Excel => "EXCELOPENXML",
                _ => "PDF",
            };
        }

        /// <summary>
        /// Obtiene la extension que se debe colocar a un reporte.
        /// </summary>
        /// <param name="reportType">Tipo de reporte que se desea.</param>
        /// <returns>Un string con la extension del archivo.</returns>
        public string GetReportExtensionType(RenderReportType reportType)
        {
            return reportType switch
            {
                RenderReportType.Word => "docx",
                RenderReportType.Excel => "xlsx",
                _ => "pdf",
            };
        }
    }
}
