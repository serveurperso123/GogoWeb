using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Course
{
    public string CourseId { get; set; } = null!;

    public string VehiculeId { get; set; } = null!;

    public DateTime? DateCourse { get; set; }

    public DateTime? HeureCourse { get; set; }

    public int? EtatCourse { get; set; }

    public bool? Destination { get; set; }

    public bool? Position { get; set; }

    public virtual Reservation ReservationIdNavigation { get; set; } = null!;

    public virtual Vehicule VehiculeIdNavigation { get; set; } = null!;
}
