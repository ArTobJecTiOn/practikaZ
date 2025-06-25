using System;
using System.Collections.Generic;

namespace practikaZ.models;

public partial class Announcement
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public int? AuthorId { get; set; }

    public int? TargetRoleId { get; set; }

    public int? TargetPostId { get; set; }

    public int? TargetSpecializationId { get; set; }

    public int? TargetUserId { get; set; }

    public virtual User? Author { get; set; }

    public virtual Post? TargetPost { get; set; }

    public virtual Role? TargetRole { get; set; }

    public virtual Specialization? TargetSpecialization { get; set; }

    public virtual User? TargetUser { get; set; }

    public string ShortMessage => Message.Length > 100 ? Message.Substring(0, 100) + "..." : Message;
}
