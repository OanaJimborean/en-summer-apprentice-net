using System;
using System.Collections.Generic;

namespace EndavaNetApp.Models;

public partial class Customer
{
    public int Customerid { get; set; }

    public string? CustomerName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
