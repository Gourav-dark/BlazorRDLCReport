using AspNetCore.Reporting;
using BlazorRDLCReport.Server.Helper;
using BlazorRDLCReport.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mime;
using System.Text;

namespace BlazorRDLCReport.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportsController(IDataService dataService,IWebHostEnvironment webHostEnvironment)
        {
            _dataService = dataService;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> getReservations()
        {
            var reservations = await _dataService.GetReservationsAsync();
            DataTable reservationDataTable = ConvertListToDataTable.ToDataTable(reservations);
            string wwwRootFolder = _webHostEnvironment.WebRootPath;
            string reportPath = Path.Combine(wwwRootFolder, @"Reports\ReservationReport.rdlc");

            var localReport = new LocalReport(reportPath);

            Dictionary<string, string> parameters = new();
            parameters.Add("runby", "C00345");
            parameters.Add("arrivalStart",DateTime.Now.ToString("MM/dd/yyyy"));
            parameters.Add("arrivalEnd", DateTime.Now.ToString("MM/dd/yyyy"));
            parameters.Add("reservationStatus", "All");
            parameters.Add("flagType", "All");
            parameters.Add("sortCriteria", "Room NO");

            localReport.AddDataSource("dsReservation", reservationDataTable);
            var reportResult = localReport.Execute(RenderType.Pdf, 1, parameters, "");
            //return File(reportResult.MainStream, MediaTypeNames.Application.Octet, "ReservationReport.pdf");
            return (File(reportResult.MainStream, contentType: "application/pdf"));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> getProducts()
        {
            var products = await _dataService.GetProductsAsync();
            DataTable productDataTable = ConvertListToDataTable.ToDataTable(products);
            string wwwRootFolder = _webHostEnvironment.WebRootPath;
            string reportPath = Path.Combine(wwwRootFolder, @"Reports\ProductReport.rdlc");

            var localReport = new LocalReport(reportPath);
            Dictionary<string, string> parameters = new();
            parameters.Add("flag", "All");
            localReport.AddDataSource("dsProduct", productDataTable);
            var reportResult = localReport.Execute(RenderType.Pdf, 1, parameters,"");
            return File(reportResult.MainStream, MediaTypeNames.Application.Octet, "ProductReport.pdf");
        }
    }
}
