using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GogoDriverWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace GogoWeb.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GogoWebUser class
public class GogoWebUser : IdentityUser
{
    public string? Nom { get; set; }

    public string? Prenom { get; set; }
    public string? Sexe { get; set; }

    public string? Cni { get; set; }
    public string? NumPermi { get; set; }

    public string? NumCapacite { get; set; }

    public int? Etat { get; set; }

    public virtual ICollection<Plainte> Plaintes { get; set; } = new List<Plainte>();

    public virtual ICollection<Reservation> Reservtions { get; set; } = new List<Reservation>();

    public virtual ICollection<So> Sos { get; set; } = new List<So>();

    public virtual ICollection<Vehicule> IdVehicules { get; set; } = new List<Vehicule>();
}

