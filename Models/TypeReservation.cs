using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class TypeReservation
{
    public string TypeReservationId { get; set; } = null!;

    public string? NomType { get; set; }

    public decimal? PrixUnitaire { get; set; }

    public int? TauxPeriodique { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
}
