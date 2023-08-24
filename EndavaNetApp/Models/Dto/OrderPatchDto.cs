namespace EndavaNetApp.Models.Dto
{
    public class OrderPatchDto
    {
        public int OrderID { get; set; }
        public int NumberOfTickets { get; set; }
        //public float TotalPrice { get; set; }


        public int TicketCategoryid { get; set; }
    }
}
