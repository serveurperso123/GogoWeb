using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class ModePaiement
{
    public string ModePaiementId { get; set; } = null!;

    public string? LibelleMode { get; set; }

    public string? Pourcentage { get; set; }

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}
