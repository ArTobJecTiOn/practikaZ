using System;
using System.Collections.Generic;

namespace practikaZ.models;

public partial class Specialization
{
    public int Id { get; set; }

    public string SpecializationName { get; set; } = null!;

    public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
