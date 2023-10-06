using GogoWeb.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Vehicule
{
    public string? VehiculeId { get; set; } 

    public string? TypevehiculeId { get; set; } 

    public string? TypeReservationId { get; set; } 
    public string? NomVehicule { get; set; }

    public string? Immatriculation { get; set; }

    public string? Couleur { get; set; }

    public string? Assurance { get; set; }

    public int? NumeroChassis { get; set; }

    public string? Marque { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual TypeReservation TypeReservationIdNavigation { get; set; } = null!;

    public virtual TypeVehicule TypevehiculeIdNavigation { get; set; } = null!;

    public virtual ICollection<GogoWebUser> Ids { get; set; } = new List<GogoWebUser>();
}
