﻿using System;
using System.Collections.Generic;

namespace practikaZ.models;

public partial class Userachievement
{
    public int UserId { get; set; }

    public int AchievementId { get; set; }

    public string? Desc { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
