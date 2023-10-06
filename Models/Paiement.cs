using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Paiement
{
    public string PaiementId { get; set; } = null!;

    public string ModePaiementId { get; set; } = null!;

    public string? MomtantPaiement { get; set; }

    public long? Telephone { get; set; }

    public DateTime? DatePaiement { get; set; }

    public string? EtatPaiement { get; set; }

    public string? Facturation { get; set; }

    public virtual ModePaiement ModePaiementIdNavigation { get; set; } = null!;

    public virtual ICollection<Reservation> IdReservations { get; set; } = new List<Reservation>();
}
