namespace EndavaNetApp.Models.Dto
{
    public class OrderDto
    {

        public int OrderID { get; set; }
        public int? NumberOfTickets { get; set; } 
        public float? TotalPrice { get; set; }
        public DateTime? OrderedAt { get; set; }
    }
}
