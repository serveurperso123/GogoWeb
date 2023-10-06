using GogoWeb.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class So
{
    public string SoId { get; set; } = null!;

    public string GogoWebUserId { get; set; } = null!;

    public int? Localisation { get; set; }

    public string? Description { get; set; }

    public virtual GogoWebUser PersonneIdNavigation { get; set; } = null!;
}
