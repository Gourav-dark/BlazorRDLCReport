namespace BlazorRDLCReport.Shared.Models
{
    public class Reservation
    {
        public string GuestName { get; set; }
        public string Room { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string ReservationStatus { get; set; }
        public string FlagStatus { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public DateTime DateEntered { get; set; }
        public string EnteredBy { get; set; }
        public DateTime DateDelivered { get; set; }
        public string DeliveredBy { get; set; }
        public string Type { get; set; }
    }
}
