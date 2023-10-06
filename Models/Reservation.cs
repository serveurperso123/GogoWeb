using GogoWeb.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Reservation
{
    public string ReservationId { get; set; } = null!;

    public string GogoWebUserId { get; set; } = null!;

    public string TypeReservationId { get; set; } = null!;

    public DateTime? DateReservation { get; set; }

    public DateTime? HeureDebut { get; set; }

    public DateTime? HeureFin { get; set; }

    public bool? Position { get; set; }

    public int? NbrePassages { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual GogoWebUser GogoWebUserIdNavigation { get; set; } = null!;

    public virtual TypeReservation TypeReservationIdNavigation { get; set; } = null!;

    public virtual ICollection<Paiement> IdPaiements { get; set; } = new List<Paiement>();
}
