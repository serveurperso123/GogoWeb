using GogoWeb.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Plainte
{
    public string PlainteId { get; set; } = null!;

    public string GogoWebUserId { get; set; } = null!;

    public string? LibellePlainte { get; set; }

    public DateTime? DatePlainte { get; set; }

    public virtual GogoWebUser GogoWebUserIdNavigation { get; set; } = null!;
}
