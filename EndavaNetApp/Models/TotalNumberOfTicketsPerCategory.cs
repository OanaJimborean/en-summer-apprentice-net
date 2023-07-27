using System;
using System.Collections.Generic;

namespace EndavaNetApp.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int? TicketCategoryid { get; set; }

    public int? TotalNumberOfTickets { get; set; }

    public double? TotalSales { get; set; }
}
