using BlazorRDLCReport.Shared.Models;

namespace BlazorRDLCReport.Shared.Services
{
    public class DataService : IDataService
    {
        private readonly List<Reservation> reservations;
        private readonly List<Product> products;

        public DataService()
        {
            products = GenerateProductsData(50);
            reservations = GenerateReservationsData(30);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return products;
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return reservations;
        }


        private List<Reservation> GenerateReservationsData(int count)
        {
            var data = new List<Reservation>();
            var random = new Random();

            for (int i = 1; i <= count; i++)
            {
                data.Add(new Reservation
                {
                    GuestName = $"Guest {i}",
                    Room = $"Room {random.Next(100, 200)}",
                    ArrivalDate = DateTime.Now.AddDays(random.Next(1, 30)),
                    DepartureDate = DateTime.Now.AddDays(random.Next(3, 10)),
                    ReservationStatus = i % 2 == 0 ? "Reserved" : "InHouse",
                    FlagStatus = GetRandomFlagStatus(random),
                    Topic = $"Topic {random.Next(1, 5)}",
                    Message = $"Message for reservation {i}",
                    DateEntered = DateTime.Now.AddDays(-random.Next(1, 10)),
                    EnteredBy = $"Staff {random.Next(1, 5)}",
                    DateDelivered = DateTime.Now.AddDays(-random.Next(1, 5)).AddHours(random.Next(1, 12)),
                    DeliveredBy = $"Staff {random.Next(1, 5)}",
                    Type = GetRandomType(random)
                });
            }
            return data;
        }
        private string GetRandomFlagStatus(Random random)
        {
            var flagStatuses = new[] { "Open", "Close", "Active", "None" };
            return flagStatuses[random.Next(flagStatuses.Length)];
        }
        private string GetRandomType(Random random)
        {
            var types = new[] { "AirlineInfo", "Alert", "BedBridge" };
            return types[random.Next(types.Length)];
        }
        private List<Product> GenerateProductsData(int count)
        {
            var data = new List<Product>();
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                data.Add(new Product
                {
                    Id = random.Next(20, 100),
                    Name = "Product " +random.Next(40,60),
                    Price = random.Next(50,500)
                });
            }
            return data;
        }
    }
}
