using AutoMapper;
using CreditCard.Interfaces;
using CreditCard.Models;
using CreditCard.Models.DTOs;
using CreditCard.Models.Enum;
using CreditCard.Models.ViewModel;
using CreditCard.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreditCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransactionService service;
        private readonly ICreditCardsService creditCardsService;
        private readonly IMapper mapper;
        private readonly IReportService _reportService;
        private readonly IPdfService pdfService;

        public HomeController(ILogger<HomeController> logger, ITransactionService service,ICreditCardsService creditCardsService,IMapper mapper, IReportService reportService, IPdfService pdfService)
        {
            _logger = logger;
            this.service = service;
            this.creditCardsService = creditCardsService;
            this.mapper = mapper;
            _reportService = reportService;
            this.pdfService = pdfService;
        }

        public IActionResult Index()
        {
            var response = creditCardsService.GetAllAsync().Result;
            var response2 = creditCardsService.GetAccountStatemenByCardIdAsync("1234567890123456").Result;

            if (response.IsSuccess && response.Data != null)
            {
                return View(response.Data);
            }

            // En caso de error, pasar un modelo vacío o un mensaje de error
            ViewBag.ErrorMessage = response.Message ?? "No se pudieron cargar las tarjetas.";
            return View(new List<CreditCardDTO>());
        }


        public ActionResult Details(int id)
        {
            var response = creditCardsService.GetAllAsync().Result;
            var card = response.Data.FirstOrDefault(x => x.CreditCardID == id);

            // Obteniendo transacciones
            var transactionResponse = service.GetTransactionsByCardIdAsync(card.CardNumber).Result;
            var transactions = transactionResponse.Data;

            // Creando el ViewModel
            var viewModel = new CreditCardDetails
            {
                CreditCard = card,
                Transactions = transactions
            };

            return View(viewModel);  // Pasando el ViewModel a la vista
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Esta línea valida el token CSRF
        public IActionResult AddTransaction(CreateTransactionViewModel transaction)
        {
            if (ModelState.IsValid)
            {

                var resul = service.CreateAsync(mapper.Map<CreateTransaction>(transaction)).Result;

                // Lógica para agregar la transacción
                return RedirectToAction("Details", new { id = transaction.CreditCardID });
            }

            // Si la validación falla, vuelve a mostrar el formulario
            return View(transaction);
        }


        public IActionResult Privacy()
        {
            return View();
        }


        public async Task<IActionResult> AccountStatement(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("El Id proporcionado no es válido.");
            }



            // Llamar al servicio para generar el PDF con el ID de la tarjeta
            var pdfBytes = await pdfService.GeneratePdf(id);

            Response.Headers["Content-Disposition"] = $"inline; filename=estado_de_cuenta.pdf";
            // Devolver el archivo PDF para abrir en una nueva pestaña
            return File(pdfBytes, "application/pdf", "estado_de_cuenta.pdf");


            //string reportName = Guid.NewGuid().ToString();
            //byte[] reportBytes = await _reportService.GenerateReportAsync(reportName, RenderReportType.Pdf, id);

            //if (reportBytes == null || reportBytes.Length == 0)
            //{
            //    return NotFound("No se pudo generar el reporte.");
            //}

            //string extensionType = _reportService.GetReportExtensionType(RenderReportType.Pdf);
            //// Configurar encabezado Content-Disposition como "inline"
            //Response.Headers["Content-Disposition"] = $"inline; filename={reportName}.{extensionType}";

            //return File(reportBytes, "application/pdf");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
