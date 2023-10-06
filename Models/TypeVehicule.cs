using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class TypeVehicule
{
    public string? TypevehiculeId { get; set; } 

    public string? Standard { get; set; }

    public string? Vip { get; set; }

    public virtual ICollection<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
}
