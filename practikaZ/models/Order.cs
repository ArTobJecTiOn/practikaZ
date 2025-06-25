using System;
using System.Collections.Generic;

namespace practikaZ.models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string? OrderStatus { get; set; }

    public int Quantity { get; set; }

    public string Description { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
