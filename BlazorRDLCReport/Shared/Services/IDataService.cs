using BlazorRDLCReport.Shared.Models;

namespace BlazorRDLCReport.Shared.Services
{
    public interface IDataService
    {
        Task<List<Reservation>> GetReservationsAsync();
        Task<List<Product>> GetProductsAsync();
    }
}
