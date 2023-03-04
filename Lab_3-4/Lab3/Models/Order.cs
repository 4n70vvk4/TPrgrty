namespace Lab3.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string? Client { get; set; }
        public string? Consultant { get; set; }
        public DateTime Date_and_time_of_delivery { get; set; }
        public string? Comment { get; set; }
        public string? Amount { get; set; }
    }
}
