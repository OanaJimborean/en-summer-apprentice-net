using EndavaNetApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EndavaNetApp.Models;

public partial class TicketCategory
{
    public int TicketCategoryid { get; set; }

    public string? Description { get; set; }

    public float? Price { get; set; }

    public int? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    
}
