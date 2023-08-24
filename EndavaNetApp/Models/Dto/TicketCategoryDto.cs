namespace EndavaNetApp.Models.Dto
{
    public class TicketCategoryDto
    {
        public int TicketCategoryid { get; set; }

        public string? Description { get; set; }

        public float? Price { get; set; }

        public int? Eventid { get; set; }

        public virtual Event? Event { get; set; }
    }
}
