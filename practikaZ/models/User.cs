using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace practikaZ.models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int GenderId { get; set; }

    public int SpecializationId { get; set; }

    public int RoleId { get; set; }

    public int PostId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? PhoneNumber { get; set; }

    public string? JobPhoneNumber { get; set; }

    public virtual ICollection<Announcement> AnnouncementAuthors { get; set; } = new List<Announcement>();

    public virtual ICollection<Announcement> AnnouncementTargetUsers { get; set; } = new List<Announcement>();

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Post Post { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual Specialization Specialization { get; set; } = null!;

    public virtual ICollection<Userachievement> Userachievements { get; set; } = new List<Userachievement>();
    
    [NotMapped]
    public string FullName => $"{LastName} {FirstName} {Patronymic}";
}
