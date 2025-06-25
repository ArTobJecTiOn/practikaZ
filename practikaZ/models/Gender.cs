using System;
using System.Collections.Generic;

namespace practikaZ.models;

public partial class Gender
{
    public int Id { get; set; }

    public string Gender1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
